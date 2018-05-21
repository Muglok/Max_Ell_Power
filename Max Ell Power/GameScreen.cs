
/*
*This screen will show the game screen on we will play the game
*/
class GameScreen : Screen
{
    Image level0;
    Audio audio;
    bool gameOver;
    MainCharacter mainCharacter;
    int chosenPlayer;
    int keyPressed;
    Enemy enemy1, enemy2, enemy3;

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
                    mainCharacter.MoveTo(450, 
                        (short) (666 - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 2:
                    mainCharacter = new Frog();
                    mainCharacter.MoveTo(450,
                        (short)(666 - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 3:
                    mainCharacter = new Soldier();
                    mainCharacter.MoveTo(450,
                        (short)(666 - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 4:
                    mainCharacter = new SpecialAgent();
                    mainCharacter.MoveTo(450,
                        (short)(666 - mainCharacter.SPRITE_HEIGHT));
                    break;
            }
        }
    }

    public GameScreen(Hardware hardware) : base(hardware)
    {
        level0 = new Image("imgs/Map.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/Heroic-Deeds.mid");
        level0.MoveTo(0, 0);
    }

    public void DecreaseLives()
    {
        //TO DO
    }

    public void NewEnemy()
    {
        //TO DO
        enemy1 = new AerialEnemy();
        enemy1.MoveTo(600,
                        (short)(200 - enemy1.SPRITE_HEIGHT));
       enemy2 = new JumpEnemy();
        enemy2.MoveTo(85,
                        (short)(666 - enemy2.SPRITE_HEIGHT));
        enemy3 = new LandEnemy();
        enemy3.MoveTo(700,
                        (short)(666 - enemy3.SPRITE_HEIGHT));
    }

    public void MoveEnemy()
    {
        short oldY;

        oldY = enemy1.Y;
        enemy1.Move(mainCharacter);
        if (enemy1.Y > 666 - (enemy1.SPRITE_HEIGHT))
            enemy1.Y = oldY;

        oldY = enemy2.Y;
        enemy2.Move(mainCharacter);
        if (enemy2.Y > 470)
            enemy2.Y = oldY;

        oldY = enemy3.Y;
        enemy3.Move(mainCharacter);
        if (enemy3.Y > 666 - (enemy3.SPRITE_HEIGHT))
            enemy3.Y = oldY;

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

        bool left = Hardware.JoystickMovedLeft() ||
            hardware.IsKeyPressed(Hardware.KEY_LEFT);
        bool right = Hardware.JoystickMovedRight() ||
            hardware.IsKeyPressed(Hardware.KEY_RIGHT);

        if (left)
            if(mainCharacter.X > 0)
            mainCharacter.X -= mainCharacter.STEP_LENGHT;

        if (right)
            if (mainCharacter.X < GameController.SCREEN_WIDTH - 
                mainCharacter.SPRITE_WIDTH)
                mainCharacter.X += mainCharacter.STEP_LENGHT;

        if (Hardware.JoystickPressed(1))
            keyPressed = Hardware.KEY_ESC;

        if (left)
            mainCharacter.Animate(MovableSprite.SpriteDirections.LEFT);
        else if (right)
            mainCharacter.Animate(MovableSprite.SpriteDirections.RIGHT);
    }

    public void MoveWeapon()
    {
        //TO DO
    }

    public override void Show()
    {
        audio.PlayMusic(0,-1);
        gameOver = false;
        NewEnemy();
        do
        {
            //1.-Draw_EveryThing
            //TO DO
            hardware.ClearScreen();
            hardware.DrawImage(level0);
            
            mainCharacter.SpriteImage.MoveTo(mainCharacter.X,mainCharacter.Y);
            hardware.DrawImage(mainCharacter.SpriteImage);

            MoveEnemy();
            enemy1.SpriteImage.MoveTo(enemy1.X, enemy1.Y);
            hardware.DrawImage(enemy1.SpriteImage);

            enemy2.SpriteImage.MoveTo(enemy2.X, enemy2.Y);
            hardware.DrawImage(enemy2.SpriteImage);

            enemy3.SpriteImage.MoveTo(enemy3.X, enemy3.Y);
            hardware.DrawImage(enemy3.SpriteImage);

            hardware.UpdateScreen();

            //2.-Move_Character_from_keyboard_input
            MoveCharacter();

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

        } while (!gameOver);
        audio.StopMusic();
    }

}
