namespace Hemy.Sample.Advanced;

using System;
using Hemy.Lib.Core;


public class A002_SoundAndTriggers : Base
{
    public A002_SoundAndTriggers()
    {
        base.Window.Settings.Resolution = Lib.Core.Window.WindowResolution.SVGA_800x600;
    }

    Lib.Core.Audio.Sound2D sound2D ;

    protected override void Init()
    {
        base.Triggers.Add("Quit", base.Keyboard.IsPressed, Lib.Core.Input.Key.Escape, this.Close);
        base.Triggers.Add("Start", base.Keyboard.IsPressed, Lib.Core.Input.Key.Space, this.Start);

        sound2D = base.AudioDevice.GetSound2D();
        sound2D.CreateFromFile(@"C:\Users\Admin\Documents\HemyProject\Hemy.Sample\Assets\demo.wav");
        sound2D.SetVolume(0.5f);
        
        base.Triggers.Add("bombe", 2000, 3, this.Boom );
    }

    private void Boom()
    {
        Log.Info($" !!!!  BOOOOMMMM !!!! { base.Time.DeltaTime } ms Fram Time {base.Time.CurrentFrameTime} ms ");
        sound2D.Play();
    }

    private void Start()
    {
        base.Triggers.StartTimer("bombe");
    }

    private void Close()
    {
        base.Window.RequestClose();
    }

    protected override void Release()
    {

    }

    protected override void Update()
    {

    }

    protected override void Draw()
    {

    }
}