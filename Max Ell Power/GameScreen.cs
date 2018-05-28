using System;
using System.Collections.Generic;
using System.IO;
/*
*This screen will show the game screen on we will play the game
*/
public struct Scores
{
    public short num;
    public short score;
    public short jumps;
}
class GameScreen : Screen
{
    short jumps = 0;
    short score = 0;

    public static  List<Scores> scoreList = new List<Scores>();
    Map map;
    Platform[] platforms = new Platform[11];
    Wall[] bricks = new Wall[6];
    List<Enemy> Enemies = new List<Enemy>();
    
    Image level0;
    Audio audio;
    MainCharacter mainCharacter;
    Enemy enemy1, enemy2, enemy3;
    const ushort SHOT_INTERVAL = 200;
    const ushort DAMAGE_INTERVAL = 400;
    bool gameOver;
    int chosenPlayer;
    int keyPressed;
    float movement_increment;
    const float MAX_VERTICAL_SPEED = 12;
    const float VERTICAL_SPEED_DECREMENT = 0.93f;
    bool left, right, isFalling, isJumping;
    float verticalSpeed, horizontalSpeed;
    short oldX, oldY;
    short floorPosition = GameController.SCREEN_HEIGHT - 58;

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
        GameController.lastGame = 1;
        level0 = new Image("imgs/Map.png", 1200, 720);
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/Heroic-Deeds.mid");
        level0.MoveTo(0, 0);
        NewEnemy();
        Load();
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
        score += 50;
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
            mainCharacter.Fall(verticalSpeed <= 0 ? -verticalSpeed : verticalSpeed);
        else if (isJumping)
        {
            mainCharacter.MoveTo((short)(mainCharacter.X + horizontalSpeed),
                (short)(mainCharacter.Y + verticalSpeed));

            verticalSpeed += VERTICAL_SPEED_DECREMENT;
            if (verticalSpeed >= MAX_VERTICAL_SPEED)
                verticalSpeed = MAX_VERTICAL_SPEED;
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

            jumps++;
        }

        if (left && mainCharacter.X > 0)
            mainCharacter.X -= mainCharacter.STEP_LENGHT;

        if (right && mainCharacter.X < GameController.SCREEN_WIDTH -
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
        foreach (Weapon w in mainCharacter.Weapons)
            {
                switch (w.CurrentDirection)
                {
                    case MovableSprite.SpriteDirections.DOWN:
                        w.Y += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.LEFT:
                        w.X -= Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.LEFT_DOWN:
                        w.X -= Weapon.STEP_LENGTH;
                        w.Y += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.LEFT_UP:
                        w.X -= Weapon.STEP_LENGTH;
                        w.Y -= Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.RIGHT:
                        w.X += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.RIGHT_DOWN:
                        w.X += Weapon.STEP_LENGTH;
                        w.Y += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.RIGHT_UP:
                        w.X += Weapon.STEP_LENGTH;
                        w.Y -= Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.UP:
                        w.Y -= Weapon.STEP_LENGTH;
                        break;
                }
            }
    }

    public void CreatePlatforms()
    {
        platforms[0] = new Platform(1);
        platforms[0].SpriteImage.MoveTo(800, 485);
        platforms[1] = new Platform(1);
        platforms[1].SpriteImage.MoveTo(950, 400);
        platforms[2] = new Platform(1);
        platforms[2].SpriteImage.MoveTo(800, 310);
        platforms[3] = new Platform(1);
        platforms[3].SpriteImage.MoveTo(300, 200);

        for (int i = 4; i < platforms.Length; i++)
        {
            if (i < 7)
            {
                platforms[i] = new Platform(2);
                platforms[i].SpriteImage.MoveTo((short)(250 + (
                    (platforms[i].SPRITE_WIDTH - 50) * (i - 4))), 575);
            }
            else if (i < 10)
            {
                platforms[i] = new Platform(2);
                platforms[i].SpriteImage.MoveTo((short)(225 + (
                    (platforms[i].SPRITE_WIDTH - 50) * (i - 7))), 285);
            }
            else
            {
                platforms[i] = new Platform(2);
                platforms[i].SpriteImage.MoveTo((short)(40 + (
                    (platforms[i].SPRITE_WIDTH - 50) * (i - 10))), 125);
            }
        }
    }

    public void CreateWalls()
    {
        for (int i = 0; i < 3; i++)
        {
            bricks[i] = new Wall();
            bricks[i].SpriteImage.MoveTo(60,(short)((610) - 50 * i));
        }

        for (int i = 3; i < bricks.Length; i++)
        {
            bricks[i] = new Wall();
            bricks[i].SpriteImage.MoveTo(1100, (short)((610) - 50 * (i-3)));
        }
    }

