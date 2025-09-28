namespace Hemy.Lib.V2.Platform.Windows;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

using const_char = System.Byte;
using BOOL = System.Int32;

// https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
using size_t = System.UIntPtr;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;

using VkBool32 = System.UInt32;
using VkDeviceAddress = System.UInt64;
using VkDeviceSize = System.UInt64;
using Flag = System.Int32;

using HRESULT = System.Int32;

using static Hemy.Lib.V2.Platform.Windows.WindowsGraphicCommon;
using static Hemy.Lib.V2.Platform.Windows.WindowsWindowCommon;
using Hemy.Lib.V2.Core;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class WindowsAudioCommon
{

}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class WindowsAudioDevice
{

	internal static int Init( WindowsData* infos)
	{
		// const float SpeedOfSound = 345.0f;

		infos->AudioModule = GetAudioModuleDLL();
		// if (contextData->AudioModule == nint.Zero)
		// {
		// 	Log.Error("Load XAUDIO2 DLL");
		// 	return 1;
		// }

		// Load(LibraryLoader.GetSymbol, contextData->AudioModule);

		// IXAudio2* Instance = null;
		// var err = XAudio2Create(&Instance, 0, AudioConsts.XAUDIO2_DEFAULT_PROCESSOR);

		// // if ( Instance == null || err != (uint)XAUDIO2_ERRORS.XAUDIO2_SUCESS, "Create Xaudio2 INSTANCE ")) { return 1; }

		// IXAudio2 iXAudio2Temp = new(Instance);
		// contextData->AudioInstance = Memory.Memory.New<IXAudio2>(withCopyInstance: false);//pool->New<IXAudio2>( );
		// Memory.Memory.Copy(Memory.Memory.ToPtr(ref iXAudio2Temp), contextData->AudioInstance, Memory.Memory.Size<IXAudio2>());

		// contextData->Debug = Memory.Memory.New<XAUDIO2_DEBUG_CONFIGURATION>(false);// pool->New<XAUDIO2_DEBUG_CONFIGURATION>( new() );	
		// contextData->Debug->LogThreadID = 0;
		// contextData->Debug->LogFileline = 0;
		// contextData->Debug->LogFunctionName = 0;
		// contextData->Debug->LogTiming = 0;
		// contextData->Debug->TraceMask = AudioConsts.XAUDIO2_LOG_ERRORS | AudioConsts.XAUDIO2_LOG_WARNINGS | AudioConsts.XAUDIO2_LOG_INFO;
		// contextData->Debug->BreakMask = AudioConsts.XAUDIO2_LOG_ERRORS;
		// contextData->AudioInstance->SetDebugConfiguration(contextData->Debug, null);

		// if (contextData->Debug == null) { Log.Error("Create Xaudio2 Debug "); return 1; }

		// // IXAudio2EngineCallback mEngineCallback;
		// // err = contextData->AudioInstance->RegisterForCallbacks( &mEngineCallback );
		// // if ( Log.Check(err != 0, "Create Xaudio2 Debug ")) { return 1; }

		// WAVEFORMATEX waveFormatEx = default;
		// waveFormatEx.nChannels = 2;
		// waveFormatEx.nSamplesPerSec = 0;
		// IXAudio2MasteringVoice* tempMaster = null;
		// err = contextData->AudioInstance->CreateMasteringVoice(&tempMaster, 2, 0, 0, null, null, AudioConsts.AUDIO_STREAM_CATEGORY_GameEffects);

		// if (tempMaster == null) { Log.Error("Create Xaudio2 Master Voice"); return 1; }

		// IXAudio2MasteringVoice iXAudio2MasteringVoice = new(tempMaster);
		// contextData->MasterVoice = Memory.Memory.New<IXAudio2MasteringVoice>(false);
		// Memory.Memory.Copy(Memory.Memory.ToPtr(ref iXAudio2MasteringVoice), contextData->MasterVoice, Memory.Memory.Size<IXAudio2MasteringVoice>());


		// uint channelMask = 0;
		// err = contextData->MasterVoice->GetChannelMask(&channelMask);

		// if (err != 0) { Log.Error("GetChannel MAsk "); return 1; }

		// X3DAUDIO_HANDLE* Handle3D;
		// err = (uint)X3DAudioInitialize(channelMask, SpeedOfSound, &Handle3D);

		// contextData->Handle3D = Handle3D;

		// if (Handle3D == null) { Log.Error("X3D Audio "); return 1; }

		return 0;
	}

	internal static void Dispose( WindowsData* infos)
	{
		// if (audioData->AudioInstance == null) return;

		// if (audioData->MasterVoice != null)
		// 	audioData->MasterVoice->DestroyVoice();

		// var error = audioData->AudioInstance->Release();

		// Memory.Memory.Dispose(audioData->AudioInstance);
		// Memory.Memory.Dispose(audioData->Debug);
		// Memory.Memory.Dispose(audioData->MasterVoice);
		// // Memory.Dispose(audioData->Handle3D); // TODO ne pas faire dispose Pourquoi ?

		// LibraryLoader.Unload(audioData->AudioModule);
	}

	internal static void SetVolume(WindowsData* infos, float value)
	{
		//clamp  value < min ? min : value > max ? max : value
		// audioData->Volume = value;
		// var err = audioData->MasterVoice->SetVolume(value);
		// if (err != 0)
		// 	Log.Error("Set Volume failed");
	}

	internal static void Suspend( WindowsData* infos)
	{
		// if (audioData->AudioInstance == null) return;

		// audioData->AudioInstance->StopEngine();
	}

	internal static void Resume( WindowsData* infos)
	{
		// if (audioData->AudioInstance == null) return;

		// var result = audioData->AudioInstance->StartEngine();
		// if (result != 0)
		// {
		// 	Log.Error("Resume of the audio engine failed; running in 'silent mode");
		// 	//Silent MOde
		// }
	}

	internal static void Reset( WindowsData* infos)
	{
		// if (audioData->AudioInstance != null)
		// 	Dispose(audioData: audioData);

		// Init(audioData);
	}

	static nint GetAudioModuleDLL()
	{
		var AudioModule = WindowsSystem.Load(XAudio2_9);

		if (AudioModule != nint.Zero) { return AudioModule; }

		AudioModule = WindowsSystem.Load(XAudio2_8);

		if (AudioModule != nint.Zero) { return AudioModule; }

		AudioModule = WindowsSystem.Load(XAudio1_7);

		if (AudioModule != nint.Zero) { return AudioModule; }

		return nint.Zero;
	}



	internal const string XAudio2_9 = "XAudio2_9";
	internal const string XAudio2_8 = "XAudio2_8";
	internal const string XAudio1_7 = "XAudio1_7";


	// // TODO replace System.MAth by own method  ( Log10 , Sin POw ASin )
	// public static float XAudio2DecibelsToAmplitudeRatio(float Decibels)
	// 	=> Math.MathFuncs.powf(10.0f, Decibels / 20.0f);

	// /// <summary>
	// /// // Inline function that converts an amplitude ratio value to a decibel value.
	// /// </summary>
	// /// <param name="Volume"></param>
	// /// <returns></returns>
	// public static float XAudio2AmplitudeRatioToDecibels(float Volume)
	// 	=> Volume == 0.0f ? -3.402823466e+38f : 20.0f * Math.MathFuncs.clog10f(Volume);

	// public static float XAudio2SemitonesToFrequencyRatio(float Semitones)
	// 	=> Math.MathFuncs.powf(2.0f, Semitones / 12.0f);

	// public static float XAudio2FrequencyRatioToSemitones(float FrequencyRatio)
	// 	=> 39.86313713864835f * Math.MathFuncs.clog10f(FrequencyRatio);

	// public static float XAudio2CutoffFrequencyToRadians(float CutoffFrequency, uint SampleRate)
	// 	=> (uint)(CutoffFrequency * 6.0f) >= SampleRate ? 1.0f : 2.0f * Math.MathFuncs.sinf((float)3.14159265358979323846 * CutoffFrequency / SampleRate);

	// public static float XAudio2RadiansToCutoffFrequency(float Radians, float SampleRate)
	// 	=> SampleRate * Math.MathFuncs.asinf(Radians / 2.0f) / (float)3.14159265358979323846;

	// public static float XAudio2CutoffFrequencyToOnePoleCoefficient(float CutoffFrequency, uint SampleRate)
	// 	=> (uint)CutoffFrequency >= SampleRate ? 1.0f : 1.0f - Math.MathFuncs.powf(1.0f - (2.0f * CutoffFrequency / SampleRate), 2.0f);


	/// <summary> Creates a new XAudio2 object and returns a pointer to its IXAudio2 interface. </summary>
	// private static delegate* unmanaged[MemberFunction]<IXAudio2**, uint, uint, HRESULT> PFN_XAudio2Create = null;
	private static delegate* unmanaged[MemberFunction]<void**, uint, HRESULT> PFN_CreateAudioReverb = null;
	private static delegate* unmanaged[MemberFunction]<void**, uint, HRESULT> PFN_CreateAudioVolumeMeter = null;
	private static delegate* unmanaged[MemberFunction]<uint, float, X3DAUDIO_HANDLE**, HRESULT> PFN_X3DAudioInitialize = null;
	private static delegate* unmanaged[MemberFunction]<void*, void*, void*, uint, void*, void> PFN_X3DAudioCalculate = null;

	public unsafe delegate nint LoadFunction(nint ptr, string name);

	public static void Load( nint module)
	{
		// PFN_XAudio2Create = (delegate* unmanaged[MemberFunction]<IXAudio2**, uint, uint, HRESULT>)load(module, "XAudio2Create");
		PFN_CreateAudioReverb = (delegate* unmanaged[MemberFunction]<void**, uint, HRESULT>)Windows.WindowsSystem.GetSymbol(module, "CreateAudioReverb");
		PFN_CreateAudioVolumeMeter = (delegate* unmanaged[MemberFunction]<void**, uint, HRESULT>)Windows.WindowsSystem.GetSymbol(module, "CreateAudioVolumeMeter");
		PFN_X3DAudioInitialize = (delegate* unmanaged[MemberFunction]<uint, float, X3DAUDIO_HANDLE**, HRESULT>)Windows.WindowsSystem.GetSymbol(module, "X3DAudioInitialize");
		PFN_X3DAudioCalculate = (delegate* unmanaged[MemberFunction]<void*, void*, void*, uint, void*, void>)Windows.WindowsSystem.GetSymbol(module, "X3DAudioCalculate");

	}

	// XAUDIO2 
	// [SuppressGCTransition]
	// [SkipLocalsInit]
	// [SuppressUnmanagedCodeSecurity]
	// internal static HRESULT XAudio2Create(IXAudio2** ppXAudio2, uint Flags = 0, uint XAudio2Processor = XAUDIO2_DEFAULT_PROCESSOR)
	// 	=> PFN_XAudio2Create(ppXAudio2, Flags, XAudio2Processor);

	// XAUDIO 3D
	[SuppressGCTransition]
	[SkipLocalsInit]
	[SuppressUnmanagedCodeSecurity]
	internal static HRESULT X3DAudioInitialize(uint SpeakerChannelMask, float SpeedOfSound, X3DAUDIO_HANDLE** Instance)
		=> PFN_X3DAudioInitialize(SpeakerChannelMask, SpeedOfSound, Instance);

	// [SuppressGCTransition]
	// [SkipLocalsInit]
	// [SuppressUnmanagedCodeSecurity]
	// internal static void X3DAudioCalculate(X3DAUDIO_HANDLE* Instance, X3DAUDIO_LISTENER* pListener, X3DAUDIO_EMITTER* pEmitter, uint Flags, X3DAUDIO_DSP_SETTINGS* pDSPSettings)
	// 	=> PFN_X3DAudioCalculate(Instance, pListener, pEmitter, Flags, pDSPSettings);

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

	internal const int XAUDIO2_DEFAULT_PROCESSOR = 0x00000001;
	
	[StructLayout(LayoutKind.Explicit, Size = 20)]
	internal readonly struct X3DAUDIO_HANDLE;


}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class WindowsAudioSound2D
{


}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class  WindowsAudioSound3D
{


}


