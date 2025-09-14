#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Window;

using WORD = System.UInt16;
using DWORD = System.UInt32; // A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.
using HRESULT = System.UInt32;
using BOOL = System.Int32;


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioData()
{
    internal nint AudioModule = 0;
    // internal XAudio_Version Version = XAudio_Version.Unknown;
    // internal float Volume = 1.0f;
    // internal uint ChannelMask = 0;
    // internal uint Channels = 0;
    // internal uint SampleRate = 0;
    // internal float SpeedOfSound = 345.0f;
    internal IXAudio2* AudioInstance = null;
    internal IXAudio2MasteringVoice* MasterVoice = null;
    // internal IXAudio2Voice* VoiceDetails = null;
    // internal XAUDIO2_PERFORMANCE_DATA* Performance = null;

    internal XAUDIO2_DEBUG_CONFIGURATION* Debug;
    internal X3DAUDIO_HANDLE* Handle3D;
}



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

        Load(WindowsLibrary.GetSymbol, contextData->AudioModule);

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

        if (contextData->Debug == null) { Log.Error("Create Xaudio2 Master Voice"); return 1; }

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

        WindowsLibrary.Unload(audioData->AudioModule);
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

    // internal static bool Update3D(WindowsContextData* audioData) // src : https://rastertek.com/dx11win10tut58.html
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

    /// <summary>
    /// Calculates DSP settings for the specified listener and emitter. See remarks.
    /// </summary>
    // public static unsafe void Calculate(Listener listener, Emitter emitter, uint flags, DspSettings settings)
    // {
    //     if (settings == null) throw new ArgumentNullException("settings");

    //     DspSettings.__Native settingsNative;
    //     settingsNative.SrcChannelCount = settings.SourceChannelCount;
    //     settingsNative.DstChannelCount = settings.DestinationChannelCount;

    //     fixed (void* pMatrix = settings.MatrixCoefficients)
    //     fixed (void* pDelays = settings.DelayTimes)
    //     {
    //         settingsNative.MatrixCoefficientsPointer = (IntPtr)pMatrix;
    //         settingsNative.DelayTimesPointer = (IntPtr)pDelays;

    //         calculateDelegate(ref handle, listener, emitter, flags, new IntPtr(&settingsNative));
    //     }

    //     settings.__MarshalFrom(ref settingsNative);
    // }


    // public unsafe static void CreateSourceVoice( IXAudio2SourceVoice* sourcevoice,WAVEFORMATEX sourceformat, uint Flags = 0,  float MaxFrequencyRatio = 1.0f, IXAudio2VoiceCallback* pCallback = null, XAUDIO2_VOICE_SENDS* pSendList = null, XAUDIO2_EFFECT_CHAIN* pEffectChain = null)
    // {
    //     // XAUDIO2_VOICE_SENDS* send =pSendList;
    //     // Instance.CreateSourceVoice( ref sourcevoice ,sourceformat, 0,MaxFrequencyRatio,null, send,null);
    // }

    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    // // [MethodImpl(MethodImplOptions.AggressiveInlining| MethodImplOptions.AggressiveOptimization )]
    // public unsafe static void CreateEmitter()
    // {

    // }

    // public unsafe static void AttachBufferToEmitter( )
    // {

    // }

    // public unsafe static void CreateOneEmitterWithMultipleBufferOrMultipleEmitterWithOneBuffer()
    // {

    // }

    public unsafe static uint CreateSource2D()
    {
        // AudioDeviceData* data  , SoundsDataWin64* sounds, string filename
        // // Log.Info("Init Source Win32");
        // sounds->SoundData = data->Memorysystem->PoolSystem->Add<WavSoundData>();

        // // ResultSound.re
        // // var context = audiodevice.GetData();
        // //  DECODE WAV 
        // WavSound wav = new( filename, sounds->SoundData ,  sounds->MemorySoundBuffer );

        // WAVEFORMATEX wfx = new()
        // {
        //     cbSize = 0,//no extra info
        //     nChannels =2,//  sounds->SoundData->Nbrcanaux, // 1;//2 = stereo
        //     nSamplesPerSec = 44100,// sounds->SoundData->Frequence, // 44100;
        //     wBitsPerSample = 16,// sounds->SoundData->BitsPerSample,//16; //8 or 24 or 32
        //     nBlockAlign = 4,// sounds->SoundData->BytePerBloc,
        //     nAvgBytesPerSec =  176400,//sounds->SoundData->BytePerSec,// wfx.nBlockAlign * wfx.nSamplesPerSec;
        //     wFormatTag = 1 ,//sounds->SoundData->AudioFormat// (ushort)wav.AudioFormat;// 3;//WAVE_FORMAT_PCM;? see list ?
        // };

        // IXAudio2SourceVoice* sourcevoice = null;

        // uint err = data->Instance->CreateSourceVoice( &sourcevoice , &wfx );

        // sounds->Sourcevoice = data->MemoryPool->Add( new IXAudio2SourceVoice(sourcevoice));

        // // Log.Info ($"Create Source voice Error Code : {err} adr : 0X{(long)sounds->Sourcevoice:X}");

        // // byte[] Data =new byte[ wav.Data.DataSize];
        // // wav.ReadChunk(ref Data,  wav.Data.DataSize);
        // // wav.ReadData(sounds->SoundData,  sounds->MemorySoundBuffer) 

        // var bytes = System.IO.File.ReadAllBytes( filename) ;
        // sounds->SoundData->Data =  sounds->MemorySoundBuffer->Add(sounds->SoundData->Data ,(uint)bytes.Length);
        // // var bytesSnd = new byte[data->DataSize ];
        // // data->Data = Mem.New<byte>(data->DataSize , sizeof(byte) , true);
        // for (int i = 0; i < bytes.Length ; i++)
        // {
        //    sounds->SoundData->Data[i] = bytes[i];
        //     // bytesSnd[i] = data->Data[i] ;
        // }

        // //CREATE BUFFER AND SATTACH TO SOURC
        // XAUDIO2_BUFFER Buffer = new()
        // {
        //     AudioBytes =(uint)bytes.Length,// sounds->SoundData->DataSize,
        //     Flags = XAUDIO2.XAUDIO2_END_OF_STREAM,
        //     pAudioData = sounds->SoundData->Data
        //     // LoopBegin =1 ,
        //     // LoopLength =0,
        //     // LoopCount =XAUDIO2_LOOP_INFINITE,
        //     // pContext = null,
        // };

        // err = sounds->Sourcevoice->SubmitSourceBuffer(&Buffer);
        // // Log.Info ($"Submit source buffer  Error Code : {err} "); 

        // wav.Dispose();
        // return 0;  
        // RitaEngine.Framework.Audio.Sounds.BasicWav wav = new(filename!);
        // wav.ReadHeader();
        // //use own readfile wav ?
        // uint wavSizeInBytes = wav.Data.DataSize;
        // byte[] rawDataInBytes =new byte[wavSizeInBytes];
        // wav.ReadChunk(ref rawDataInBytes, wavSizeInBytes);

        // // CREATE EMITTER / SOURCE 
        // WAVEFORMATEX wfx = new();
        // wfx.cbSize =0;//no extra info
        // wfx.nChannels = (ushort)wav.Data.Nbrcanaux; // 1;//2 = stereo
        // wfx.nSamplesPerSec = wav.Data.Frequence; // 44100;
        // wfx.wBitsPerSample =(ushort)wav.Data.BitsPerSample;//16; //8 or 24 or 32
        // wfx.nBlockAlign = (ushort)wav.Data.BytePerBloc;
        // wfx.nAvgBytesPerSec = wav.Data.BytePerSec;// wfx.nBlockAlign * wfx.nSamplesPerSec;
        // wfx.wFormatTag =(ushort)wav.Data.AudioFormat ;// (ushort)wav.AudioFormat;// 3;//WAVE_FORMAT_PCM;? see list ?
        // // Log.Info(wav.ToString());

        // IXAudio2SourceVoice* sourcevoice = null;
        // uint err = data->Instance->CreateSourceVoice(  &sourcevoice , &wfx);
        // // Log.Info ($"Create Source voice wtih :{filename} Error Code : {err} adr : {new IntPtr((void*)((Xaudio.IXAudio2SourceVoice*)&sourcevoice)):X}");

        // // CREATE BUFFER 
        // XAUDIO2_BUFFER buffer = new()
        // {
        //     AudioBytes = wavSizeInBytes,
        //     Flags = XAUDIO2.XAUDIO2_END_OF_STREAM
        // };
        // fixed ( byte* bytes = &rawDataInBytes[0] ){ 
        //     buffer.pAudioData = bytes; 
        // }   

        // // ATTACH BUFFER TO SOURCE 
        // err = sourcevoice->SubmitSourceBuffer(&buffer);
        // // Log.Info ($"Submit source buffer  Error Code : {err} ");

        // // PLAY SOURCE  ' MONO 
        // err = sourcevoice->Start();
        // // Log.Info ($"Start sound  Error Code : {err} ");

        return 0;

    }
    // public static void PlaySource(uint source, SoundsDataWin64* sounds)=> sounds->Sourcevoice->Start();
    // public static void StopSource(uint source, SoundsDataWin64* sounds)=> sounds->Sourcevoice->Stop(); //sounds->Sourcevoice[source ]->Stop();

    // 	return true;
    // }

    static nint GetAudioModuleDLL()
    {
        var AudioModule = WindowsLibrary.Load(LibrariesName.XAudio2_9);

        if (AudioModule != nint.Zero) { return AudioModule; }

        AudioModule = WindowsLibrary.Load(LibrariesName.XAudio2_8);

        if (AudioModule != nint.Zero) { return AudioModule; }

        AudioModule = WindowsLibrary.Load(LibrariesName.XAudio1_7);

        if (AudioModule != nint.Zero) { return AudioModule; }

        return nint.Zero;
    }
    
     // TODO replace System.MAth by own method  ( Log10 , Sin POw ASin )
    public static float XAudio2DecibelsToAmplitudeRatio(float Decibels)
        => MathNative.powf(10.0f, Decibels / 20.0f);

    /// <summary>
    /// // Inline function that converts an amplitude ratio value to a decibel value.
    /// </summary>
    /// <param name="Volume"></param>
    /// <returns></returns>
    public static float XAudio2AmplitudeRatioToDecibels(float Volume)
        => Volume == 0.0f ? -3.402823466e+38f : 20.0f * MathNative.clog10f(Volume);

    public static float XAudio2SemitonesToFrequencyRatio(float Semitones)
        => MathNative.powf(2.0f, Semitones / 12.0f);

    public static float XAudio2FrequencyRatioToSemitones(float FrequencyRatio)
        => 39.86313713864835f * MathNative.clog10f(FrequencyRatio);

    public static float XAudio2CutoffFrequencyToRadians(float CutoffFrequency, uint SampleRate)
        => (uint)(CutoffFrequency * 6.0f) >= SampleRate ? 1.0f : 2.0f * MathNative.sinf((float)3.14159265358979323846 * CutoffFrequency / SampleRate);

    public static float XAudio2RadiansToCutoffFrequency(float Radians, float SampleRate)
        => SampleRate * MathNative.asinf(Radians / 2.0f) / (float)3.14159265358979323846;

    public static float XAudio2CutoffFrequencyToOnePoleCoefficient(float CutoffFrequency, uint SampleRate)
        => (uint)CutoffFrequency >= SampleRate ? 1.0f : 1.0f - MathNative.powf(1.0f - (2.0f * CutoffFrequency / SampleRate), 2.0f);


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

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class AudioConsts
{
    internal const int Processor1 = 0x00000001;
    internal const int Processor2 = 0x00000002;
    internal const int Processor3 = 0x00000004;
    internal const int Processor4 = 0x00000008;
    internal const int Processor5 = 0x00000010;
    internal const int Processor6 = 0x00000020;
    internal const int Processor7 = 0x00000040;
    internal const int Processor8 = 0x00000080;
    internal const int Processor9 = 0x00000100;
    internal const int Processor10 = 0x00000200;
    internal const int Processor11 = 0x00000400;
    internal const int Processor12 = 0x00000800;
    internal const int Processor13 = 0x00001000;
    internal const int Processor14 = 0x00002000;
    internal const int Processor15 = 0x00004000;
    internal const int Processor16 = 0x00008000;
    internal const int Processor17 = 0x00010000;
    internal const int Processor18 = 0x00020000;
    internal const int Processor19 = 0x00040000;
    internal const int Processor20 = 0x00080000;
    internal const int Processor21 = 0x00100000;
    internal const int Processor22 = 0x00200000;
    internal const int Processor23 = 0x00400000;
    internal const int Processor24 = 0x00800000;
    internal const int Processor25 = 0x01000000;
    internal const int Processor26 = 0x02000000;
    internal const int Processor27 = 0x04000000;
    internal const int Processor28 = 0x08000000;
    internal const int Processor29 = 0x10000000;
    internal const int Processor30 = 0x20000000;
    internal const int Processor31 = 0x40000000;
    internal const uint Processor32 = 0x80000000;

    internal const int FACILITY_XAUDIO2 = 0x896;
    internal const uint XAUDIO2_MAX_BUFFER_BYTES = 0x80000000;
    internal const int XAUDIO2_MAX_QUEUED_BUFFERS = 64;
    internal const int XAUDIO2_MAX_BUFFERS_SYSTEM = 2;
    internal const int XAUDIO2_MAX_AUDIO_CHANNELS = 64;
    internal const int XAUDIO2_MIN_SAMPLE_RATE = 1000;
    internal const int XAUDIO2_MAX_SAMPLE_RATE = 200000;
    internal const float XAUDIO2_MAX_VOLUME_LEVEL = 16777216.0f;
    internal const float XAUDIO2_MIN_FREQ_RATIO = (1 / 1024.0f);
    internal const float XAUDIO2_MAX_FREQ_RATIO = 1024.0f;
    internal const float XAUDIO2_DEFAULT_FREQ_RATIO = 2.0f;
    internal const float XAUDIO2_MAX_FILTER_ONEOVERQ = 1.5f;
    internal const float XAUDIO2_MAX_FILTER_FREQUENCY = 1.0f;
    internal const int XAUDIO2_MAX_LOOP_COUNT = 254;
    internal const int XAUDIO2_MAX_INSTANCES = 8;
    internal const int XAUDIO2_MAX_RATIO_TIMES_RATE_XMA_MONO = 600000;
    internal const int XAUDIO2_MAX_RATIO_TIMES_RATE_XMA_MULTICHANNEL = 300000;
    internal const int XAUDIO2_COMMIT_NOW = 0;
    internal const int XAUDIO2_COMMIT_ALL = 0;
    internal const uint XAUDIO2_INVALID_OPSET = unchecked((uint)(-1));
    internal const int XAUDIO2_NO_LOOP_REGION = 0;
    internal const int XAUDIO2_LOOP_INFINITE = 255;
    internal const int XAUDIO2_DEFAULT_CHANNELS = 0;
    internal const int XAUDIO2_DEFAULT_SAMPLERATE = 0;
    internal const int XAUDIO2_DEBUG_ENGINE = 0x0001;
    internal const int XAUDIO2_VOICE_NOPITCH = 0x0002;
    internal const int XAUDIO2_VOICE_NOSRC = 0x0004;
    internal const int XAUDIO2_VOICE_USEFILTER = 0x0008;
    internal const int XAUDIO2_PLAY_TAILS = 0x0020;
    internal const int XAUDIO2_END_OF_STREAM = 0x0040;
    internal const int XAUDIO2_SEND_USEFILTER = 0x0080;
    internal const int XAUDIO2_VOICE_NOSAMPLESPLAYED = 0x0100;
    internal const int XAUDIO2_STOP_ENGINE_WHEN_IDLE = 0x2000;
    internal const int XAUDIO2_1024_QUANTUM = 0x8000;
    internal const int XAUDIO2_NO_VIRTUAL_AUDIO_CLIENT = 0x10000;
    internal const XAUDIO2_FILTER_TYPE XAUDIO2_DEFAULT_FILTER_TYPE = XAUDIO2_FILTER_TYPE.LowPassFilter;
    internal const float XAUDIO2_DEFAULT_FILTER_FREQUENCY = 1.0f;
    internal const float XAUDIO2_DEFAULT_FILTER_ONEOVERQ = 1.0f;
    internal const int XAUDIO2_QUANTUM_NUMERATOR = 1;
    internal const int XAUDIO2_QUANTUM_DENOMINATOR = 100;
    internal const float XAUDIO2_QUANTUM_MS = 1000.0f * 1 / 100;
    internal const int XAUDIO2_E_INVALID_CALL = unchecked((int)0x88960001);
    internal const int XAUDIO2_E_XMA_DECODER_ERROR = unchecked((int)0x88960002);
    internal const int XAUDIO2_E_XAPO_CREATION_FAILED = unchecked((int)0x88960003);
    internal const int XAUDIO2_E_DEVICE_INVALIDATED = unchecked((int)0x88960004);
    internal const uint XAUDIO2_ANY_PROCESSOR = 0xffffffff;
    internal const int XAUDIO2_USE_DEFAULT_PROCESSOR = 0x00000000;
    internal const int XAUDIO2_DEFAULT_PROCESSOR = 0x00000001;

    internal const int XAUDIO2_LOG_ERRORS = 0x0001;
    internal const int XAUDIO2_LOG_WARNINGS = 0x0002;
    internal const int XAUDIO2_LOG_INFO = 0x0004;
    internal const int XAUDIO2_LOG_DETAIL = 0x0008;
    internal const int XAUDIO2_LOG_API_CALLS = 0x0010;
    internal const int XAUDIO2_LOG_FUNC_CALLS = 0x0020;
    internal const int XAUDIO2_LOG_TIMING = 0x0040;
    internal const int XAUDIO2_LOG_LOCKS = 0x0080;
    internal const int XAUDIO2_LOG_MEMORY = 0x0100;
    internal const int XAUDIO2_LOG_STREAMING = 0x1000;

    internal const uint XAUDIO2_SUCESS = 0;
    // internal const uint XAUDIO2_E_INVALID_CALL = 0x88960001;
    // internal const uint XAUDIO2_E_XMA_DECODER_ERROR = 0x88960002;
    // internal const uint XAUDIO2_E_XAPO_CREATION_FAILED = 0x88960003;
    // internal const uint XAUDIO2_E_DEVICE_INVALIDATED = 0x88960004;
    public const uint AUDIO_STREAM_CATEGORY_GameEffects = 6;
    //AudioCategory_Other = 0,
    //     AudioCategory_ForegroundOnlyMedia = 1,
    //     AudioCategory_Communications = 3,
    //     AudioCategory_Alerts = 4,
    //     AudioCategory_SoundEffects = 5,
    //     AudioCategory_GameEffects = 6,
    //     AudioCategory_GameMedia = 7,
    //     AudioCategory_GameChat = 8,
    //     AudioCategory_Speech = 9,
    //     AudioCategory_Movie = 10,
    //     AudioCategory_Media = 11,
}

