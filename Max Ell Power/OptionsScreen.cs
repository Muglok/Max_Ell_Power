/*
 *This screen wil manage the options of the game 
 */
using System.Threading;
class OptionsScreen : Screen
{
    Image bakcGround;
    Audio audio;
    Font font;
    bool spacePressed;

    public OptionsScreen(Hardware hardware) : base(hardware)
    {
        font = new Font("fonts/Nashville.ttf", 33);
        bakcGround = new Image("imgs/Options.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/adagio-for-strings.mid");
        bakcGround.MoveTo(0, 0);
    }

    public override void Show()
    {
        audio.PlayMusic(0, -1);
        spacePressed = false;

        hardware.DrawImage(bakcGround);
        hardware.UpdateScreen();

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

            Thread.Sleep(10);
        } while (spacePressed != true);
        audio.StopMusic();
    }
}

