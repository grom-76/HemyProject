/**/
namespace Hemy.Lib.Core.Input;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Hemy.Lib.Core.Memory;

public unsafe struct CommandData(ulong name, delegate* unmanaged<byte, bool> action, byte key)
{
    public delegate* unmanaged<byte, bool> Action = action;
    // public fixed byte Name[8];// store the name //  string impossble 
    public ulong ActionName = name; // convert ulong To byte[] fast search 
    public byte Key = key;  // correspond MouseButton, Keys, Joystick_Button

    // public int TypeOrder =0; // si plusieurs joystick , clavier ou souris
    // public Inputs_Type Type;
    // public Inputs_State State;
    // public int RepeatTime = 0; 
    // public float Duree =0.0f;
    // public float StarTime = 0.0f; 
    // public float AccumulateTime = 0.0f;
    public bool IsAction = false;

    public bool Update() =>  Action(Key);

}

public unsafe sealed class Commands() : IDisposable
{
    public delegate bool EventDelegate(byte value);
    public delegate bool EventDelegateK(Key value);
    public delegate bool EventDelegateM(MouseButton value);
    public delegate bool EventDelegateG(ControllerButton value);

    private List<CommandData> _commands = [];
 

    private static ulong BytesToULong(string data)
    =>  (data.Length >= 1 ? ( (ulong)data[0] << 0) : 0 << 0 ) |
        (data.Length >= 2 ? ( (ulong)data[1] << 8) : 0 << 8 ) |
        (data.Length >= 3 ? ( (ulong)data[2] << 16) : 0 << 16 ) |  
        (data.Length >= 4 ? ( (ulong)data[3] << 24) : 0 << 24 ) |
        (data.Length >= 5 ? ( (ulong)data[4] << 32) : 0 << 32 ) |    
        (data.Length >= 6 ? ( (ulong)data[5] << 40) : 0 << 40 ) |    
        (data.Length >= 7 ? ( (ulong)data[6] << 48) : 0 << 48 ) |    
        (data.Length >= 8 ? ( (ulong)data[7] << 56) : 0 << 56 ) ;

    public void Add(string commandName8CarMax, EventDelegateK eventDelegate, Key Key)
    {
        CommandData temp = new(BytesToULong(commandName8CarMax), (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate( eventDelegate), (byte)Key);
        _commands.Add(temp);
    }
    
    public void Add(string commandName8CarMax, EventDelegateM eventDelegate, MouseButton Key)
    {
        CommandData temp = new(BytesToULong(commandName8CarMax), (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate( eventDelegate), (byte)Key);
        _commands.Add(temp);
    }

    public void Add(string commandName8CarMax, EventDelegateG eventDelegate, ControllerButton Key)
    {
        CommandData temp = new(BytesToULong(commandName8CarMax), (delegate* unmanaged<byte, bool>)Marshal.GetFunctionPointerForDelegate( eventDelegate), (byte)Key);
        _commands.Add(temp);
    }

    public bool IsAction(string commandName)
    {
        ulong name = BytesToULong(commandName);
        bool result = false;
        for (int i = 0; i < _commands.Count; i++)
        {
            if (name == _commands[i].ActionName)
                result = result || _commands[i].Update();
        }
        return result;
    }

    public void Dispose()
    {
        _commands.Clear();
        _commands = null;
        GC.SuppressFinalize(this);
    }
}
