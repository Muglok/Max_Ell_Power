using System;
using System.Threading;
using Tao.Sdl;

/*
    * This class will manage the main menu screen and get the chosen option in 
    * that menu
    */
class MainMenuScreen : Screen
{
    Image bakcGround, imgChoseOption;
    Audio audio, audio2;
    Font font;
    string[] menuTexts;
    string[] menuTextsIn = new string[] { "Play Level", "Continue Last Game",
    "Horde Mode", "ScoreBoard", "Help", "Options", "Credits", "Exit Game"};
    string[] menuTextsEs = new string[] { "Jugar Nivel", "Continuar Partida",
    "Modo Horda", "Tabla De Puntuaciones", "Ayuda", "Opciones",
        "Creditos", "Salir Del Juego"};
    string[] disp = new string[] { " not available yet", " aun no disposible"};
    IntPtr[] textPtr = new IntPtr[9];
    int chosenOption = 0;
    short len = 0;
    bool spacePressed, exitGame;

    public MainMenuScreen(Hardware hardware) : base(hardware)
    {
        font = new Font("fonts/Abberancy.ttf", 45);

        InitText();
        bakcGround = new Image("imgs/Test.png", 1200, 720);
        imgChoseOption = new Image("imgs/choose_player.png", 48, 48);
        audio = new Audio(44100, 2, 4096);
        audio2 = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/song_a.mid");
        audio2.AddWAV("sound/fire.Wav");

        imgChoseOption.MoveTo((short)(470 + len), 105);
        bakcGround.MoveTo(0, 0);
    }

    //This method initialize the diferent texts in the mainMenuScreen

    public void InitText()
    {
        switch (GameController.language)
        {
            case 1:
                 menuTexts = menuTextsIn;
                len = 0; break;

            case 2:
                 menuTexts = menuTextsEs;
                len = 80;
                break;
             default:
                menuTexts = menuTextsIn;
                break;
        }
        Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
        Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);

        for (int i = 0; i < menuTexts.Length; i++)
        {
            textPtr[i] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            menuTexts[i], red);
        }

        textPtr[chosenOption] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                menuTexts[chosenOption], green);

        ChosenOption();

        for (int i = 0; i < menuTexts.Length; i++)
        {
            if (textPtr[i] == IntPtr.Zero)
                Environment.Exit(5);
        }
    }

    public void ChosenOption()
    {
        Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
        switch (chosenOption)
        {
            case 2:
            case 5:
                textPtr[8] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            menuTexts[chosenOption] + disp[GameController.language - 1], yellow);
                break;

            default:
                textPtr[8] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "", yellow);
                break;
        }
    }

    public int GetChosenOption()
    {
        return chosenOption + 1;
    }

    public bool GetExit()
    {
        return exitGame;

    }

    public void Draw()
    {
        InitText();
        hardware.DrawImage(bakcGround);
        hardware.DrawImage(imgChoseOption);
        for (short i = 0; i < textPtr.Length - 1; i++)
        {
            hardware.WriteText(textPtr[i], 70, (short)(100 + i * 50));
        }


        if (chosenOption < 8)
            hardware.WriteText(textPtr[8], 450, 550);
        hardware.UpdateScreen();
    }

    public override void Show()
    {
        audio.PlayMusic(0, -1);
        bakcGround.MoveTo(0, 0);
        spacePressed = false;
        exitGame = false;
        Draw();

        do
        {
            //Check input
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
            else if (Hardware.JoystickPressed(0))
                keyPressed = Hardware.KEY_SPACE;

            if (keyPressed == Hardware.KEY_UP && chosenOption > 0)
            {
                audio2.PlayWAV(0, 1, 0);
                
                chosenOption--;
                imgChoseOption.MoveTo((short)(470 + len), 
                    (short)(imgChoseOption.Y - 50));
                InitText();
                Draw();

            }
            else if (keyPressed == Hardware.KEY_DOWN && chosenOption < 7)
            {
                audio2.PlayWAV(0, 1, 0);
                
                chosenOption++;
                imgChoseOption.MoveTo((short)(470 + len), 
                    (short)(imgChoseOption.Y + 50));
                InitText();
                Draw();
            }

            else if (keyPressed == Hardware.KEY_SPACE && chosenOption == 7)
            {
                spacePressed = true;
                exitGame = true;
            }

            else if (keyPressed == Hardware.KEY_SPACE /*&& chosenOption == 0*/)
            {
                spacePressed = true;
            }
            
            Thread.Sleep(10);
            

        } while (spacePressed != true);
        audio.StopMusic();
    }
}