internal enum XAUDIO2_FILTER_TYPE
{
    LowPassFilter,                      // Attenuates frequencies above the cutoff frequency (state-variable filter).
    BandPassFilter,                     // Attenuates frequencies outside a given range      (state-variable filter).
    HighPassFilter,                     // Attenuates frequencies below the cutoff frequency (state-variable filter).
    NotchFilter,                        // Attenuates frequencies inside a given range       (state-variable filter).
    LowPassOnePoleFilter,               // Attenuates frequencies above the cutoff frequency (one-pole filter, XAUDIO2_FILTER_PARAMETERS.OneOverQ has no effect)
    HighPassOnePoleFilter               // Attenuates frequencies below the cutoff frequency (one-pole filter, XAUDIO2_FILTER_PARAMETERS.OneOverQ has no effect)
}

#region COMMON 


[StructLayout(LayoutKind.Sequential)]
internal unsafe struct GUID
{
    internal ulong Data1;
    internal ushort Data2;
    internal ushort Data3;
    internal fixed byte Data4[8];

    internal GUID(ulong d1, ushort d2, ushort d3, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8)
    {
        Data1 = d1;
        Data2 = d2;
        Data3 = d3;
        Data4[0] = b1;
        Data4[1] = b2;
        Data4[2] = b3;
        Data4[3] = b4;
        Data4[4] = b5;
        Data4[5] = b6;
        Data4[6] = b7;
        Data4[7] = b8;
    }
};

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct WAVEFORMATEX
{
    internal WORD wFormatTag;
    internal WORD nChannels;
    internal DWORD nSamplesPerSec;
    internal DWORD nAvgBytesPerSec;
    internal WORD nBlockAlign;
    internal WORD wBitsPerSample;
    internal WORD cbSize;
}
#endregion


