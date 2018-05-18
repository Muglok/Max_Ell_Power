using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    /*
     * This class will show a screen in what you will be able to select one of 
     * the diferent main characters
     */
    class PlayerSelectScreen : Screen
    {

        private Image backGround,downArrow;
        private int[] characterXPositions;
        private int[] characterYPositions;
        private int chosenPlayer;
        private Audio backgroundMusic;
        private Audio arrowSound;

        public PlayerSelectScreen(Hardware hardware) : base(hardware)
        {
            backgroundMusic = new Audio(44100, 2, 4096);
            backgroundMusic.AddMusic("sound/Weird-Xmas.mid");
            arrowSound = new Audio(44100, 2, 4096);
            arrowSound.AddWAV("sound/fire.wav");

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

            chosenPlayer = 3;
            backGround = new Image
                (@"imgs\PlayerSelectScreenWithCharacters.png",1280,720);
            downArrow = new Image
                (@"imgs\Arrow2MiniDown.png", 57, 48);
            downArrow.X = (short)characterXPositions[chosenPlayer];
            downArrow.Y = (short)characterYPositions[chosenPlayer];
        }

        public void Show()
        {
            backgroundMusic.PlayMusic(0, -1);
            int keyPressed;
            hardware.ClearScreen();
            hardware.DrawImage(backGround);
            hardware.DrawImage(downArrow);
            hardware.UpdateScreen();

            do
            {
                keyPressed = hardware.KeyPressed();

                if(keyPressed == Hardware.KEY_RIGHT ||
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
}
