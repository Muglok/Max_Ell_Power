/*
* This class will show a screen in what you will be able to select one of 
* the diferent main characters
*/
using System.Threading;
using System;
using Tao.Sdl;

class PlayerSelectScreen : Screen
{
    private Image backGround,downArrow;
    private int[] characterXPositions;
    private int[] characterYPositions;
    private int chosenPlayer;
    private Audio backgroundMusic;
    private Audio arrowSound;
    private IntPtr tittle;
    private Font font;
    string[] text = new string[] { "Player Select Screen",
    "Seleccion de personaje"};

    public PlayerSelectScreen(Hardware hardware) : base(hardware)
    {
        backgroundMusic = new Audio(44100, 2, 4096);
        backgroundMusic.AddMusic("sound/Weird-Xmas.mid");
        arrowSound = new Audio(44100, 2, 4096);
        arrowSound.AddWAV("sound/fire.wav");
        font = new Font("fonts/NexaRustSlab-BlackShadow01.otf", 50);

        characterXPositions = new int[4];
        characterYPositions = new int[4];
        characterXPositions[0] = 300;
        characterYPositions[0] = 280;
        characterXPositions[1] = 465;
        characterYPositions[1] = 475;
        characterXPositions[2] = 720;
        characterYPositions[2] = 270;
        characterXPositions[3] = 1100;
        characterYPositions[3] = 310;

        chosenPlayer = 0;
        backGround = new Image
            (@"imgs\PlayerSelectScreenWithCharacters.png",1280,720);
        downArrow = new Image
            (@"imgs\Arrow2MiniDown.png", 57, 48);
        downArrow.X = (short)characterXPositions[chosenPlayer];
        downArrow.Y = (short)characterYPositions[chosenPlayer];
        
    }

    public void InitText()
    {
        Sdl.SDL_Color red = new Sdl.SDL_Color(255, 128, 0);
        tittle = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            text[GameController.language - 1], red);
    }

    public override void Show()
    {
        InitText();
        backgroundMusic.PlayMusic(0, -1);
        int keyPressed;
        hardware.ClearScreen();
        hardware.DrawImage(backGround);
        hardware.WriteText(tittle, 65, 75);
        hardware.DrawImage(downArrow);
        hardware.UpdateScreen();

        do
        {
            keyPressed = hardware.KeyPressed();

            if (Hardware.JoystickMovedLeft())
            {
                keyPressed = Hardware.KEY_LEFT;
                Thread.Sleep(70);
            }

            else if (Hardware.JoystickMovedRight())
            {
                keyPressed = Hardware.KEY_RIGHT;
                Thread.Sleep(70);
            }

            else if (Hardware.JoystickMovedDown())
            {
                keyPressed = Hardware.KEY_DOWN;
                Thread.Sleep(70);
            }
            else if (Hardware.JoystickPressed(0))
                keyPressed = Hardware.KEY_SPACE;

            if (keyPressed == Hardware.KEY_RIGHT ||
                keyPressed == Hardware.KEY_LEFT ||
                keyPressed == Hardware.KEY_DOWN)
            {
                switch (keyPressed)
                {
                    case Hardware.KEY_LEFT:
                        if(chosenPlayer > 0)
                        {
                            if (chosenPlayer == 2)
                                chosenPlayer -= 2;
                            else
                                chosenPlayer--;

                            arrowSound.PlayWAV(0, 2, 0);
                        }
                        break;

                    case Hardware.KEY_RIGHT:
                        if(chosenPlayer < 3)
                        {
                            if (chosenPlayer == 0)
                                chosenPlayer += 2;
                            else
                                chosenPlayer++;

                            arrowSound.PlayWAV(0, 2, 0);
                        }
                        break;

                    case Hardware.KEY_DOWN:
                        if (chosenPlayer == 0 || chosenPlayer == 2)
                        {
                            chosenPlayer = 1;
                            arrowSound.PlayWAV(0, 2, 0);
                        }
                        break;
                }

                downArrow.X = (short)characterXPositions[chosenPlayer];
                downArrow.Y = (short)characterYPositions[chosenPlayer];
                hardware.ClearScreen();
                hardware.DrawImage(backGround);
                hardware.WriteText(tittle, 65, 75);
                hardware.DrawImage(downArrow);
                hardware.UpdateScreen();
            }
        } while (keyPressed != Hardware.KEY_SPACE);
            
    }

    public int ChosenPlayer()
    {
        return chosenPlayer+1;
    }
}

