using System;
using System.Threading;
using Tao.Sdl;

class HelpScreen : Screen
{
    Image bakcGround;
    Audio audio;
    Font font;
    bool spacePressed;
    string[] texts;
    string[] textsIn = new string[] {"Use arrows to move in the menus and move the " 
        + "character"
    ,"Space or 'A' button to acept and jump in the game", "Escape key or 'B' "
        + "button to exit"};
    string[] textsEs = new string[] {"Usa las flechas para moverte por los menus " +
        "y mover al personaje"
    ,"Usa el Espacio o el boton A para aceptar o saltar",
        "Tecla Escape o boton B para salir"};
    short num;
    IntPtr[] textsPtr = new IntPtr[3];

    public HelpScreen(Hardware hardware) : base(hardware)
    {
        font = new Font("fonts/Nashville.ttf", 33);
        bakcGround = new Image("imgs/Help.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/Wistful-for-piano.mid");
        bakcGround.MoveTo(0, 0);
    }

    public void InitText()
    {
        switch (num)
        {
            case 1:
                texts = textsIn; break;
            case 2:
                texts = textsEs;break;
            default:
                texts = textsIn;
                break;
        }
        Sdl.SDL_Color black = new Sdl.SDL_Color(255, 255, 0);

        for (int i = 0; i < textsPtr.Length; i++)
        {
            textsPtr[i] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            texts[i], black);

        }

        for (int i = 0; i < 3; i++)
        {
            if (textsPtr[i] == IntPtr.Zero)
                Environment.Exit(5);
        }
    }

    public void Draw()
    {
        InitText();
        hardware.DrawImage(bakcGround);

        hardware.WriteText(textsPtr[0], 320, 125);
        hardware.WriteText(textsPtr[1], 415, 375);
        hardware.WriteText(textsPtr[2], 485, 585);

        hardware.UpdateScreen();
    }

    public override void Show()
    {
        num = GameController.language;
        audio.PlayMusic(0, -1);
        spacePressed = false;
        Draw();
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

            if (keyPressed == Hardware.KEY_SPACE ||
                keyPressed == Hardware.KEY_ESC)
            {
                spacePressed = true;
            }
        } while (spacePressed != true);
        audio.StopMusic();
    }
}
