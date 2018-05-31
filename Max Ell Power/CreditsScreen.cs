using System;
using System.Threading;
using Tao.Sdl;
/*
* This class willshow the credit screen
 */
class CreditsScreen : Screen
{
    Image bakcGround;
    Audio audio;
    Font font;
    string[] tasks;
    string[] agreements;
    string[] tasksIn = new string[] { "Development boss", "Team leader",
    "Programmers", "Analyst", "Beta Tester", "New technologies investigator",
        "Head of Systems", "Distributor"};
    string[] tasksEs = new string[] { "Jefe De Desarroyo", "Lider De Equipo",
    "Programadores", "Analista", "Beta Tester", "Investigador De Nuevas Tecnologias",
        "Jefe De Systemas", "Distribuidor"};
    string[] names = new string[] { "Marcos Cervantes Matamoros", "Cervantes Marcos",
    "MCM", "Cervantes Marcos", "Muglok - Deisuke", "Marcos Cervantes Matamoros",
        "Marcos Cervantes Matamoros", "Marcos CM"};
    string[] agreementsIn = new string[] {"Special thanks to all teachers that have" +
        " made possible the creation of ",
        "this game and creators of all free sprites, fonts and sounds to libre use.",
        "Without all of you this game cannot would have been possible." };
    string[] agreementsEs = new string[] {"Un agradecimiento especial a todos los " +
        "prefesores que han hecho posible la creacion",
        "  de este juego y a los creadores de los sprites, fuentes y sonidos gratuitos" +
        " de libre uso.",
        "Sin todos ustedes, este juego no podría haber sido posible." };
    IntPtr[] taksPtr = new IntPtr[9];
    IntPtr[] namesPtr = new IntPtr[9];
    IntPtr[] agreementsPtr = new IntPtr[3];
    bool spacePressed;

    public CreditsScreen(Hardware hardware) : base(hardware)
    {
        font = new Font("fonts/Nashville.ttf", 33);
        bakcGround = new Image("imgs/fondoNegro.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/Wistful-for-piano.mid");

        bakcGround.MoveTo(0, 0);

        InitText();
    }

    public void InitText()
    {
        switch (GameController.language)
        {
            case 1:
                tasks = tasksIn;
                agreements = agreementsIn;break;
            case 2:
                tasks = tasksEs;
                agreements = agreementsEs;break;
            default:
                tasks = tasksIn; break;
        }

        font = new Font("fonts/Nashville.ttf", 33);
        Sdl.SDL_Color gray = new Sdl.SDL_Color(125, 125, 125);
        Sdl.SDL_Color blue = new Sdl.SDL_Color(66, 125, 255);

        for (int i = 0; i < tasks.Length; i++)
        {
            taksPtr[i] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            tasks[i], gray);

            namesPtr[i] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
            names[i], gray);
        }

        font = new Font("fonts/Nashville.ttf", 26);

        for (int i = 0; i < agreementsPtr.Length; i++)
        {
            agreementsPtr[i] = SdlTtf.TTF_RenderText_Solid(font.GetFontType(), 
                agreements[i], blue);
        }

        for (int i = 0; i < tasks.Length; i++)
        {
            if (taksPtr[i] == IntPtr.Zero || namesPtr[i] == IntPtr.Zero)
                Environment.Exit(5);
        }
        for (int i = 0; i < 3; i++)
        {
            if (agreementsPtr[i] == IntPtr.Zero)
                Environment.Exit(5);
        }
       
    }

    public void Draw()
    {
        hardware.DrawImage(bakcGround);
        for (short i = 0; i < taksPtr.Length - 1; i++)
        {
            hardware.WriteText(taksPtr[i],
                (short)((GameController.SCREEN_WIDTH / 2) - (tasks[i].Length * 13) - 100)
                , (short)(75 + i * 50));

            hardware.WriteText(namesPtr[i],
                (short)((GameController.SCREEN_WIDTH / 2) - 50)
                , (short)(75 + i * 50));
        }
        for (int i = 0; i < 3; i++)
        {
            hardware.WriteText(agreementsPtr[i],
              (short)(195 - (agreements[i].Length / 2) + (35 * i)), (short)(525 + (50 * i)));
        }
        hardware.UpdateScreen();
    }

    public override void Show()
    {
        audio.PlayMusic(0, -1);
        bakcGround.MoveTo(0, 0);
        spacePressed = false;

        do
        {
            Draw();

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
