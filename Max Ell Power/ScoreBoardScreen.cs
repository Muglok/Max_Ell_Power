using System;
using System.Threading;
using Tao.Sdl;
using System.Collections.Generic;

class ScoreBoardScreen : Screen
{
    short index;
    Image bakcGround;
    Audio audio, audio2;
    Font font;
    bool spacePressed;
    List<Scores> scoreList;
    string[,] text = new string[2, 3]
    {
        {"Player number ","  Score: ","  Jumps: " },
        {"Numero de jugador ","  Puntuacion: ","  Saltos: " }
    };
    int ind = GameController.language - 1;
    IntPtr[] scorePtr;

    public ScoreBoardScreen(Hardware hardware) : base(hardware)
    {
        scoreList = GameScreen.scoreList;
        scorePtr = new IntPtr[scoreList.Count];
        font = new Font("fonts/Abberancy.ttf", 35);
        bakcGround = new Image("imgs/fondoNegro.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/Wistful-for-piano.mid");
        audio2 = new Audio(44100, 2, 4096);
        audio2.AddWAV("sound/fire.Wav");

        bakcGround.MoveTo(0, 0);

        InitText();
    }

    public void InitText()
    {
        Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
        string line;

        for (int i = 0; i < scorePtr.Length; i++)
        {
            line = text[ind,0] + Convert.ToInt32(scoreList[i].num) + text[ind, 1] +
                Convert.ToInt32(scoreList[i].score) + text[ind, 2] +
                Convert.ToInt32(scoreList[i].jumps);
            scorePtr[i] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            line, red);
        }
    }

    public void Draw()
    {
        for (short i = 0; i < scoreList.Count; i++)
        {
            hardware.WriteText(scorePtr[i], 50, (short)((index * 35) + (45 * i)));
        }
    }

    public override void Show()
    {
        audio.PlayMusic(0, -1);
        spacePressed = false;
        index = 1;

        hardware.DrawImage(bakcGround);
        Draw();
        
        do
        {
            hardware.UpdateScreen();

            int keyPressed = hardware.KeyPressed();

            /*Two conditions to equalize the joystick movement with the 
            keyboard pulsations*/

            if (Hardware.JoystickMovedUp())
            {
                keyPressed = Hardware.KEY_UP;
                Thread.Sleep(70);
            }

            else if (Hardware.JoystickMovedDown())
            {
                keyPressed = Hardware.KEY_DOWN;
                Thread.Sleep(70);
            }

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

            if (keyPressed == Hardware.KEY_UP && index < 1)
            {
                audio2.PlayWAV(0, 1, 0);
                hardware.ClearScreen();
                index++;
                hardware.DrawImage(bakcGround);
                Draw();
            }

            if (keyPressed == Hardware.KEY_DOWN && index > -(scoreList.Count -15))
            {
                audio2.PlayWAV(0, 1, 0);
                hardware.ClearScreen();
                index--;
                hardware.DrawImage(bakcGround);
                Draw();
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

