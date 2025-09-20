/**/
namespace Hemy.Lib.Core.Sys;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Core.Input;
using Hemy.Lib.Core.Sys;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class Triggers() : IDisposable// SystemTriggers ( add onKillFocus .....)
{
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


    public void Add(uint id, EventDelegateK inputEvent, Key Key, EventActionExecute actionExecute = null)
    {
        actionExecute ??= Empty;

        TriggerData trigger = new();

        trigger.Id = id;
        trigger.Type = Input;

        trigger.InputAction = (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate(inputEvent);
        trigger.Key = (byte)Key;
        trigger.ActionExecute = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(actionExecute);

        trigger.Duration = 0;
        trigger.LoopCount = 0;

        _triggerData[Position++] = trigger;
    }

    public void Add(uint id, ulong duration_ms, int loop = 1, EventActionExecute actionExecute = null)
    {
        actionExecute ??= Empty;

        TriggerData trigger = new();

        trigger.Id = id;
        trigger.Type = Timer;

        trigger.InputAction = (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate((EventDelegate)EmptyInput);
        trigger.Key = (byte)0;
        trigger.ActionExecute = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(actionExecute);

        trigger.Duration = duration_ms * (HighResolutionTimer.Frequency / 1000);
        trigger.LoopCount = loop;

        _triggerData[Position++] = trigger;
    }


    public void StartTimer(uint Id)
    {
        //find ID 
        uint i = Id;
        _triggerData[i].StartTime = HighResolutionTimer.TimeStamp;
        _triggerData[i].Loop = _triggerData[i].LoopCount;
    }

    public void Remove(uint Id)
    {
        //find ID 

    }


    private bool IsValidTimer(TriggerData* data) => data->Type == Timer
        && (HighResolutionTimer.TimeStamp - data->StartTime) >= data->Duration
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
                Log.Warning(data.ToString());
                _triggerData[i].Loop--;
                _triggerData[i].StartTime = HighResolutionTimer.TimeStamp;

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