    public void Load()
    {
        string name = "Score.txt";
        Scores scoreLine = new Scores();

        if (!File.Exists(name))
        {
            Console.WriteLine("File not found!");
        }
        else
        {
            try
            {
                StreamReader reader = new StreamReader(name);
                string line;
                do
                {
                     line = (reader.ReadLine());

                    if (line != null)
                    {
                        string[] parts = line.Split('-');
                        scoreLine.num = Convert.ToInt16(parts[0]);
                        scoreLine.score = Convert.ToInt16(parts[1]);
                        scoreLine.jumps = Convert.ToInt16(parts[2]);
                        scoreList.Add(scoreLine);
                    }
                } while (line != null);

                reader.Close();
                
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Path too long");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not accessible");
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oooops... " + e.Message);
            }
        }
    }

    public void Save()
    {
        string name = "Score.txt";

        if (!File.Exists(name))
        {
            Console.WriteLine("File not found!");
        }
        else
        {
            try
            {
                StreamWriter writer = new StreamWriter("Score.txt",true);
                writer.WriteLine((scoreList.Count + 1) + "-" + score + "-" + jumps);

                writer.Close();
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Path too long");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not accessible");
            }
            catch (IOException e)
            {
                Console.WriteLine("I/O error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oooops... " + e.Message);
            }
        }
    }


    public override void Show()
    {
        DateTime timeStampFromLastShot = DateTime.Now;
        DateTime timeStampFromLastScoreIncrement = DateTime.Now;
        DateTime timeStampFromLastDamage = DateTime.Now;

        CreatePlatforms();
        CreateWalls();

        audio.PlayMusic(0,-1);
        gameOver = false;
        
        isFalling = false;
        isJumping = false;
        verticalSpeed = 100.0f;
        horizontalSpeed = 0.0f;
        movement_increment = 3f + mainCharacter.STEP_LENGHT;


        

        do
        {
            if ((DateTime.Now - timeStampFromLastScoreIncrement).TotalMilliseconds 
                > 1000)
            {
                timeStampFromLastScoreIncrement = DateTime.Now;
                UpdatePoints();
            }
            //1.-Draw_EveryThing
            
            //TO DO
            hardware.ClearScreen();
            hardware.DrawImage(level0);

            mainCharacter.SpriteImage.MoveTo(mainCharacter.X,mainCharacter.Y);
            hardware.DrawImage(mainCharacter.SpriteImage);

            foreach (Weapon w in mainCharacter.Weapons)
                hardware.DrawImage(w.SpriteImage);


            for (int i = 0; i < platforms.Length; i++)
            {
                hardware.DrawImage(platforms[i].SpriteImage);
            }

            MoveEnemy();
            foreach (Enemy Enemy in Enemies)
            {
                Enemy.SpriteImage.MoveTo(Enemy.X, Enemy.Y);
                hardware.DrawImage(Enemy.SpriteImage);
            }

            foreach (Wall brick in bricks)
            {
                hardware.DrawImage(brick.SpriteImage);
            }
  
            hardware.UpdateScreen();

            //2.-Move_Character_from_keyboard_input
            oldX = mainCharacter.X;
            oldY = mainCharacter.Y;
            MoveCharacter();
            if (hardware.IsKeyPressed(Hardware.KEY_C))
            {
                if ((DateTime.Now - timeStampFromLastShot).TotalMilliseconds > SHOT_INTERVAL)
                {
                    timeStampFromLastShot = DateTime.Now;
                    mainCharacter.AddWeapon();
                }
            }

            //TO DO
            //3.-Move_Enemies_And_Objects
            MoveWeapon();
            //TO DO
            //4-.Check_Colisions_AndUpdateGameState
            isFalling = !isJumping;

            if (mainCharacter.Y >= floorPosition -
               mainCharacter.SPRITE_HEIGHT)
            {
                mainCharacter.MoveTo(mainCharacter.X, (short)
                    (floorPosition - mainCharacter.SPRITE_HEIGHT));
                isFalling = false;
                isJumping = false;
            }

            foreach (Platform platforms in platforms)
                if (mainCharacter.IsOver(platforms.SpriteImage))
                {
                    mainCharacter.MoveTo(mainCharacter.X, (short)(platforms.SpriteImage.Y -
                    mainCharacter.SPRITE_HEIGHT));
                    isFalling = false;
                    isJumping = false;
                }

            foreach (Wall brick in bricks)
            {
                if (mainCharacter.CollidesWithImage(brick.SpriteImage))
                {
                    mainCharacter.X = oldX;
                    mainCharacter.Y = oldY;
                    mainCharacter.MoveTo(mainCharacter.X, mainCharacter.Y);
                    isFalling = false;
                    isJumping = false;
                }
            }

            foreach (Enemy Enemy in Enemies)
                if (Enemy.Y >= floorPosition - Enemy.SPRITE_HEIGHT)
                {
                    Enemy.MoveTo(Enemy.X, (short)
                        (floorPosition - Enemy.SPRITE_HEIGHT));
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
        Save();
    }
}
