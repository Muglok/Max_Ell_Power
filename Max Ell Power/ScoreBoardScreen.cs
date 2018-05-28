using System;
using System.Threading;
using Tao.Sdl;
using System.Collections.Generic;

class ScoreBoardScreen : Screen
{
    Image bakcGround;
    Audio audio;
    Font font;
    bool spacePressed;
    List<Scores> scoreList;

    IntPtr[] scorePtr;

    public ScoreBoardScreen(Hardware hardware) : base(hardware)
    {
        scoreList = GameScreen.scoreList;
        scorePtr = new IntPtr[scoreList.Count];
        font = new Font("fonts/Nashville.ttf", 33);
        bakcGround = new Image("imgs/fondoNegro.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/Wistful-for-piano.mid");

        bakcGround.MoveTo(0, 0);

        InitText();
    }

    public void InitText()
    {
        font = new Font("fonts/Nashville.ttf", 33);
        Sdl.SDL_Color gray = new Sdl.SDL_Color(125, 125, 125);
        Sdl.SDL_Color blue = new Sdl.SDL_Color(66, 125, 255);
        string line;

        for (int i = 0; i < scorePtr.Length; i++)
        {
            line = "Player number " + scoreList[i].num + "  Score: " +
                scoreList[i].score + "  Jumps: " + scoreList[i].jumps;
            scorePtr[i] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            line, gray);
        }
    }

    public override void Show()
    {
        audio.PlayMusic(0, -1);
        spacePressed = false;
        do
        {
            hardware.DrawImage(bakcGround);

            for (short i = 0; i < scorePtr.Length - 1; i++)
            {
                hardware.WriteText(scorePtr[i], 0, (short)(25 * i));
            }

            hardware.UpdateScreen();

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



            if (keyPressed == Hardware.KEY_SPACE ||
                keyPressed == Hardware.KEY_ESC)
            {
                spacePressed = true;
            }

            Thread.Sleep(10);

        } while (spacePressed != true);
        audio.StopMusic();
    }
}

