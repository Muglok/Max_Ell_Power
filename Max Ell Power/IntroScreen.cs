using System;
using System.Threading;
using Tao.Sdl;
/*
* This class willshow the credit screen
 */
class IntroScreen : Screen
{
    Image bakcGround;
    Audio audio;
    Font font;
    IntPtr Englis;
    IntPtr Castellano;
    bool next;

    public IntroScreen(Hardware hardware) : base(hardware)
    {
        bakcGround = new Image("imgs/IntroScreen2.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/IntroTheme.mid");
        font = new Font("fonts/NexaRustSlab-BlackShadow01.otf", 35);
        bakcGround.MoveTo(0, 0);
        Sdl.SDL_Color white = new Sdl.SDL_Color(255, 255, 255);
        Englis = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Press space/A escape/B to continue", white);
        Castellano = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Espacio o A para Castellano", white);
        Englis = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Escape or B for English", white);
    }


    public void Draw()
    {
        hardware.DrawImage(bakcGround);
        hardware.WriteText(Castellano, 240, 515);
        hardware.WriteText(Englis, 295, 585);
        hardware.UpdateScreen();
    }

    public override void Show()
    {
        next = false;
        Draw();
        Thread.Sleep(300);
        audio.PlayMusic(0, -1);

        do
        {
            int keyPressed = hardware.KeyPressed();

            /*Two conditions to equalize the joystick movement with the 
            keyboard pulsations*/

            if (Hardware.JoystickPressed(0))
            {
                keyPressed = Hardware.KEY_SPACE;
                Thread.Sleep(70);
            }
            else if (Hardware.JoystickPressed(1))
            {
                keyPressed = Hardware.KEY_ESC;
                Thread.Sleep(70);
            }

            if (keyPressed == Hardware.KEY_SPACE)
            {
                next = true;
                GameController.language = 2;
            }

            if (keyPressed == Hardware.KEY_ESC)
            {
                next = true;
                GameController.language = 1;
            }

        } while (next != true);
        audio.StopMusic();
    }
}
