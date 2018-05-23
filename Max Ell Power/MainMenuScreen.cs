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
    IntPtr textPlay, textContinue, textHordeMode, textRanking, textHelp,
        textOptions, textCredits, textExit, textAux;
    int chosenOption = 1;
    bool spacePressed, exitGame;

    public MainMenuScreen(Hardware hardware) : base(hardware)
    {
        font = new Font("fonts/Abberancy.ttf", 45);
        bakcGround = new Image("imgs/Test.png", 1200,720);
        imgChoseOption = new Image("imgs/choose_player.png",48,48);
        audio = new Audio(44100,2,4096);
        audio2 = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/song_a.mid");
        audio2.AddWAV("sound/fire.Wav");

        bakcGround.MoveTo(0,0);
        imgChoseOption.MoveTo(470, 105);

        InitText();
    }

    //This method initialize the diferent texts in the mainMenuScreen

    public void InitText()
    {
        Sdl.SDL_Color red = new Sdl.SDL_Color(255,0,0);
        Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
           
        textPlay = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Play Level", red);
        textContinue = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Continue Last Game", red);
        textHordeMode = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Horde Mode", red);
        textRanking = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "ScoreBoard", red);
        textHelp = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Help", red);
        textOptions = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Options", red);
        textCredits = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Credits", red);
        textExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Exit Game", red);

        if(chosenOption == 1)
                textPlay = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                "Play Level", green);
        if (chosenOption == 2)
            textContinue = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Continue Last Game", green);
        else if (chosenOption == 3)
            textHordeMode = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Horde Mode", green);
        else if (chosenOption == 4)
            textRanking = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "ScoreBoard", green);
        else if (chosenOption == 5)
            textHelp = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Help", green);
        else if (chosenOption == 6)
            textOptions = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Options", green);
        else if (chosenOption == 7)
            textCredits = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Credits", green);
        else if (chosenOption == 8)
            textExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Exit Game", green);

        ChosenOption();

        if (textPlay == IntPtr.Zero || textContinue == IntPtr.Zero ||
            textHordeMode == IntPtr.Zero || textRanking == IntPtr.Zero
            || textHelp == IntPtr.Zero || textOptions == IntPtr.Zero
            || textCredits == IntPtr.Zero || textExit == IntPtr.Zero)
            Environment.Exit(5);
    }

    public void ChosenOption()
    {
        Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
        switch (chosenOption)
        {
            /*case 1:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Play Level not available yet", yellow);
                break;*/
            case 2:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Continue Last Game not available yet", yellow);
                break;
            case 3:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Horde Mode not available yet", yellow);
                break;
            case 4:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "ScoreBoard not available yet", yellow);
                break;
            case 5:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Help not available yet", yellow);
                break;
            case 6:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Options not available yet", yellow);
                break;
            case 7:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Credits not available yet", yellow);
                break;
            case 8:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "Exit Game not available yet", yellow);
                break;

            default:
                textAux = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            "", yellow);
                break;
        }
    }

    public int GetChosenOption()
    {
        return chosenOption;
    }

    public bool GetExit()
    {
        return exitGame;
    }

    public override void Show()
    {
        audio.PlayMusic(0,-1);
        bakcGround.MoveTo(0, 0);
        spacePressed = false;
        exitGame = false;

        do
        {
            hardware.DrawImage(bakcGround);
            hardware.DrawImage(imgChoseOption);
            hardware.WriteText(textPlay, 70,100);
            hardware.WriteText(textContinue, 70, 150);
            hardware.WriteText(textHordeMode, 70, 200);
            hardware.WriteText(textRanking, 70, 250);
            hardware.WriteText(textHelp, 70, 300);
            hardware.WriteText(textOptions, 70, 350);
            hardware.WriteText(textCredits, 70, 400);
            hardware.WriteText(textExit, 70, 450);

            if (chosenOption < 8)
                hardware.WriteText(textAux, 450, 550);
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
            else if (Hardware.JoystickPressed(0))
                keyPressed = Hardware.KEY_SPACE;

            if (keyPressed == Hardware.KEY_UP && chosenOption > 1)
            {
                audio2.PlayWAV(0, 1, 0);
                chosenOption--;
                imgChoseOption.MoveTo(470, (short)(imgChoseOption.Y - 50));
            }
            else if (keyPressed == Hardware.KEY_DOWN && chosenOption < 8)
            {
                audio2.PlayWAV(0, 1, 0);
                chosenOption++;
                imgChoseOption.MoveTo(470, (short)(imgChoseOption.Y + 50));
            }

            else if (keyPressed == Hardware.KEY_SPACE && chosenOption == 1)
            {
                spacePressed = true;
            }

            else if (keyPressed == Hardware.KEY_SPACE && chosenOption == 8)
            {
                spacePressed = true;
                exitGame = true;
            }
            Thread.Sleep(10);
            InitText();

        } while (spacePressed != true);
        audio.StopMusic();
    }
}
