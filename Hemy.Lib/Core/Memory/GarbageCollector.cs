
namespace Hemy.Lib.Core.Memory;

using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


/// <summary>
/// // CPU  architecture, number of core , max thread ,... 
/// </summary>
[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public struct GarbageCollector()
{
    private static GCLatencyMode _lactencyDefault = GCSettings.LatencyMode;

    public static void Init(int memoryPressure = 1024 * 1024 * 48, GarbageCollectionPriority priority = GarbageCollectionPriority.High)
    {
        // GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
        GCSettings.LatencyMode = (GCLatencyMode)priority;

        GC.AddMemoryPressure(memoryPressure);
        Log.Info( $"Set Garbage collector with Memory Pressure : {memoryPressure}  ");

        // if ( Settings.SelectedPlatform.Equals( App.Platform.AutoDetect ))
        //     Settings.SelectedPlatform = App.Platform.DetectPlatformUsed();
    }

    public static void Dispose(int memoryPressure = 1024 * 1024 * 48)
    {
        GCSettings.LatencyMode = _lactencyDefault;

        GC.RemoveMemoryPressure(memoryPressure);
        Log.Info( $"Remove Garbage collector  Memory Pressure : {memoryPressure}  ");
    }

    public enum GarbageCollectionPriority
    {
        Normal = 1,
        High = GCLatencyMode.SustainedLowLatency,
        Desactive = 0,
        Middle = 2,
    }

}
