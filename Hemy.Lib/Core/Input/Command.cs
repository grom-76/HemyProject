/**/
namespace Hemy.Lib.Core.Input;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Core.Memory;
using Hemy.Lib.Core.Sys;

public unsafe struct TriggerData()
{
    public delegate* unmanaged<byte, bool> InputAction = null;
    public byte Key = 0;  // correspond MouseButton, Keys, Joystick_Button
    public delegate* unmanaged<void> ActionExecute = null;//(delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(action) ; 
    public ulong StartTime = 0;
    public ulong Duration = 0;
    public int Loop = 0;
    public int LoopCount = 0;
    public int Type = 0;
    public uint Id = 0; 
}

public unsafe struct Triggers() // SystemTriggers ( add onKillFocus .....)
{
    private TriggerData[] _triggerData = new TriggerData[10];
    private int Position = 0;
    const int Input = 0;
    const int Timer = 1;
    public delegate bool EventDelegate(byte value);
    public delegate bool EventDelegateK(Key value);
    public delegate bool EventDelegateM(MouseButton value);
    public delegate bool EventDelegateG(ControllerButton value);
    public delegate void EventActionExecute();

    private void Empty(){ }
    private bool EmptyInput(byte b){ _ = b; return false; }


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

        trigger.InputAction = (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate(EmptyInput);
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
        && HighResolutionTimer.TimeStamp - data->StartTime >= data->Duration
        && data->Loop != 0;

    private bool IsValidCommand(TriggerData* data) => data->Type == Input && data->InputAction(data->Key);
    
    public void Update()
    {
        for (int i = 0; i < _triggerData.Length; i++)
        {
            TriggerData data = _triggerData[i];

            if (IsValidCommand(&data))
                { data.ActionExecute();}

            if (IsValidTimer(&data))
            {
                data.Loop--;
                data.StartTime = HighResolutionTimer.TimeStamp;

                data.ActionExecute();
            }
        }

    }


    
}


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct CommandData(ulong name, delegate* unmanaged<byte, bool> action, byte key)
{
    //Triggers(Context) .AddCommand( player1 , Name , touch, type , action

    private readonly delegate* unmanaged<byte, bool> Action = action;
    public readonly ulong ActionName = name; // convert ulong To byte[] fast search 
    private readonly byte Key = key;  // correspond MouseButton, Keys, Joystick_Button

    // public int TypeOrder =0; // si plusieurs joystick , clavier ou souris
    // public Inputs_Type Type;
    // public Inputs_State State;
    // public int RepeatTime = 0; 
    // public float Duree =0.0f;
    // public float StarTime = 0.0f; 
    // public float AccumulateTime = 0.0f;

    public bool Update() => Action(Key);
}

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Commands(int count = 10)
{
    public delegate bool EventDelegate(byte value);
    public delegate bool EventDelegateK(Key value);
    public delegate bool EventDelegateM(MouseButton value);
    public delegate bool EventDelegateG(ControllerButton value);

    private CommandData[] _commands = new CommandData[count];
    private int Position = 0;

    private static ulong BytesToULong(string data)
    => (data.Length >= 1 ? ((ulong)data[0] << 0) : 0 << 0) |
        (data.Length >= 2 ? ((ulong)data[1] << 8) : 0 << 8) |
        (data.Length >= 3 ? ((ulong)data[2] << 16) : 0 << 16) |
        (data.Length >= 4 ? ((ulong)data[3] << 24) : 0 << 24) |
        (data.Length >= 5 ? ((ulong)data[4] << 32) : 0 << 32) |
        (data.Length >= 6 ? ((ulong)data[5] << 40) : 0 << 40) |
        (data.Length >= 7 ? ((ulong)data[6] << 48) : 0 << 48) |
        (data.Length >= 8 ? ((ulong)data[7] << 56) : 0 << 56);

    public void Add(string commandName8CarMax, EventDelegateK eventDelegate, Key Key)
    {
        CommandData temp = new(BytesToULong(commandName8CarMax), (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate(eventDelegate), (byte)Key);
        _commands[Position++] = temp;
    }

    public void Add(string commandName8CarMax, EventDelegateM eventDelegate, MouseButton Key)
    {
        CommandData temp = new(BytesToULong(commandName8CarMax), (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate(eventDelegate), (byte)Key);
        _commands[Position++] = temp;
    }

    public void Add(string commandName8CarMax, EventDelegateG eventDelegate, ControllerButton Key)
    {
        CommandData temp = new(BytesToULong(commandName8CarMax), (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate(eventDelegate), (byte)Key);
        _commands[Position++] = temp;
    }

    public bool IsAction(string commandName)
    {
        ulong name = BytesToULong(commandName);
        bool result = false;
        for (int i = 0; i < _commands.Length; i++)
        {
            if (name == _commands[i].ActionName)
                result = result || _commands[i].Update();
        }
        return result;
    }

    public void Dispose()
    {
        Array.Clear(_commands);
        _commands = null;
    }
}
