/**/
namespace Hemy.Lib.Core.Input;

using System.Collections.Generic;

public unsafe struct CommandData
{
    public delegate bool PFN_Action(int id, int key);
    public PFN_Action fN_Action = null!;
    public int ActionName = -1;
    int _Player = 0;
    int _Key = 0;  // correspond MouseButton, Keys, Joystick_Button
    bool _isValid = false;
    // public int TypeOrder =0; // si plusieurs joystick , clavier ou souris
    // public Inputs_Type Type;
    // public Inputs_State State;
    // public int RepeatTime = 0; 
    // public float Duree =0.0f;
    // public float StarTime = 0.0f; 
    // public float AccumulateTime = 0.0f;
    public CommandData(int name  , int key, int player =0)
    { 
        ActionName = name;
        _Player = player;
        _Key = key;
    }

    public bool IsCompleted => _isValid ;

    public void Update( double elpasedTime )
    {
        // AccumulateTime = StarTime + elpased; 

        _isValid = fN_Action(_Player, _Key);

        // //...... if Accumultae Time = duree Reset 
        // if ( IsValid)
        // {
        //     StarTime = 1000.0f;
        // }
    }

}

public readonly unsafe struct Commands()
{
    readonly Dictionary<int, CommandData> _commands = new();
    /*
        Add command :
            Command Name ( string )
            InputType ( Gesture , touch , gampad(player) , keyboard, mouse )
            InputState (Click, Double click, pressed, released , up , down , )
            Touch/Buttons  use it ( Key, mouse button , ControllerButton)
            Timer 

    */
    public void AddCommand(int command_Name, InputState inputState, InputType inputType , int Key, int player = 0 )
    {
        CommandData temp = new(command_Name,Key, player);
        
        if ( inputType == InputType.Keyboard)
        {
            // if ( inputState == InputState.Pressed)
            //     temp.fN_Action=  IsKeyPressed;
            // if ( inputState == InputState.Release)
            //     temp.fN_Action= IsKeyReleased;
            // if ( inputState == InputState.Down)
            //     temp.fN_Action= IsKeyDown;
            // if ( inputState == InputState.Up)
            //     temp.fN_Action= IsKeyUp;
        }
        if ( inputType == InputType.Mouse)
        {
            // if ( inputState == InputState.Pressed)
            //     temp.fN_Action= IsMouseButtonPressed;
            // if ( inputState == InputState.Release)
            //     temp.fN_Action= IsMouseButtonReleased;
            // if ( inputState == InputState.Down)
            //     temp.fN_Action= IsMouseButtonDown;
            // if ( inputState == InputState.Up)
            //     temp.fN_Action= IsMouseButtonUp;
        }	
        if ( inputType == InputType.Joystick)
        {
            // if ( inputState == InputState.Pressed)
            //     temp.fN_Action= IsJoystickButtonPressed;
            // if ( inputState == InputState.Release)
            //     temp.fN_Action=   IsJoystickButtonReleased;
            // if ( inputState == InputState.Down)
            //     temp.fN_Action= IsJoystickButtonDown;
            // if ( inputState == InputState.Up)
            //     temp.fN_Action= IsJoystickButtonUp;
        }

        _commands.Add (command_Name,temp );
    }

    public void RemoveCommand(int command_name)
    {
        _commands.Remove(command_name);
    }

    public bool IsAction(int commandName)
        => _commands.ContainsKey(commandName) && _commands[commandName].IsCompleted;
}
