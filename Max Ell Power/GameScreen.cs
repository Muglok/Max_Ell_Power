using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    /*
     *This screen will show the game screen on we will play the game
     */
    class GameScreen : Screen
    {
        Image level0, character;
        Audio audio;
        bool gameOver;
        MainCharacter mainCharacter;
        int keyPressed;

        public GameScreen(Hardware hardware) : base(hardware)
        {
            level0 = new Image("imgs/Map.png",1200,720);
            character = new Image("imgs/characterRightMini.png", 60,88);
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("sound/Heroic-Deeds.mid");
            mainCharacter = new MainCharacter();
            level0.MoveTo(0, 0);
            mainCharacter.X = 450;
            mainCharacter.Y = 570;
            mainCharacter.X += 200;
            character.MoveTo(mainCharacter.X, mainCharacter.Y);
        }

        public void ChosenPlayer()
        {
            //TO DO
        }

        public void DecreaseLives()
        {
            //TO DO
        }

        public void NewEnemy()
        {
            //TO DO
        }

        public void MoveEnemy()
        {
            //TO DO
        }

        public void UpdatePoints()
        {
            //TO DO
        }

        public void InitText()
        {
            //TO DO
        }

        public void MoveCharacter()
        {
            keyPressed = hardware.KeyPressed();
            if (Hardware.JoystickMovedLeft() ||
                hardware.IsKeyPressed(Hardware.KEY_LEFT))
                mainCharacter.X -= MainCharacter.STEP_LENGHT;


            else if (Hardware.JoystickMovedRight() ||
                hardware.IsKeyPressed(Hardware.KEY_RIGHT))
                mainCharacter.X += MainCharacter.STEP_LENGHT;

            else if (Hardware.JoystickPressed(1))
                keyPressed = Hardware.KEY_ESC;
        }

        public void MoveWeapon()
        {
            //TO DO
        }

        public override void Show()
        {
            audio.PlayMusic(0,-1);
            gameOver = false;
            do
            {
                

                //1.-Draw_EveryThing
                //TO DO
                hardware.DrawImage(level0);
                hardware.DrawImage(character);
                hardware.UpdateScreen();

                MoveCharacter();

                //2.-Move_Character_from_keyboard_input
                //TO DO
                //3.-Move_Enemies_And_Objects
                //TO DO
                //4-.Check_Colisions_AndUpdateGameState
                //TO DO
                //5.-Puse_Game
                //TO DO
                if (hardware.IsKeyPressed(Hardware.KEY_ESC) ||
                    keyPressed == Hardware.KEY_ESC)
                {
                    gameOver = true;
                }
               //MoveCharacter();
                character.MoveTo(mainCharacter.X, mainCharacter.Y);


            } while (!gameOver);
            audio.StopMusic();
        }

    }
}
