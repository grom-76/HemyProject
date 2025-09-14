#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class LibraryLoaderImpl
{
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static nint Load(string libraryName)
    {
        nint dll = LoadLibrary(libraryName);
        if (dll == nint.Zero)
        {
            Log.Display("Error", $"Impossible de charger la Library suivante : {libraryName}");
        }

        return dll;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static void Unload(nint module)
    {
        if (FreeLibrary(module) == 0)
        {
            Log.Display("Error", $"Unload module Failed ");
        }
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static nint GetSymbol(nint library, string symbolName)
    {
        nint proc = GetProcAddress(library, symbolName);
        if (proc == nint.Zero)
        {
            Log.Display("Error", $"Impossible de trouver l'adresse du symbole suivant : {symbolName}");
        }

        return proc;
    }
    
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial uint FreeLibrary(nint hModule);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial nint GetProcAddress(nint hModule, string lpProcName);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false, EntryPoint = "LoadLibraryA", StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial nint LoadLibrary(string lpFileName);
}

#endif
