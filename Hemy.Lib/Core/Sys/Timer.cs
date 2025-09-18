namespace Hemy.Lib.Core.Sys;

using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Sys;
#endif

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Timer(ulong duration_ms, int loop =1 )
{
    private ulong _start = 0;
    private ulong _duration = duration_ms * (HighResolutionTimer.Frequency / 1000 );
    private int _loop = 0;
    private int _loopCount = loop;

    public void Start()
    {
        _start = HighResolutionTimer.TimeStamp;
        _loop = _loopCount;
    }

    // public void Reset()
    // {
    //     _start = HighResolutionTimer.TimeStamp;

    // }

    public bool IsDone()
    {
        if (HighResolutionTimer.TimeStamp - _start >= _duration && _loop != 0)
        {
            _loop--;
            _start = HighResolutionTimer.TimeStamp;
            return true;
        }
        return false;
    }
}


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TimerTrigger(ulong duration_ms, int loop =1,TimerTrigger.EventTimerDelegate  action =null )
{
    
    public delegate void EventTimerDelegate();
    private delegate* unmanaged<void> _action = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(action) ; 
    private ulong _start = 0;
    private ulong _duration = duration_ms * (HighResolutionTimer.Frequency / 1000);
    private int _loop = 0;
    private int _loopCount = loop;

    public void Start()
    {
        _start = HighResolutionTimer.TimeStamp;
        _loop = _loopCount;
    }


    public void Update()
    {
        if (HighResolutionTimer.TimeStamp - _start >= _duration && _loop != 0)
        {
            _loop--;
            _start = HighResolutionTimer.TimeStamp;

            if (_action != null)
                _action();
        }

    }

    public void Dispose()
    {
        _action = null;
    }
}

