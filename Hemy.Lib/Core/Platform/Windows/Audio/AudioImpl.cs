#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using HRESULT = System.UInt32;
using Hemy.Lib.Core.Sys;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;
using Hemy.Lib.Core;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class AudioImpl
{
    internal static int Init(AudioData* contextData)
    {
        const float SpeedOfSound = 345.0f;

        contextData->AudioModule = GetAudioModuleDLL();
        if (contextData->AudioModule == nint.Zero)
        {
            Log.Error("Load XAUDIO2 DLL");
            return 1;
        }

        Load(LibraryLoader.GetSymbol, contextData->AudioModule);

        IXAudio2* Instance = null;
        var err = XAudio2Create(&Instance, 0, AudioConsts.XAUDIO2_DEFAULT_PROCESSOR);

        // if ( Instance == null || err != (uint)XAUDIO2_ERRORS.XAUDIO2_SUCESS, "Create Xaudio2 INSTANCE ")) { return 1; }

        IXAudio2 iXAudio2Temp = new(Instance);
        contextData->AudioInstance = Memory.Memory.New<IXAudio2>(withCopyInstance: false);//pool->New<IXAudio2>( );
        Memory.Memory.Copy(Memory.Memory.ToPtr(ref iXAudio2Temp), contextData->AudioInstance, Memory.Memory.Size<IXAudio2>());

#if DEBUG
        contextData->Debug = Memory.Memory.New<XAUDIO2_DEBUG_CONFIGURATION>(false);// pool->New<XAUDIO2_DEBUG_CONFIGURATION>( new() );	
        contextData->Debug->LogThreadID = 0;
        contextData->Debug->LogFileline = 0;
        contextData->Debug->LogFunctionName = 0;
        contextData->Debug->LogTiming = 0;
        contextData->Debug->TraceMask = AudioConsts.XAUDIO2_LOG_ERRORS | AudioConsts.XAUDIO2_LOG_WARNINGS | AudioConsts.XAUDIO2_LOG_INFO;
        contextData->Debug->BreakMask = AudioConsts.XAUDIO2_LOG_ERRORS;
        contextData->AudioInstance->SetDebugConfiguration(contextData->Debug, null);

        if (contextData->Debug == null) { Log.Error("Create Xaudio2 Debug ");  return 1; }
#endif

        // IXAudio2EngineCallback mEngineCallback;
        // err = contextData->AudioInstance->RegisterForCallbacks( &mEngineCallback );
        // if ( Log.Check(err != 0, "Create Xaudio2 Debug ")) { return 1; }

        WAVEFORMATEX waveFormatEx = default;
        waveFormatEx.nChannels = 2;
        waveFormatEx.nSamplesPerSec = 0;
        IXAudio2MasteringVoice* tempMaster = null;
        err = contextData->AudioInstance->CreateMasteringVoice(&tempMaster, 2, 0, 0, null, null, AudioConsts.AUDIO_STREAM_CATEGORY_GameEffects);

        if (tempMaster == null) { Log.Error("Create Xaudio2 Master Voice"); return 1; }

        IXAudio2MasteringVoice iXAudio2MasteringVoice = new(tempMaster);
        contextData->MasterVoice = Memory.Memory.New<IXAudio2MasteringVoice>(false);
        Memory.Memory.Copy(Memory.Memory.ToPtr(ref iXAudio2MasteringVoice), contextData->MasterVoice, Memory.Memory.Size<IXAudio2MasteringVoice>());


        uint channelMask = 0;
        err = contextData->MasterVoice->GetChannelMask(&channelMask);

        if (err != 0 ){ Log.Error("GetChannel MAsk "); return 1; }

        X3DAUDIO_HANDLE* Handle3D;
        err = (uint)X3DAudioInitialize(channelMask, SpeedOfSound, &Handle3D);

        contextData->Handle3D = Handle3D;

        if (Handle3D == null ){ Log.Error("X3D Audio "); return 1; }

        return 0;
    }

    internal static void Dispose(AudioData* audioData)
    {
        if (audioData->AudioInstance == null) return;

        if (audioData->MasterVoice != null)
            audioData->MasterVoice->DestroyVoice();

        var error = audioData->AudioInstance->Release();

        Memory.Memory.Dispose(audioData->AudioInstance);
        Memory.Memory.Dispose(audioData->Debug);
        Memory.Memory.Dispose(audioData->MasterVoice);
        // Memory.Dispose(audioData->Handle3D); // TODO ne pas faire dispose Pourquoi ?

        LibraryLoader.Unload(audioData->AudioModule);
    }

    internal static void SetVolume(AudioData* audioData, float value)
    {
        //clamp  value < min ? min : value > max ? max : value
        // audioData->Volume = value;
        var err = audioData->MasterVoice->SetVolume(value);
        if (err != 0)
            Log.Error("Set Volume failed");
    }

    internal static void Suspend(AudioData* audioData)
    {
        if (audioData->AudioInstance == null) return;

        audioData->AudioInstance->StopEngine();
    }

    internal static void Resume(AudioData* audioData)
    {
        if (audioData->AudioInstance == null) return;

        var result = audioData->AudioInstance->StartEngine();
        if (result != 0)
        {
            Log.Error("Resume of the audio engine failed; running in 'silent mode");
            //Silent MOde
        }
    }

    internal static void Reset(AudioData* audioData)
    {
        if (audioData->AudioInstance != null)
            Dispose(audioData: audioData);

        Init(audioData);
    }

    // internal static bool UpdateDsp(AudioData* audioData) // src : https://rastertek.com/dx11win10tut58.html
    // {
    // 	X3DAUDIO_EMITTER emitter;
    // 	IXAudio2SourceVoice* sourceVoice = null;
    // 	X3DAUDIO_HANDLE m_X3DInstance;
    // 	X3DAUDIO_LISTENER m_listener;
    // 	XAUDIO2_VOICE_DETAILS m_deviceDetails;
    // 	float* m_matrixCoefficients;
    // 	X3DAUDIO_DSP_SETTINGS m_DSPSettings;

    // 	// Call X3DAudioCalculate to calculate new settings for the voices.
    // 	XAudioNative.X3DAudioCalculate(audioData->Handle3D , &m_listener, &emitter, X3DAudioConsts.X3DAUDIO_CALCULATE_MATRIX | X3DAudioConsts.X3DAUDIO_CALCULATE_DOPPLER | X3DAudioConsts.X3DAUDIO_CALCULATE_LPF_DIRECT | X3DAudioConsts.X3DAUDIO_CALCULATE_REVERB, &m_DSPSettings);

    // 	// Use SetOutputMatrix and SetFrequencyRatio to apply the volume and pitch values to the source voice.
    // 	var result = sourceVoice->SetOutputMatrix(audioData->MasterVoice, 1, m_deviceDetails.InputChannels, m_DSPSettings.pMatrixCoefficients);

    // 	result = sourceVoice->SetFrequencyRatio(m_DSPSettings.DopplerFactor);

    [SuppressUnmanagedCodeSecurity]
    [SuppressGCTransition]
    [SkipLocalsInit]
    public static void CreateEmiter(X3DAUDIO_EMITTER* Emitter /*, vector3 orientation , vector3 position , vector3 up , vector3 velocity */ )
    {
        // X3DAUDIO_EMITTER Emitter =new();
        Emitter->ChannelCount = 1;
        Emitter->CurveDistanceScaler = Emitter->DopplerScaler = 1.0f;
        // Emitter.OrientFront = EmitterOrientFront;
        // Emitter.OrientTop = EmitterOrientTop;
        // Emitter.Position = EmitterPosition;
        // Emitter.Velocity = EmitterVelocity;
    }

    [SuppressUnmanagedCodeSecurity]
    [SuppressGCTransition]
    [SkipLocalsInit]
    public static void CreateListener(X3DAUDIO_LISTENER* Listener /*, vector3 orientation , vector3 position , vector3 up , vector3 velocity */  )
    {
        _ = Listener;
        // X3DAUDIO_LISTENER Listener =new();
        // Listener.OrientFront = ListenerOrientFront;
        // Listener.OrientTop = ListenerOrientTop;
        // Listener.Position = ListenerPosition;
        // Listener.Velocity = ListenerVelocity;
    }

    [SuppressUnmanagedCodeSecurity]
    [SuppressGCTransition]
    [SkipLocalsInit]
    public static void CreateDSP(ref X3DAUDIO_LISTENER Listener, ref X3DAUDIO_EMITTER Emitter, ref IXAudio2SourceVoice pSFXSourceVoice, ref IXAudio2Voice destinationVoice)
    {
        _ = Listener;
        _ = Emitter;
        _ = pSFXSourceVoice;
        _ = destinationVoice;
        // XAUDIO2_VOICE_DETAILS details ;
        // MasterVoice.GetVoiceDetails( &details);

        // X3DAUDIO_DSP_SETTINGS DSPSettings = new();
        // float[] matrix = new float[(int)details.InputChannels];
        // DSPSettings.SrcChannelCount = 1;
        // DSPSettings.DstChannelCount = details.InputChannels;
        // fixed( float* mat = &matrix[0]){ DSPSettings.pMatrixCoefficients = mat; }

        // // CalculateNewSettingForVoice()
        // fixed( X3DAUDIO_EMITTER* emit =&Emitter )
        // {
        //     fixed(X3DAUDIO_LISTENER* listen = &Listener  )
        //     {
        //         X3DAudio. X3DAudioCalculate(Handle ,listen  ,emit,
        //         X3DAudio.X3DAUDIO_CALCULATE_MATRIX | X3DAudio.X3DAUDIO_CALCULATE_DOPPLER |X3DAudio. X3DAUDIO_CALCULATE_LPF_DIRECT | X3DAudio.X3DAUDIO_CALCULATE_REVERB,
        //         &DSPSettings );
        //     }
        // }

    }

    [SuppressUnmanagedCodeSecurity]
    [SuppressGCTransition]
    [SkipLocalsInit]
    public static void Create3DSound(ref IXAudio2SourceVoice pSFXSourceVoice, ref IXAudio2Voice destinationVoice, ref X3DAUDIO_DSP_SETTINGS DSPSettings)
    {
        _ = pSFXSourceVoice;
        _ = destinationVoice;
        _ = DSPSettings;
        // pSFXSourceVoice.SetOutputMatrix( MasterVoice, 1, details.InputChannels, DSPSettings.pMatrixCoefficients ) ;
        // pSFXSourceVoice.SetFrequencyRatio(DSPSettings.DopplerFactor);

        // pSFXSourceVoice.SetOutputMatrix(destinationVoice, 1, 1, &DSPSettings.ReverbLevel);
        // XAUDIO2_FILTER_PARAMETERS FilterParameters = new() ;//{ LowPassFilter, 2.0f * sinf(X3DAUDIO_PI/6.0f * DSPSettings.LPFDirectCoefficient), 1.0f };
        // pSFXSourceVoice.SetFilterParameters(&FilterParameters);
    }

  

    // public unsafe static void CreateSourceVoice( IXAudio2SourceVoice* sourcevoice,WAVEFORMATEX sourceformat, uint Flags = 0,  float MaxFrequencyRatio = 1.0f, IXAudio2VoiceCallback* pCallback = null, XAUDIO2_VOICE_SENDS* pSendList = null, XAUDIO2_EFFECT_CHAIN* pEffectChain = null)
    // {
    //     // XAUDIO2_VOICE_SENDS* send =pSendList;
    //     // Instance.CreateSourceVoice( ref sourcevoice ,sourceformat, 0,MaxFrequencyRatio,null, send,null);
    // }

    // public unsafe static void CreateOneEmitterWithMultipleBufferOrMultipleEmitterWithOneBuffer()
    // {

    // }


    static nint GetAudioModuleDLL()
    {
        var AudioModule = LibraryLoader.Load(XAudio2_9);

        if (AudioModule != nint.Zero) { return AudioModule; }

        AudioModule = LibraryLoader.Load(XAudio2_8);

        if (AudioModule != nint.Zero) { return AudioModule; }

        AudioModule = LibraryLoader.Load(XAudio1_7);

        if (AudioModule != nint.Zero) { return AudioModule; }

        return nint.Zero;
    }
    
     // TODO replace System.MAth by own method  ( Log10 , Sin POw ASin )
    public static float XAudio2DecibelsToAmplitudeRatio(float Decibels)
        => Math.MathFuncs.powf(10.0f, Decibels / 20.0f);

    /// <summary>
    /// // Inline function that converts an amplitude ratio value to a decibel value.
    /// </summary>
    /// <param name="Volume"></param>
    /// <returns></returns>
    public static float XAudio2AmplitudeRatioToDecibels(float Volume)
        => Volume == 0.0f ? -3.402823466e+38f : 20.0f * Math.MathFuncs.clog10f(Volume);

    public static float XAudio2SemitonesToFrequencyRatio(float Semitones)
        => Math.MathFuncs.powf(2.0f, Semitones / 12.0f);

    public static float XAudio2FrequencyRatioToSemitones(float FrequencyRatio)
        => 39.86313713864835f * Math.MathFuncs.clog10f(FrequencyRatio);

    public static float XAudio2CutoffFrequencyToRadians(float CutoffFrequency, uint SampleRate)
        => (uint)(CutoffFrequency * 6.0f) >= SampleRate ? 1.0f : 2.0f * Math.MathFuncs.sinf((float)3.14159265358979323846 * CutoffFrequency / SampleRate);

    public static float XAudio2RadiansToCutoffFrequency(float Radians, float SampleRate)
        => SampleRate * Math.MathFuncs.asinf(Radians / 2.0f) / (float)3.14159265358979323846;

    public static float XAudio2CutoffFrequencyToOnePoleCoefficient(float CutoffFrequency, uint SampleRate)
        => (uint)CutoffFrequency >= SampleRate ? 1.0f : 1.0f - Math.MathFuncs.powf(1.0f - (2.0f * CutoffFrequency / SampleRate), 2.0f);


    /// <summary> Creates a new XAudio2 object and returns a pointer to its IXAudio2 interface. </summary>
    private static delegate* unmanaged[MemberFunction]<IXAudio2**, uint, uint, HRESULT> PFN_XAudio2Create = null;
    private static delegate* unmanaged[MemberFunction]<void**, uint, HRESULT> PFN_CreateAudioReverb = null;
    private static delegate* unmanaged[MemberFunction]<void**, uint, HRESULT> PFN_CreateAudioVolumeMeter = null;
    private static delegate* unmanaged[MemberFunction]<uint, float, X3DAUDIO_HANDLE**, HRESULT> PFN_X3DAudioInitialize = null;
    private static delegate* unmanaged[MemberFunction]<void*, void*, void*, uint, void*, void> PFN_X3DAudioCalculate = null;

    public unsafe delegate nint LoadFunction(nint ptr, string name);

    public static void Load(LoadFunction load, nint module)
    {
        PFN_XAudio2Create = (delegate* unmanaged[MemberFunction]<IXAudio2**, uint, uint, HRESULT>)load(module, "XAudio2Create");
        PFN_CreateAudioReverb = (delegate* unmanaged[MemberFunction]<void**, uint, HRESULT>)load(module, "CreateAudioReverb");
        PFN_CreateAudioVolumeMeter = (delegate* unmanaged[MemberFunction]<void**, uint, HRESULT>)load(module, "CreateAudioVolumeMeter");
        PFN_X3DAudioInitialize  = (delegate* unmanaged[MemberFunction]<uint, float, X3DAUDIO_HANDLE**, HRESULT>)load(module, "X3DAudioInitialize"); 
        PFN_X3DAudioCalculate = (delegate* unmanaged[MemberFunction]<void*, void*, void*, uint, void*, void>)load(module, "X3DAudioCalculate");

    }

    // XAUDIO2 
    [SuppressGCTransition]
    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    internal static HRESULT XAudio2Create(IXAudio2** ppXAudio2, uint Flags = 0, uint XAudio2Processor = AudioConsts.XAUDIO2_DEFAULT_PROCESSOR)
        => PFN_XAudio2Create(ppXAudio2, Flags, XAudio2Processor);

    // XAUDIO 3D
    [SuppressGCTransition]
    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    internal static HRESULT X3DAudioInitialize(uint SpeakerChannelMask, float SpeedOfSound, X3DAUDIO_HANDLE** Instance)
        => PFN_X3DAudioInitialize(SpeakerChannelMask, SpeedOfSound, Instance);

    [SuppressGCTransition]
    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    internal static void X3DAudioCalculate(X3DAUDIO_HANDLE* Instance, X3DAUDIO_LISTENER* pListener, X3DAUDIO_EMITTER* pEmitter, uint Flags, X3DAUDIO_DSP_SETTINGS* pDSPSettings)
        => PFN_X3DAudioCalculate(Instance, pListener, pEmitter, Flags, pDSPSettings);

    //XAUDIO2 FX
    [SuppressGCTransition]
    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    internal static HRESULT CreateAudioReverb(void** ppApo, uint flags)
        => PFN_CreateAudioReverb(ppApo, flags);

    [SuppressGCTransition]
    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    internal static HRESULT CreateVolumeMeter(void** ppApo, uint flags)
        => PFN_CreateAudioVolumeMeter(ppApo, flags);



}


#endif
