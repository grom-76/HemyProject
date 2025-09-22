namespace Hemy.Lib.Core.Audio;

enum PreferredBackend
{
    None,
    Dsound,
    Xaudio,
    CoreAudio,
    Pulse,
    Alsa,
    Winmm,
    OpenAL,
    MegaDrive,
    //system decide for you
    AutoDetect,
    Web,
    PS4,
    XBOX,
    SWITCH,
}

