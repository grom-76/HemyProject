/**/
namespace Hemy.Lib.Core.Sys;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Core.Input;
using Hemy.Lib.Core.Platform.Windows.Sys;
using Hemy.Lib.Core.Sys;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class Triggers(
#if WINDOWS    
    TimeData* timedata
#endif

) : IDisposable// SystemTriggers ( add onKillFocus .....)
{
    private static ulong BytesToULong(string data)
    => (data.Length >= 1 ? ((ulong)data[0] << 0) : 0 << 0) |
        (data.Length >= 2 ? ((ulong)data[1] << 8) : 0 << 8) |
        (data.Length >= 3 ? ((ulong)data[2] << 16) : 0 << 16) |
        (data.Length >= 4 ? ((ulong)data[3] << 24) : 0 << 24) |
        (data.Length >= 5 ? ((ulong)data[4] << 32) : 0 << 32) |
        (data.Length >= 6 ? ((ulong)data[5] << 40) : 0 << 40) |
        (data.Length >= 7 ? ((ulong)data[6] << 48) : 0 << 48) |
        (data.Length >= 8 ? ((ulong)data[7] << 56) : 0 << 56);

    private TriggerData[] _triggerData = new TriggerData[10];
    // private int[] _activList = new int[10];
    private int Position = 0;
    const int Input = 0;
    const int Timer = 1;
    public delegate bool EventDelegate(byte value);
    public delegate bool EventDelegateK(Key value);
    public delegate bool EventDelegateM(MouseButton value);
    public delegate bool EventDelegateG(ControllerButton value);
    public delegate void EventActionExecute();

    private static void Empty() { }
    private static bool EmptyInput(byte b) { _ = b; return false; }


    public void Add(string id, EventDelegateK inputEvent, Key Key, EventActionExecute actionExecute = null)
    {
        actionExecute ??= Empty;

        TriggerData trigger = new();

        trigger.Id = BytesToULong( id );
        trigger.Type = Input;

        trigger.InputAction = (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate(inputEvent);
        trigger.Key = (byte)Key;
        trigger.ActionExecute = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(actionExecute);

        trigger.Duration = 0;
        trigger.LoopCount = 0;

        _triggerData[Position++] = trigger;
    }

    public void Add(string id, ulong duration_ms, int loop = 1, EventActionExecute actionExecute = null)
    {
        actionExecute ??= Empty;

        TriggerData trigger = new();

        trigger.Id = BytesToULong( id );
        trigger.Type = Timer;

        trigger.InputAction = (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate((EventDelegate)EmptyInput);
        trigger.Key = (byte)0;
        trigger.ActionExecute = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(actionExecute);

        trigger.Duration = duration_ms ;
        trigger.LoopCount = loop;

        _triggerData[Position++] = trigger;
    }


    private int Findindex(string name)
    {
        ulong id = BytesToULong(name);
        
        int pos = 0;
        while (pos < Position && id == _triggerData[pos++].Id)
        {
            
        }
        return pos ;
    }

    public void StartTimer(string Id)
    {
        //find ID 
        ulong name = BytesToULong(Id);
        int index = -1;
        for (int i = 0; i < Position; i++)
        {
            if (name == _triggerData[i].Id)
            {
                index = i;
                break;
            }
        }

        if (index == -1) return;

        _triggerData[index].StartTime = timedata->CurrentFrameTime;
        _triggerData[index].Loop = _triggerData[index].LoopCount;
    }

    public void Remove(uint Id)
    {
        //find ID 

    }


    private bool IsValidTimer(TriggerData* data) => data->Type == Timer
        && ( timedata->CurrentFrameTime - data->StartTime) >= data->Duration
        && data->Loop != 0;

    private bool IsValidCommand(TriggerData* data) =>
        data->Type == Input
        && data->InputAction(data->Key);

    public void Update()
    {
        for (int i = 0; i < Position; i++)
        {
            TriggerData data = _triggerData[i];

            if (IsValidCommand(&data))
            { data.ActionExecute(); }

            if (IsValidTimer(&data))
            {
                
                _triggerData[i].Loop--;
                _triggerData[i].StartTime = timedata->CurrentFrameTime ;

                _triggerData[i].ActionExecute();
            }
        }
        // int activPosition = 0;
        // for (int i = 0; i < Position; i++)
        // {
        //     TriggerData data = _triggerData[i];
        //     if (IsValidCommand(&data) || IsValidTimer(&data))
        //         _activList[activPosition++] = i;
        // }

        // for (; activPosition <= 0; activPosition--)
        // {
        //     TriggerData data = _triggerData[_activList[activPosition]];
        //     data.Loop--;
        //     data.StartTime = HighResolutionTimer.TimeStamp;
        //     data.ActionExecute();
        // }



    }

    // private readonly object _triggerLock = new object();

    // public async Task NotifyObserversAsync(NotificationData data)
    // {
    //     // lock( _triggerLock ){
    //     var tasks = _observers.Select(observer =>
    //         Task.Run(() => observer.Update(data))
    //     );

    //     await Task.WhenAll(tasks);
    //     //}
    // }

    public void Dispose()
    {
        Array.Clear(_triggerData);
        _triggerData = null;

        GC.SuppressFinalize(this);
    }
}
