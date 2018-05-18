
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
        do
        {
            //1.-Draw_EveryThing
            //TO DO
            hardware.DrawImage(level0);
            MoveCharacter();

            /* hardware.DrawSprite(mainCharacter.SpriteImage,
                 (short)(138 - GameController.SCREEN_WIDTH),
                 (short)(129 - GameController.SCREEN_HEIGHT),
                 20, 20,
                 Sprite.SPRITE_WIDTH, Sprite.SPRITE_HEIGHT);*/

           /* hardware.DrawSprite(mainCharacter.SpriteImage, (short)(character.X - level.XMap), (short)(character.Y - level.YMap),
                character.SpriteX, character.SpriteY, Sprite.SPRITE_WIDTH, Sprite.SPRITE_HEIGHT);*/

            mainCharacter.SpriteImage.MoveTo(mainCharacter.X,mainCharacter.Y);
            hardware.DrawImage(mainCharacter.SpriteImage);
            hardware.UpdateScreen();

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
            mainCharacter.MoveTo(mainCharacter.X, mainCharacter.Y);


        } while (!gameOver);
        audio.StopMusic();
    }

}
