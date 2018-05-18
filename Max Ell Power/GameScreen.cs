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
        int chosenPlayer;
        int keyPressed;

        public GameScreen(Hardware hardware) : base(hardware)
        {
            level0 = new Image("imgs/Map.png", 1200, 720);
            audio = new Audio(44100, 2, 4096);
            audio.AddMusic("sound/Heroic-Deeds.mid");
            level0.MoveTo(0, 0);
        }

        public int ChosenPlayer
        {
            get { return chosenPlayer; }

            set
            {
                if (value >= 1 || value <= 4)
                    chosenPlayer = value;
                switch (value)
                {
                    case 1:
                        mainCharacter = new Bear();
                        break;
                    case 2:
                        mainCharacter = new Frog();
                        break;
                    case 3:
                        mainCharacter = new Soldier();
                        break;
                    case 4:
                        mainCharacter = new SpecialAgent();
                        break;
                }
                mainCharacter.MoveTo(450, 570);
            }
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
                if(mainCharacter.X > 0)
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
