using System.Collections.Generic;
/*
*This screen will show the game screen on we will play the game
*/
class GameScreen : Screen
{
    List<Enemy> Enemies = new List<Enemy>();
    Image level0;
    Audio audio;
    MainCharacter mainCharacter;
    Enemy enemy1, enemy2, enemy3;
    bool gameOver;
    int chosenPlayer;
    int keyPressed;
    float movement_increment;
    const float MAX_VERTICAL_SPEED = 9.5f;
    const float VERTICAL_SPEED_DECREMENT = 0.93f;
    bool left, right, isFalling, isJumping;
    float verticalSpeed, horizontalSpeed;
    short oldX, oldY;
    short floorPosition = GameController.SCREEN_HEIGHT - 58;

    Image brick;
                

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
                        (short) (floorPosition - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 2:
                    mainCharacter = new Frog();
                    mainCharacter.MoveTo(450,
                        (short)(floorPosition - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 3:
                    mainCharacter = new Soldier();
                    mainCharacter.MoveTo(450,
                        (short)(floorPosition - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 4:
                    mainCharacter = new SpecialAgent();
                    mainCharacter.MoveTo(450,
                        (short)(floorPosition - mainCharacter.SPRITE_HEIGHT));
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
        NewEnemy();

        brick = new Image("imgs/brick.png", 50, 50);
        brick.MoveTo(650,635);
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

        Enemies.Add(enemy1);
        Enemies.Add(enemy2);
        Enemies.Add(enemy3);
    }

    public void MoveEnemy()
    {
        foreach (Enemy Enemy in Enemies)
        {
            Enemy.Move(mainCharacter);
        }
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
        
        left = Hardware.JoystickMovedLeft() ||
            hardware.IsKeyPressed(Hardware.KEY_LEFT);
        right = Hardware.JoystickMovedRight() ||
            hardware.IsKeyPressed(Hardware.KEY_RIGHT);

        if (isFalling)
            mainCharacter.Fall();
        else if (isJumping)
        {
            mainCharacter.MoveTo((short)(mainCharacter.X + horizontalSpeed),
                (short)(mainCharacter.Y + verticalSpeed));

            verticalSpeed += VERTICAL_SPEED_DECREMENT;
            if (verticalSpeed >= MAX_VERTICAL_SPEED)
                verticalSpeed = MAX_VERTICAL_SPEED;
            mainCharacter.Fall();
        }

        else if (hardware.IsKeyPressed(Hardware.KEY_SPACE) || 
            Hardware.JoystickPressed(0))
        {
            isJumping = true;
            verticalSpeed = -1 * MAX_VERTICAL_SPEED;
            horizontalSpeed = left ? -1 * movement_increment : right ? +1 *
                movement_increment : 0.0f;
            mainCharacter.MoveTo((short)(mainCharacter.X + horizontalSpeed),
                (short)(mainCharacter.Y + verticalSpeed));

        }

        else if (left && mainCharacter.X > 0)
            mainCharacter.X -= mainCharacter.STEP_LENGHT;

        else if (right && mainCharacter.X < GameController.SCREEN_WIDTH -
                mainCharacter.SPRITE_WIDTH)
                mainCharacter.X += mainCharacter.STEP_LENGHT;

        else if (Hardware.JoystickPressed(1))
            keyPressed = Hardware.KEY_ESC;

        if (left && !isFalling)
            mainCharacter.Animate(MovableSprite.SpriteDirections.LEFT);
        else if (right && !isFalling)
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
        
        isFalling = false;
        isJumping = false;
        verticalSpeed = 100.0f;
        horizontalSpeed = 0.0f;
        //Wall[] bricks = new Wall[3];

        /*for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i] = new Wall();
            bricks[i].SpriteImage.MoveTo((short)(50 * i), (short)(300 - (50*i)));
        }*/

        movement_increment = 2f + mainCharacter.STEP_LENGHT;
        do
        {
            //1.-Draw_EveryThing
            
            //TO DO
            hardware.ClearScreen();
            hardware.DrawImage(level0);

            mainCharacter.SpriteImage.MoveTo(mainCharacter.X,mainCharacter.Y);
            hardware.DrawImage(mainCharacter.SpriteImage);

            hardware.DrawImage(brick);

            MoveEnemy();
            foreach (Enemy Enemy in Enemies)
            {
                Enemy.SpriteImage.MoveTo(Enemy.X, Enemy.Y);
                hardware.DrawImage(Enemy.SpriteImage);
            }

            /*foreach (Wall brick in bricks)
            {
                hardware.DrawImage(brick.SpriteImage);
            }*/
  
            hardware.UpdateScreen();

            //2.-Move_Character_from_keyboard_input
            oldX = mainCharacter.X;
            oldY = mainCharacter.Y;
            MoveCharacter();

            //TO DO
            //3.-Move_Enemies_And_Objects
            //TO DO
            //4-.Check_Colisions_AndUpdateGameState
            isFalling = !isJumping;


            if(mainCharacter.Y >= floorPosition -
                mainCharacter.SPRITE_HEIGHT)
            {
                mainCharacter.MoveTo(mainCharacter.X, (short)
                    (floorPosition - mainCharacter.SPRITE_HEIGHT));
                isFalling = false;
                isJumping = false;
            }

            if (mainCharacter.CollidesWithImage(brick))
            {
                mainCharacter.X = oldX;
                mainCharacter.Y = oldY;
            }

            if (mainCharacter.IsOver(brick))
            {
                mainCharacter.MoveTo(mainCharacter.Y, (short)(brick.Y -
                mainCharacter.SPRITE_HEIGHT));
                isFalling = false;
                isJumping = false;
            }

            foreach (Enemy Enemy in Enemies)
            {
                if (Enemy.Y >= floorPosition - Enemy.SPRITE_HEIGHT)
                {
                    Enemy.MoveTo(Enemy.X, (short)
                        (floorPosition - Enemy.SPRITE_HEIGHT));
                }
            }

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
