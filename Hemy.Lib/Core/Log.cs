namespace Hemy.Lib.Core;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Log
{
        public const string INFO = "INFO";
        public const string ERROR = "ERROR";
        public const string WARNING = "WARN";

        /// <summary>
        ///  Verbose
        /// </summary>
        /// <param name="message"></param>
        /// <param name="file"></param>
        /// <param name="method"></param>
        /// <param name="line"></param> <summary>
        /// </summary>
        //     [Conditional("DEBUG")]
        //     [DebuggerHidden]
        public static void Info(string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string method = "",
            [CallerLineNumber] int line = 0)
#if WINDOWS
            => Hemy.Lib.Core.Platform.Windows.Common.Log.Display(Log.INFO, message, file, method, line);
#else
        {}
#endif

        /// <summary>
        /// event not excpected but continue 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="file"></param>
        /// <param name="method"></param>
        /// <param name="line"></param> <summary>
        /// </summary>
        //     [Conditional("DEBUG")]
        //     [DebuggerHidden]
        public static void Warning(string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string method = "",
            [CallerLineNumber] int line = 0)
#if WINDOWS
              => Hemy.Lib.Core.Platform.Windows.Common.Log.Display(Log.WARNING, message, file, method, line);
#else
        {}
#endif

        /// <summary>
        /// When something wrong need to quit 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="file"></param>
        /// <param name="method"></param>
        /// <param name="line"></param> <summary>
        /// </summary>
        //     [Conditional("DEBUG")]
        //     [DebuggerHidden]
        public static void Error(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string method = "",
            [CallerLineNumber] int line = 0)
#if WINDOWS
              => Hemy.Lib.Core.Platform.Windows.Common.Log.Display(Log.ERROR, message, file, method, line);
#else
        {}
#endif

public static void Display(
        string header,
        string message,
        [CallerFilePath] string file = "",
        [CallerMemberName] string method = "",
        [CallerLineNumber] int line = 0)
#if WINDOWS        
          => Hemy.Lib.Core.Platform.Windows.Common.Log.Display(header, message, file, method, line);
#else
        {}
#endif
}