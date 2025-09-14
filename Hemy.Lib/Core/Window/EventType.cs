namespace Hemy.Lib.Core.Window;
#if WINDOWS
public enum EventType : byte
{
    /// <summary> Se déclenche lors de la Perte du focus de la fenetre, la fenetre n'est plus active </summary>
    OnKillFocus,
    OnSetFocus,
    OnQuit,
    OnKeyDown,
}