#region XAUDIO

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal  unsafe struct IXAudio2EngineCallback(IXAudio2EngineCallback* pointer)
{
    internal  void OnProcessingPassStart() => onProcessingPassStart(lpVtbl);
    internal  void OnProcessingPassEnd() => onProcessingPassEnd(lpVtbl);
    internal  void OnCriticalError(HRESULT Error) => onCriticalError(lpVtbl, Error);

    IXAudio2EngineCallback* lpVtbl = pointer;
    delegate* unmanaged<IXAudio2EngineCallback*, void> onProcessingPassStart = (delegate* unmanaged<IXAudio2EngineCallback*, void>)((void**)*(void**)pointer)[0];
    delegate* unmanaged<IXAudio2EngineCallback*, void> onProcessingPassEnd = (delegate* unmanaged<IXAudio2EngineCallback*, void>)((void**)*(void**)pointer)[1];
    delegate* unmanaged<IXAudio2EngineCallback*, HRESULT, void> onCriticalError = (delegate* unmanaged<IXAudio2EngineCallback*, HRESULT, void>)((void**)*(void**)pointer)[2];
}

[StructLayout(LayoutKind.Sequential,Pack =1)] //[Guid("2B02E3CF-2E0B-4EC3-BE45-1B2A3FE7210D")]
internal  unsafe struct IXAudio2(IXAudio2* pointer)
{
    // internal static  GUID IID_IXAudio2 = new(0x2B02E3CF, 0x2E0B, 0x4ec3, 0xBE, 0x45, 0x1B, 0x2A, 0x3F, 0xE7, 0x21, 0x0D);

    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT Release() => release(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT RegisterForCallbacks(IXAudio2EngineCallback* pCallback) => registerForCallbacks(lpVtbl, pCallback);
[SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal void UnregisterForCallbacks(IXAudio2EngineCallback* pCallback) => unregisterForCallbacks(lpVtbl, pCallback);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal HRESULT CreateSourceVoice(IXAudio2SourceVoice** ppSourceVoice, WAVEFORMATEX* pSourceFormat, uint SoundEfectFlags = 0, float MaxFrequencyRatio = AudioConsts.XAUDIO2_DEFAULT_FREQ_RATIO, IXAudio2VoiceCallback* pCallback = null, XAUDIO2_VOICE_SENDS* pSendList = null, XAUDIO2_EFFECT_CHAIN* pEffectChain = null)
    => createSourceVoice(lpVtbl, ppSourceVoice, pSourceFormat, SoundEfectFlags, MaxFrequencyRatio, pCallback, pSendList, pEffectChain);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal HRESULT CreateSubmixVoice(IXAudio2SubmixVoice** ppSubmixVoice, uint InputChannels, uint InputSampleRate, uint Flags = 0, uint ProcessingStage = 0, XAUDIO2_VOICE_SENDS* pSendList = null, XAUDIO2_EFFECT_CHAIN* pEffectChain = null)
        => createSubmixVoice(lpVtbl, ppSubmixVoice, InputChannels, InputSampleRate, Flags, ProcessingStage, pSendList, pEffectChain);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal HRESULT CreateMasteringVoice(IXAudio2MasteringVoice** ppMasteringVoice, uint InputChannels = 0, uint InputSampleRate = 0, uint Flags = 0, char* szDeviceId = null, XAUDIO2_EFFECT_CHAIN* pEffectChain = null, uint StreamCategory =7)
        => createMasteringVoice(lpVtbl, ppMasteringVoice, InputChannels, InputSampleRate, Flags, szDeviceId, pEffectChain, StreamCategory);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal HRESULT StartEngine() => startEngine(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal void StopEngine() => stopEngine(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal HRESULT CommitChanges(uint OperationSet)
        => commitChanges(lpVtbl, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal void GetPerformanceData(XAUDIO2_PERFORMANCE_DATA* pPerfData)
        => getPerformanceData(lpVtbl, pPerfData);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal void SetDebugConfiguration(XAUDIO2_DEBUG_CONFIGURATION* pDebugConfiguration, void* pReserved = null)
        => setDebugConfiguration(lpVtbl, pDebugConfiguration, pReserved);

  
     IXAudio2* lpVtbl = pointer;
     delegate* unmanaged<IXAudio2*, GUID*, void**, int> queryInterface = (delegate* unmanaged<IXAudio2*, GUID*, void**, int>)((void**)*(void**)pointer)[0];
     delegate* unmanaged<IXAudio2*, uint> addRef = (delegate* unmanaged<IXAudio2*, uint>)((void**)*(void**)pointer)[1];
     delegate* unmanaged<IXAudio2*, HRESULT> release = (delegate* unmanaged<IXAudio2*, HRESULT>)((void**)*(void**)pointer)[2];
     delegate* unmanaged<IXAudio2*, IXAudio2EngineCallback*, HRESULT> registerForCallbacks = (delegate* unmanaged<IXAudio2*, IXAudio2EngineCallback*, HRESULT>)((void**)*(void**)pointer)[3];
     delegate* unmanaged<IXAudio2*, IXAudio2EngineCallback*, void> unregisterForCallbacks = (delegate* unmanaged<IXAudio2*, IXAudio2EngineCallback*, void>)((void**)*(void**)pointer)[4];
     delegate* unmanaged<IXAudio2*, IXAudio2SourceVoice**, WAVEFORMATEX*, uint, float, IXAudio2VoiceCallback*, XAUDIO2_VOICE_SENDS*, XAUDIO2_EFFECT_CHAIN*, HRESULT> createSourceVoice = (delegate* unmanaged<IXAudio2*, IXAudio2SourceVoice**, WAVEFORMATEX*, uint, float, IXAudio2VoiceCallback*, XAUDIO2_VOICE_SENDS*, XAUDIO2_EFFECT_CHAIN*, HRESULT>)((void**)*(void**)pointer)[5];
     delegate* unmanaged<IXAudio2*, IXAudio2SubmixVoice**, uint, uint, uint, uint, XAUDIO2_VOICE_SENDS*, XAUDIO2_EFFECT_CHAIN*, HRESULT> createSubmixVoice = (delegate* unmanaged<IXAudio2*, IXAudio2SubmixVoice**, uint, uint, uint, uint, XAUDIO2_VOICE_SENDS*, XAUDIO2_EFFECT_CHAIN*, HRESULT>)((void**)*(void**)pointer)[6];
     delegate* unmanaged<IXAudio2*, IXAudio2MasteringVoice**, uint, uint, uint, char*, XAUDIO2_EFFECT_CHAIN*, uint, HRESULT> createMasteringVoice = (delegate* unmanaged<IXAudio2*, IXAudio2MasteringVoice**, uint, uint, uint, char*, XAUDIO2_EFFECT_CHAIN*, uint, HRESULT>)((void**)*(void**)pointer)[7];
     delegate* unmanaged<IXAudio2*, HRESULT> startEngine = (delegate* unmanaged<IXAudio2*, HRESULT>)((void**)*(void**)pointer)[8];
     delegate* unmanaged<IXAudio2*, void> stopEngine = (delegate* unmanaged<IXAudio2*, void>)((void**)*(void**)pointer)[9];
     delegate* unmanaged<IXAudio2*, uint, HRESULT> commitChanges = (delegate* unmanaged<IXAudio2*, uint, HRESULT>)((void**)*(void**)pointer)[10];
     delegate* unmanaged<IXAudio2*, XAUDIO2_PERFORMANCE_DATA*, void> getPerformanceData = (delegate* unmanaged<IXAudio2*, XAUDIO2_PERFORMANCE_DATA*, void>)((void**)*(void**)pointer)[11];
     delegate* unmanaged<IXAudio2*, XAUDIO2_DEBUG_CONFIGURATION*, void*, void> setDebugConfiguration = (delegate* unmanaged<IXAudio2*, XAUDIO2_DEBUG_CONFIGURATION*, void*, void>)((void**)*(void**)pointer)[12];
}

// [StructLayout(LayoutKind.Sequential,Pack =1)] //84AC29BB-D619-44D2-B197-E4ACF7DF3ED6
// internal  unsafe struct IXAudio2Extension(IXAudio2Extension* pointer)
// {
//     internal static  GUID IID_IXAudio2 = new(0x84AC29BB, 0xD619, 0x44D2, 0xB1, 0x97, 0xE4, 0xAC, 0xF7, 0xDF, 0x3E, 0xD6);

//     [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
//     internal  HRESULT QueryInterface(GUID* riid, void** ppvObject) => queryInterface(lpVtbl, riid, ppvObject);
//     [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
//     internal  uint AddRef() => addRef(lpVtbl);
//     [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
//     internal uint Release() => release(lpVtbl);
//     [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
//     internal  void GetProcessingQuantum(uint* quantumNumerator, uint* quantumDenominator) => getProcessingQuantum(lpVtbl, quantumNumerator, quantumDenominator);
//     [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
//     internal  void GetProcessor(uint* processor) => getProcessor(lpVtbl, processor);

//      IXAudio2Extension* lpVtbl;
//      delegate* unmanaged<IXAudio2Extension*, GUID*, void**, HRESULT> queryInterface = (delegate* unmanaged<IXAudio2Extension*, GUID*, void**, HRESULT>)((void**)*(void**)pointer)[0];
//      delegate* unmanaged<IXAudio2Extension*, uint> addRef = (delegate* unmanaged<IXAudio2Extension*, uint>)((void**)*(void**)pointer)[1];
//      delegate* unmanaged<IXAudio2Extension*, uint> release = (delegate* unmanaged<IXAudio2Extension*, uint>)((void**)*(void**)pointer)[2];
//      delegate* unmanaged<IXAudio2Extension*, uint*, uint*, void> getProcessingQuantum = (delegate* unmanaged<IXAudio2Extension*, uint*, uint*, void>)((void**)*(void**)pointer)[3];
//      delegate* unmanaged<IXAudio2Extension*, uint*, void> getProcessor = (delegate* unmanaged<IXAudio2Extension*, uint*, void>)((void**)*(void**)pointer)[4];
// }

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal  unsafe struct IXAudio2MasteringVoice(IXAudio2MasteringVoice* pointer)
{
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVoiceDetails(XAUDIO2_VOICE_DETAILS* pVoiceDetails) => getVoiceDetails(lpVtbl, pVoiceDetails);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputVoices(XAUDIO2_VOICE_SENDS* pSendList) => setOutputVoices(lpVtbl, pSendList);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectChain(XAUDIO2_EFFECT_CHAIN* pEffectChain) => setEffectChain(lpVtbl, pEffectChain);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT EnableEffect(uint EffectIndex, uint OperationSet = 0) => enableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT DisableEffect(uint EffectIndex, uint OperationSet = 0) => disableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetEffectState(uint EffectIndex, BOOL* pEnabled) => getEffectState(lpVtbl, EffectIndex, pEnabled);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize, uint OperationSet = 0)
        => setEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT GetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize)
        => getEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0) => setFilterParameters(lpVtbl, pParameters, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters) => getFilterParameters(lpVtbl, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0)
        => setOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters)
        => getOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetVolume(float Volume, uint OperationSet = 0) => setVolume(lpVtbl, Volume, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVolume(float* pVolume) => getVolume(lpVtbl, pVolume);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetChannelVolumes(uint Channels, float* pVolumes, uint OperationSet = 0) => setChannelVolumes(lpVtbl, Channels, pVolumes, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetChannelVolumes(uint Channels, float* pVolumes) => getChannelVolumes(lpVtbl, Channels, pVolumes);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix, uint OperationSet = 0)
        => setOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix)
        => getOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void DestroyVoice() => destroyVoice(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT GetChannelMask(uint* pChannelmask) => getChannelMask(lpVtbl, pChannelmask);

     IXAudio2MasteringVoice* lpVtbl = pointer;
     delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_VOICE_DETAILS*, void> getVoiceDetails = (delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_VOICE_DETAILS*, void>)((void**)*(void**)pointer)[0];
     delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_VOICE_SENDS*, HRESULT> setOutputVoices = (delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_VOICE_SENDS*, HRESULT>)((void**)*(void**)pointer)[1];
     delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_EFFECT_CHAIN*, HRESULT> setEffectChain = (delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_EFFECT_CHAIN*, HRESULT>)((void**)*(void**)pointer)[2];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint, uint, HRESULT> enableEffect = (delegate* unmanaged<IXAudio2MasteringVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[3];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint, uint, HRESULT> disableEffect = (delegate* unmanaged<IXAudio2MasteringVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[4];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint, BOOL*, void> getEffectState = (delegate* unmanaged<IXAudio2MasteringVoice*, uint, BOOL*, void>)((void**)*(void**)pointer)[5];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint, void*, uint, uint, HRESULT> setEffectParameters = (delegate* unmanaged<IXAudio2MasteringVoice*, uint, void*, uint, uint, HRESULT>)((void**)*(void**)pointer)[6];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint, void*, uint, HRESULT> getEffectParameters = (delegate* unmanaged<IXAudio2MasteringVoice*, uint, void*, uint, HRESULT>)((void**)*(void**)pointer)[7];
     delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setFilterParameters = (delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[8];
     delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_FILTER_PARAMETERS*, void> getFilterParameters = (delegate* unmanaged<IXAudio2MasteringVoice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[9];
     delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setOutputFilterParameters = (delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[10];
     delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void> getOutputFilterParameters = (delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[11];
     delegate* unmanaged<IXAudio2MasteringVoice*, float, uint, HRESULT> setVolume = (delegate* unmanaged<IXAudio2MasteringVoice*, float, uint, HRESULT>)((void**)*(void**)pointer)[12];
     delegate* unmanaged<IXAudio2MasteringVoice*, float*, void> getVolume = (delegate* unmanaged<IXAudio2MasteringVoice*, float*, void>)((void**)*(void**)pointer)[13];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint, float*, uint, HRESULT> setChannelVolumes = (delegate* unmanaged<IXAudio2MasteringVoice*, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[14];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint, float*, void> getChannelVolumes = (delegate* unmanaged<IXAudio2MasteringVoice*, uint, float*, void>)((void**)*(void**)pointer)[15];
     delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT> setOutputMatrix = (delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[16];
     delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, uint, uint, float*, void> getOutputMatrix = (delegate* unmanaged<IXAudio2MasteringVoice*, IXAudio2Voice*, uint, uint, float*, void>)((void**)*(void**)pointer)[17];
     delegate* unmanaged<IXAudio2MasteringVoice*, void> destroyVoice = (delegate* unmanaged<IXAudio2MasteringVoice*, void>)((void**)*(void**)pointer)[18];
     delegate* unmanaged<IXAudio2MasteringVoice*, uint*, HRESULT> getChannelMask = (delegate* unmanaged<IXAudio2MasteringVoice*, uint*, HRESULT>)((void**)*(void**)pointer)[19];
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal  unsafe struct IXAudio2SourceVoice(IXAudio2SourceVoice* pointer)
{
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVoiceDetails(XAUDIO2_VOICE_DETAILS* pVoiceDetails) => getVoiceDetails(lpVtbl, pVoiceDetails);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputVoices(XAUDIO2_VOICE_SENDS* pSendList) => setOutputVoices(lpVtbl, pSendList);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectChain(XAUDIO2_EFFECT_CHAIN* pEffectChain) => setEffectChain(lpVtbl, pEffectChain);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT EnableEffect(uint EffectIndex, uint OperationSet = 0) => enableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT DisableEffect(uint EffectIndex, uint OperationSet = 0) => disableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetEffectState(uint EffectIndex, BOOL* pEnabled) => getEffectState(lpVtbl, EffectIndex, pEnabled);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize, uint OperationSet = 0) => setEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT GetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize) => getEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0) => setFilterParameters(lpVtbl, pParameters, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters) => getFilterParameters(lpVtbl, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0) => setOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters) => getOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetVolume(float Volume, uint OperationSet = 0) => setVolume(lpVtbl, Volume, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVolume(float* pVolume) => getVolume(lpVtbl, pVolume);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetChannelVolumes(uint Channels, float* pVolumes, uint OperationSet = 0) => setChannelVolumes(lpVtbl, Channels, pVolumes, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetChannelVolumes(uint Channels, float* pVolumes) => getChannelVolumes(lpVtbl, Channels, pVolumes);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix, uint OperationSet = 0) => setOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix) => getOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void DestroyVoice() => destroyVoice(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT Start(uint Flags = 0, uint OperationSet = 0) => start(lpVtbl, Flags, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT Stop(uint Flags = 0, uint OperationSet = 0) => stop(lpVtbl, Flags, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SubmitSourceBuffer(XAUDIO2_BUFFER* pBuffer, XAUDIO2_BUFFER_WMA* pBufferWMA = null) => submitSourceBuffer(lpVtbl, pBuffer, pBufferWMA);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT FlushSourceBuffers() => flushSourceBuffers(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT Discontinuity() => discontinuity(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT ExitLoop(uint OperationSet = 0) => exitLoop(lpVtbl, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetState(XAUDIO2_VOICE_STATE* pVoiceState, uint Flags = 0) => getState(lpVtbl, pVoiceState, Flags);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetFrequencyRatio(float Ratio, uint OperationSet = 0) => setFrequencyRatio(lpVtbl, Ratio, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetFrequencyRatio(float* pRatio) => getFrequencyRatio(lpVtbl, pRatio);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetSourceSampleRate(uint NewSourceSampleRate) => setSourceSampleRate(lpVtbl, NewSourceSampleRate);

     IXAudio2SourceVoice* lpVtbl = pointer;
     delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_VOICE_DETAILS*, void> getVoiceDetails = (delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_VOICE_DETAILS*, void>)((void**)*(void**)pointer)[0];
     delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_VOICE_SENDS*, HRESULT> setOutputVoices = (delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_VOICE_SENDS*, HRESULT>)((void**)*(void**)pointer)[1];
     delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_EFFECT_CHAIN*, HRESULT> setEffectChain = (delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_EFFECT_CHAIN*, HRESULT>)((void**)*(void**)pointer)[2];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT> enableEffect = (delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[3];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT> disableEffect = (delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[4];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, BOOL*, void> getEffectState = (delegate* unmanaged<IXAudio2SourceVoice*, uint, BOOL*, void>)((void**)*(void**)pointer)[5];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, void*, uint, uint, HRESULT> setEffectParameters = (delegate* unmanaged<IXAudio2SourceVoice*, uint, void*, uint, uint, HRESULT>)((void**)*(void**)pointer)[6];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, void*, uint, HRESULT> getEffectParameters = (delegate* unmanaged<IXAudio2SourceVoice*, uint, void*, uint, HRESULT>)((void**)*(void**)pointer)[7];
     delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setFilterParameters = (delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[8];
     delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_FILTER_PARAMETERS*, void> getFilterParameters = (delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[9];
     delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setOutputFilterParameters = (delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[10];
     delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void> getOutputFilterParameters = (delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[11];
     delegate* unmanaged<IXAudio2SourceVoice*, float, uint, HRESULT> setVolume = (delegate* unmanaged<IXAudio2SourceVoice*, float, uint, HRESULT>)((void**)*(void**)pointer)[12];
     delegate* unmanaged<IXAudio2SourceVoice*, float*, void> getVolume = (delegate* unmanaged<IXAudio2SourceVoice*, float*, void>)((void**)*(void**)pointer)[13];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, float*, uint, HRESULT> setChannelVolumes = (delegate* unmanaged<IXAudio2SourceVoice*, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[14];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, float*, void> getChannelVolumes = (delegate* unmanaged<IXAudio2SourceVoice*, uint, float*, void>)((void**)*(void**)pointer)[15];
     delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT> setOutputMatrix = (delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[16];
     delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, uint, uint, float*, void> getOutputMatrix = (delegate* unmanaged<IXAudio2SourceVoice*, IXAudio2Voice*, uint, uint, float*, void>)((void**)*(void**)pointer)[17];
     delegate* unmanaged<IXAudio2SourceVoice*, void> destroyVoice = (delegate* unmanaged<IXAudio2SourceVoice*, void>)((void**)*(void**)pointer)[18];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT> start = (delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[19];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT> stop = (delegate* unmanaged<IXAudio2SourceVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[20];
     delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_BUFFER*, XAUDIO2_BUFFER_WMA*, HRESULT> submitSourceBuffer = (delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_BUFFER*, XAUDIO2_BUFFER_WMA*, HRESULT>)((void**)*(void**)pointer)[21];
     delegate* unmanaged<IXAudio2SourceVoice*, HRESULT> flushSourceBuffers = (delegate* unmanaged<IXAudio2SourceVoice*, HRESULT>)((void**)*(void**)pointer)[22];
     delegate* unmanaged<IXAudio2SourceVoice*, HRESULT> discontinuity = (delegate* unmanaged<IXAudio2SourceVoice*, HRESULT>)((void**)*(void**)pointer)[23];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, HRESULT> exitLoop = (delegate* unmanaged<IXAudio2SourceVoice*, uint, HRESULT>)((void**)*(void**)pointer)[24];
     delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_VOICE_STATE*, uint, void> getState = (delegate* unmanaged<IXAudio2SourceVoice*, XAUDIO2_VOICE_STATE*, uint, void>)((void**)*(void**)pointer)[25];
     delegate* unmanaged<IXAudio2SourceVoice*, float, uint, HRESULT> setFrequencyRatio = (delegate* unmanaged<IXAudio2SourceVoice*, float, uint, HRESULT>)((void**)*(void**)pointer)[26];
     delegate* unmanaged<IXAudio2SourceVoice*, float*, void> getFrequencyRatio = (delegate* unmanaged<IXAudio2SourceVoice*, float*, void>)((void**)*(void**)pointer)[27];
     delegate* unmanaged<IXAudio2SourceVoice*, uint, HRESULT> setSourceSampleRate = (delegate* unmanaged<IXAudio2SourceVoice*, uint, HRESULT>)((void**)*(void**)pointer)[28];
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal  unsafe struct IXAudio2SubmixVoice(IXAudio2SubmixVoice* pointer)
{
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVoiceDetails(XAUDIO2_VOICE_DETAILS* pVoiceDetails) => getVoiceDetails(lpVtbl, pVoiceDetails);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputVoices(XAUDIO2_VOICE_SENDS* pSendList) => setOutputVoices(lpVtbl, pSendList);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectChain(XAUDIO2_EFFECT_CHAIN* pEffectChain) => setEffectChain(lpVtbl, pEffectChain);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT EnableEffect(uint EffectIndex, uint OperationSet = 0) => enableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT DisableEffect(uint EffectIndex, uint OperationSet = 0) => disableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetEffectState(uint EffectIndex, BOOL* pEnabled) => getEffectState(lpVtbl, EffectIndex, pEnabled);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize, uint OperationSet = 0) => setEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT GetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize) => getEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0) => setFilterParameters(lpVtbl, pParameters, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters) => getFilterParameters(lpVtbl, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0) => setOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters) => getOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetVolume(float Volume, uint OperationSet = 0) => setVolume(lpVtbl, Volume, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVolume(float* pVolume) => getVolume(lpVtbl, pVolume);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetChannelVolumes(uint Channels, float* pVolumes, uint OperationSet = 0) => setChannelVolumes(lpVtbl, Channels, pVolumes, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetChannelVolumes(uint Channels, float* pVolumes) => getChannelVolumes(lpVtbl, Channels, pVolumes);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix, uint OperationSet = 0) => setOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix) => getOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void DestroyVoice() => destroyVoice(lpVtbl);

     IXAudio2SubmixVoice* lpVtbl = pointer;
     delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_VOICE_DETAILS*, void> getVoiceDetails = (delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_VOICE_DETAILS*, void>)((void**)*(void**)pointer)[0];
     delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_VOICE_SENDS*, HRESULT> setOutputVoices = (delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_VOICE_SENDS*, HRESULT>)((void**)*(void**)pointer)[1];
     delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_EFFECT_CHAIN*, HRESULT> setEffectChain = (delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_EFFECT_CHAIN*, HRESULT>)((void**)*(void**)pointer)[2];
     delegate* unmanaged<IXAudio2SubmixVoice*, uint, uint, HRESULT> enableEffect = (delegate* unmanaged<IXAudio2SubmixVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[3];
     delegate* unmanaged<IXAudio2SubmixVoice*, uint, uint, HRESULT> disableEffect = (delegate* unmanaged<IXAudio2SubmixVoice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[4];
     delegate* unmanaged<IXAudio2SubmixVoice*, uint, BOOL*, void> getEffectState = (delegate* unmanaged<IXAudio2SubmixVoice*, uint, BOOL*, void>)((void**)*(void**)pointer)[5];
     delegate* unmanaged<IXAudio2SubmixVoice*, uint, void*, uint, uint, HRESULT> setEffectParameters = (delegate* unmanaged<IXAudio2SubmixVoice*, uint, void*, uint, uint, HRESULT>)((void**)*(void**)pointer)[6];
     delegate* unmanaged<IXAudio2SubmixVoice*, uint, void*, uint, HRESULT> getEffectParameters = (delegate* unmanaged<IXAudio2SubmixVoice*, uint, void*, uint, HRESULT>)((void**)*(void**)pointer)[7];
     delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setFilterParameters = (delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[8];
     delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_FILTER_PARAMETERS*, void> getFilterParameters = (delegate* unmanaged<IXAudio2SubmixVoice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[9];
     delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setOutputFilterParameters = (delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[10];
     delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void> getOutputFilterParameters = (delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[11];
     delegate* unmanaged<IXAudio2SubmixVoice*, float, uint, HRESULT> setVolume = (delegate* unmanaged<IXAudio2SubmixVoice*, float, uint, HRESULT>)((void**)*(void**)pointer)[12];
     delegate* unmanaged<IXAudio2SubmixVoice*, float*, void> getVolume = (delegate* unmanaged<IXAudio2SubmixVoice*, float*, void>)((void**)*(void**)pointer)[13];
     delegate* unmanaged<IXAudio2SubmixVoice*, uint, float*, uint, HRESULT> setChannelVolumes = (delegate* unmanaged<IXAudio2SubmixVoice*, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[14];
     delegate* unmanaged<IXAudio2SubmixVoice*, uint, float*, void> getChannelVolumes = (delegate* unmanaged<IXAudio2SubmixVoice*, uint, float*, void>)((void**)*(void**)pointer)[15];
     delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT> setOutputMatrix = (delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[16];
     delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, uint, uint, float*, void> getOutputMatrix = (delegate* unmanaged<IXAudio2SubmixVoice*, IXAudio2Voice*, uint, uint, float*, void>)((void**)*(void**)pointer)[17];
     delegate* unmanaged<IXAudio2SubmixVoice*, void> destroyVoice = (delegate* unmanaged<IXAudio2SubmixVoice*, void>)((void**)*(void**)pointer)[18];
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal  unsafe struct IXAudio2Voice(IXAudio2Voice* pointer)
{
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVoiceDetails(XAUDIO2_VOICE_DETAILS* pVoiceDetails) => getVoiceDetails(lpVtbl, pVoiceDetails);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputVoices(XAUDIO2_VOICE_SENDS* pSendList) => setOutputVoices(lpVtbl, pSendList);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectChain(XAUDIO2_EFFECT_CHAIN* pEffectChain) => setEffectChain(lpVtbl, pEffectChain);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT EnableEffect(uint EffectIndex, uint OperationSet = 0) => enableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT DisableEffect(uint EffectIndex, uint OperationSet = 0) => disableEffect(lpVtbl, EffectIndex, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetEffectState(uint EffectIndex, BOOL* pEnabled) => getEffectState(lpVtbl, EffectIndex, pEnabled);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize, uint OperationSet = 0) => setEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT GetEffectParameters(uint EffectIndex, void* pParameters, uint ParametersByteSize) => getEffectParameters(lpVtbl, EffectIndex, pParameters, ParametersByteSize);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0) => setFilterParameters(lpVtbl, pParameters, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters) => getFilterParameters(lpVtbl, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters, uint OperationSet = 0) => setOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters, OperationSet);
    internal  void GetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters) => getOutputFilterParameters(lpVtbl, pDestinationVoice, pParameters);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetVolume(float Volume, uint OperationSet = 0) => setVolume(lpVtbl, Volume, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetVolume(float* pVolume) => getVolume(lpVtbl, pVolume);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetChannelVolumes(uint Channels, float* pVolumes, uint OperationSet = 0) => setChannelVolumes(lpVtbl, Channels, pVolumes, OperationSet);
    internal  void GetChannelVolumes(uint Channels, float* pVolumes) => getChannelVolumes(lpVtbl, Channels, pVolumes);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  HRESULT SetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix, uint OperationSet = 0) => setOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix, OperationSet);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void GetOutputMatrix(IXAudio2Voice* pDestinationVoice, uint SourceChannels, uint DestinationChannels, float* pLevelMatrix) => getOutputMatrix(lpVtbl, pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void DestroyVoice() => destroyVoice(lpVtbl);

     IXAudio2Voice* lpVtbl = pointer;
     delegate* unmanaged<IXAudio2Voice*, XAUDIO2_VOICE_DETAILS*, void> getVoiceDetails = (delegate* unmanaged<IXAudio2Voice*, XAUDIO2_VOICE_DETAILS*, void>)((void**)*(void**)pointer)[0];
     delegate* unmanaged<IXAudio2Voice*, XAUDIO2_VOICE_SENDS*, HRESULT> setOutputVoices = (delegate* unmanaged<IXAudio2Voice*, XAUDIO2_VOICE_SENDS*, HRESULT>)((void**)*(void**)pointer)[1];
     delegate* unmanaged<IXAudio2Voice*, XAUDIO2_EFFECT_CHAIN*, HRESULT> setEffectChain = (delegate* unmanaged<IXAudio2Voice*, XAUDIO2_EFFECT_CHAIN*, HRESULT>)((void**)*(void**)pointer)[2];
     delegate* unmanaged<IXAudio2Voice*, uint, uint, HRESULT> enableEffect = (delegate* unmanaged<IXAudio2Voice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[3];
     delegate* unmanaged<IXAudio2Voice*, uint, uint, HRESULT> disableEffect = (delegate* unmanaged<IXAudio2Voice*, uint, uint, HRESULT>)((void**)*(void**)pointer)[4];
     delegate* unmanaged<IXAudio2Voice*, uint, BOOL*, void> getEffectState = (delegate* unmanaged<IXAudio2Voice*, uint, BOOL*, void>)((void**)*(void**)pointer)[5];
     delegate* unmanaged<IXAudio2Voice*, uint, void*, uint, uint, HRESULT> setEffectParameters = (delegate* unmanaged<IXAudio2Voice*, uint, void*, uint, uint, HRESULT>)((void**)*(void**)pointer)[6];
     delegate* unmanaged<IXAudio2Voice*, uint, void*, uint, HRESULT> getEffectParameters = (delegate* unmanaged<IXAudio2Voice*, uint, void*, uint, HRESULT>)((void**)*(void**)pointer)[7];
     delegate* unmanaged<IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setFilterParameters = (delegate* unmanaged<IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[8];
     delegate* unmanaged<IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void> getFilterParameters = (delegate* unmanaged<IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[9];
     delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT> setOutputFilterParameters = (delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, HRESULT>)((void**)*(void**)pointer)[10];
     delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void> getOutputFilterParameters = (delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void>)((void**)*(void**)pointer)[11];
     delegate* unmanaged<IXAudio2Voice*, float, uint, HRESULT> setVolume = (delegate* unmanaged<IXAudio2Voice*, float, uint, HRESULT>)((void**)*(void**)pointer)[12];
     delegate* unmanaged<IXAudio2Voice*, float*, void> getVolume = (delegate* unmanaged<IXAudio2Voice*, float*, void>)((void**)*(void**)pointer)[13];
     delegate* unmanaged<IXAudio2Voice*, uint, float*, uint, HRESULT> setChannelVolumes = (delegate* unmanaged<IXAudio2Voice*, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[14];
     delegate* unmanaged<IXAudio2Voice*, uint, float*, void> getChannelVolumes = (delegate* unmanaged<IXAudio2Voice*, uint, float*, void>)((void**)*(void**)pointer)[15];
     delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT> setOutputMatrix = (delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, uint, uint, float*, uint, HRESULT>)((void**)*(void**)pointer)[16];
     delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, uint, uint, float*, void> getOutputMatrix = (delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, uint, uint, float*, void>)((void**)*(void**)pointer)[17];
     delegate* unmanaged<IXAudio2Voice*, void> destroyVoice = (delegate* unmanaged<IXAudio2Voice*, void>)((void**)*(void**)pointer)[18];
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal  unsafe struct IXAudio2VoiceCallback(IXAudio2VoiceCallback* pointer)
{
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void OnVoiceProcessingPassStart(uint BytesRequired) => onVoiceProcessingPassStart(lpVtbl, BytesRequired);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void OnVoiceProcessingPassEnd() => onVoiceProcessingPassEnd(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void OnStreamEnd() => onStreamEnd(lpVtbl);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void OnBufferStart(void* pBufferContext) => onBufferStart(lpVtbl, pBufferContext);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void OnBufferEnd(void* pBufferContext) => onBufferEnd(lpVtbl, pBufferContext);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void OnLoopEnd(void* pBufferContext) => onLoopEnd(lpVtbl, pBufferContext);
    [SkipLocalsInit, SuppressUnmanagedCodeSecurity, SuppressGCTransition, MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal  void OnVoiceError(void* pBufferContext, HRESULT Error) => onVoiceError(lpVtbl, pBufferContext, Error);

     IXAudio2VoiceCallback* lpVtbl = pointer;
     delegate* unmanaged<IXAudio2VoiceCallback*, uint, void> onVoiceProcessingPassStart = (delegate* unmanaged<IXAudio2VoiceCallback*, uint, void>)((void**)*(void**)pointer)[0];
     delegate* unmanaged<IXAudio2VoiceCallback*, void> onVoiceProcessingPassEnd = (delegate* unmanaged<IXAudio2VoiceCallback*, void>)((void**)*(void**)pointer)[1];
     delegate* unmanaged<IXAudio2VoiceCallback*, void> onStreamEnd = (delegate* unmanaged<IXAudio2VoiceCallback*, void>)((void**)*(void**)pointer)[2];
     delegate* unmanaged<IXAudio2VoiceCallback*, void*, void> onBufferStart = (delegate* unmanaged<IXAudio2VoiceCallback*, void*, void>)((void**)*(void**)pointer)[3];
     delegate* unmanaged<IXAudio2VoiceCallback*, void*, void> onBufferEnd = (delegate* unmanaged<IXAudio2VoiceCallback*, void*, void>)((void**)*(void**)pointer)[4];
     delegate* unmanaged<IXAudio2VoiceCallback*, void*, void> onLoopEnd = (delegate* unmanaged<IXAudio2VoiceCallback*, void*, void>)((void**)*(void**)pointer)[5];
     delegate* unmanaged<IXAudio2VoiceCallback*, void*, HRESULT, void> onVoiceError = (delegate* unmanaged<IXAudio2VoiceCallback*, void*, HRESULT, void>)((void**)*(void**)pointer)[6];
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_BUFFER
{
    internal uint Flags;                       // Either 0 or XAUDIO2_END_OF_STREAM.
    internal uint AudioBytes;                  // Size of the audio data buffer in bytes.
    internal byte* pAudioData;             // Pointer to the audio data buffer.
    internal uint PlayBegin;                   // First sample in this buffer to be played.
    internal uint PlayLength;                  // Length of the region to be played in samples,  or 0 to play the whole buffer.
    internal uint LoopBegin;                   // First sample of the region to be looped.
    internal uint LoopLength;                  // Length of the desired loop region in samples,  or 0 to loop the entire buffer.
    internal uint LoopCount;                   // Number of times to repeat the loop region,  or XAUDIO2_LOOP_INFINITE to loop forever.
    internal void* pContext;                     // Context value to be passed back in callbacks.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_BUFFER_WMA
{
    internal uint* pDecodedPacketCumulativeBytes; // Decoded packet's cumulative size array.Each element is the number of bytes accumulated when the corresponding XWMA packet is decoded in order.  The array must have PacketCount elements.
    internal uint PacketCount;                          // Number of XWMA packets submitted. Must be >= 1 and  divide evenly into XAUDIO2_BUFFER.AudioBytes.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal struct XAUDIO2_DEBUG_CONFIGURATION
{
    internal uint TraceMask;                   // Bitmap of enabled debug message types.
    internal uint BreakMask;                   // Message types that will break into the debugger.
    internal int LogThreadID;                   // Whether to // Log the thread ID with each message.
    internal int LogFileline;                   // Whether to // Log the source file and line number.
    internal int LogFunctionName;               // Whether to // Log the function name.
    internal int LogTiming;                     // Whether to // Log message timestamps.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_EFFECT_CHAIN
{
    internal uint EffectCount;                 // Number of effects in this voice's effect chain.
    internal XAUDIO2_EFFECT_DESCRIPTOR* pEffectDescriptors; // Array of effect descriptors.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_EFFECT_DESCRIPTOR
{
    internal void* pEffect;                  // Pointer to the effect object's IUnknown interface.
    internal int InitialState;                  // TRUE if the effect should begin in the enabled state.
    internal uint OutputChannels;              // How many output channels the effect should produce.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_FILTER_PARAMETERS
{
    internal XAUDIO2_FILTER_TYPE Type;           // Filter type.
    internal float Frequency;                    // Filter coefficient. must be >= 0 and <= XAUDIO2_MAX_FILTER_FREQUENCY See XAudio2CutoffFrequencyToRadians() for state-variable filter types and XAudio2CutoffFrequencyToOnePoleCoefficient() for one-pole filter types.
    internal float OneOverQ;                     // Reciprocal of the filter's quality factor Q; must be > 0 and <= XAUDIO2_MAX_FILTER_ONEOVERQ. Has no effect for one-pole filters.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal struct XAUDIO2_PERFORMANCE_DATA
{
    internal ulong AudioCyclesSinceLastQuery;   // CPU cycles spent on audio processing since the  last call to StartEngine or GetPerformanceData.
    internal ulong TotalCyclesSinceLastQuery;   // Total CPU cycles elapsed since the last call  (only counts the CPU XAudio2 is running on).
    internal uint MinimumCyclesPerQuantum;     // Fewest CPU cycles spent processing any one audio quantum since the last call.
    internal uint MaximumCyclesPerQuantum;     // Most CPU cycles spent processing any one  audio quantum since the last call.
    internal uint MemoryUsageInBytes;          // Total heap space currently in use.
    internal uint CurrentLatencyInSamples;     // Minimum delay from when a sample is read from a source buffer to when it reaches the speakers.
    internal uint GlitchesSinceEngineStarted;  // Audio dropouts since the engine was started.Data about XAudio2's current workload
    internal uint ActiveSourceVoiceCount;      // Source voices currently playing.
    internal uint TotalSourceVoiceCount;       // Source voices currently existing.
    internal uint ActiveSubmixVoiceCount;      // Submix voices currently playing/existing.
    internal uint ActiveResamplerCount;        // Resample xAPOs currently active.
    internal uint ActiveMatrixMixCount;        // MatrixMix xAPOs currently active.
    internal uint ActiveXmaSourceVoices;       // Number of source voices decoding XMA data.
    internal uint ActiveXmaStreams;            // A voice can use more than one XMA stream.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_SEND_DESCRIPTOR
{
    internal uint Flags;                       // Either 0 or XAUDIO2_SEND_USEFILTER.
    internal IXAudio2Voice* pOutputVoice;        // This send's destination voice.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal struct XAUDIO2_VOICE_DETAILS
{
    internal uint CreationFlags;               // Flags the voice was created with.
    internal uint ActiveFlags;                 // Flags currently active.
    internal uint InputChannels;               // Channels in the voice's input audio.
    internal uint InputSampleRate;             // Sample rate of the voice's input audio.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_VOICE_SENDS
{
    internal uint SendCount;                   // Number of sends from this voice.
    internal XAUDIO2_SEND_DESCRIPTOR* pSends;    // Array of SendCount send descriptors.
}

[StructLayout(LayoutKind.Sequential,Pack =1)]
internal unsafe struct XAUDIO2_VOICE_STATE
{
    internal void* pCurrentBufferContext;        // The pContext value provided in the XAUDIO2_BUFFER that is currently being processed, or NULL if  there are no buffers in the queue.
    internal uint BuffersQueued;               // Number of buffers currently queued on the voice  (including the one that is being processed).
    internal ulong SamplesPlayed;               // Total number of samples produced by the voice since it began processing the current audio stream. If XAUDIO2_VOICE_NOSAMPLESPLAYED is specified in the call to IXAudio2SourceVoice::GetState, this member will not be calculated, saving CPU.
}

#endregion

#region XAUDIO 3D
// source : https://github.com/terrafx/terrafx.interop.windows/tree/main/sources/Interop/Windows/DirectX/um/x3daudio

[StructLayout(LayoutKind.Explicit, Size = 20)]
internal readonly struct X3DAUDIO_HANDLE;

[StructLayout(LayoutKind.Sequential)]
internal struct X3DAUDIO_CONE
{
    internal float InnerAngle;
    internal float OuterAngle;
    internal float InnerVolume;
    internal float OuterVolume;
    internal float InnerLPF;
    internal float OuterLPF;
    internal float InnerReverb;
    internal float OuterReverb;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct X3DAUDIO_DISTANCE_CURVE
{
    internal X3DAUDIO_DISTANCE_CURVE_POINT* pPoints;
    internal uint PointCount;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct X3DAUDIO_DISTANCE_CURVE_POINT
{
    internal float Distance;
    internal float DSPSetting;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe partial struct X3DAUDIO_DSP_SETTINGS
{
    internal float* pMatrixCoefficients;
    internal float* pDelayTimes;
    internal uint SrcChannelCount;
    internal uint DstChannelCount;
    internal float LPFDirectCoefficient;
    internal float LPFReverbCoefficient;
    internal float ReverbLevel;
    internal float DopplerFactor;
    internal float EmitterToListenerAngle;
    internal float EmitterToListenerDistance;
    internal float EmitterVelocityComponent;
    internal float ListenerVelocityComponent;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct X3DAUDIO_EMITTER
{
    internal X3DAUDIO_CONE* pCone;
    internal X3DAUDIO_VECTOR OrientFront;
    internal X3DAUDIO_VECTOR OrientTop;
    internal X3DAUDIO_VECTOR Position;
    internal X3DAUDIO_VECTOR Velocity;
    internal float InnerRadius;
    internal float InnerRadiusAngle;
    internal uint ChannelCount;
    internal float ChannelRadius;
    internal float* pChannelAzimuths;
    internal X3DAUDIO_DISTANCE_CURVE* pVolumeCurve;
    internal X3DAUDIO_DISTANCE_CURVE* pLFECurve;
    internal X3DAUDIO_DISTANCE_CURVE* pLPFDirectCurve;
    internal X3DAUDIO_DISTANCE_CURVE* pLPFReverbCurve;
    internal X3DAUDIO_DISTANCE_CURVE* pReverbCurve;
    internal float CurveDistanceScaler;
    internal float DopplerScaler;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct X3DAUDIO_LISTENER
{
    internal X3DAUDIO_VECTOR OrientFront;
    internal X3DAUDIO_VECTOR OrientTop;
    internal X3DAUDIO_VECTOR Position;
    internal X3DAUDIO_VECTOR Velocity;
    internal X3DAUDIO_CONE* pCone;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe partial struct X3DAUDIO_VECTOR
{
    internal float X;
    internal float Y;
    internal float Z;
    internal X3DAUDIO_VECTOR(float x, float y, float z) => (X, Y, Z) = (x, y, z);
}

#endregion

#endif
