namespace Hemy.Lib.V2.Core;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Events
{

    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    public interface IEvents
    {
        [MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
        void RequestClose();

        [MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
        bool IsRunning();
    }


}
