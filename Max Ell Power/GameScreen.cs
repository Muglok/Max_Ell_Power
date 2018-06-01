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

    public static  List<Scores> scoreList;
    Map map;
    List<Enemy> Enemies = new List<Enemy>();
    
    Audio audio;
    MainCharacter mainCharacter;
    const ushort SHOT_INTERVAL = 300;
    const ushort DAMAGE_INTERVAL = 450;
    bool gameOver;
    int chosenPlayer;
    int keyPressed;
    float movement_increment;
    const float MAX_VERTICAL_SPEED = 13;
    const float VERTICAL_SPEED_DECREMENT = 1.33f;
    bool left, right, isFalling, isJumping;
    float verticalSpeed, horizontalSpeed;
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
                    mainCharacter.MoveTo(map.Start.X, 
                        (short) ((map.Start.Y)- mainCharacter.SPRITE_HEIGHT));
                    break;
                case 2:
                    mainCharacter = new Frog();
                    mainCharacter.MoveTo(map.Start.X,
                        (short)(map.Start.Y - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 3:
                    mainCharacter = new Soldier();
                    mainCharacter.MoveTo(map.Start.X,
                        (short)(map.Start.Y - mainCharacter.SPRITE_HEIGHT));
                    break;
                case 4:
                    mainCharacter = new SpecialAgent();
                    mainCharacter.MoveTo(map.Start.X,
                        (short)(map.Start.Y - mainCharacter.SPRITE_HEIGHT));
                    break;
            }
        }
    }

    public GameScreen(Hardware hardware) : base(hardware)
    {
        GameController.lastGame = 1;
        audio = new Audio(44100, 2, 4096);
        audio.AddMusic("sound/Heroic-Deeds.mid");
        map = new Map("Map/map1.txt");
        scoreList = new List<Scores>();
        Load();
    }

    public void DecreaseLives()
    {
        //TO DO
    }

    public void MoveEnemy(ref DateTime timestamp)
    {
        foreach (Enemy Enemy in map.Enemy)
        {
            short oldX = Enemy.X;
            short oldY = Enemy.Y;
            Enemy.Move(mainCharacter);
            if (Enemy.CollidesWith(map.Walls))
            {
                Enemy.X = oldX;
                Enemy.Y = oldY;
            }
            else if (Enemy.CollidesWithImage(mainCharacter.SpriteImage))
            {
                Enemy.X = oldX;
                Enemy.Y = oldY;
                if ((DateTime.Now - timestamp).TotalMilliseconds > DAMAGE_INTERVAL)
                {
                    mainCharacter.Lives -= Enemy.DAMAGE;
                    timestamp = DateTime.Now;
                }
            }
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

            if (mainCharacter.CurrentDirection == MovableSprite.SpriteDirections.LEFT
                && map.XMap > 0)
                map.XMap += (short)horizontalSpeed;
            else if (mainCharacter.CurrentDirection == MovableSprite.SpriteDirections.RIGHT
                && map.XMap > 0)
                map.XMap += (short)horizontalSpeed;

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

        if (left && mainCharacter.X > 10)
        {
            mainCharacter.X -= mainCharacter.STEP_LENGHT;
            if (map.XMap > 0)
                map.XMap -= mainCharacter.STEP_LENGHT;
        }

        if (right && mainCharacter.X < map.Width -
                mainCharacter.SPRITE_WIDTH -10)
        {
            mainCharacter.X += mainCharacter.STEP_LENGHT;
            if (map.XMap < map.Width - GameController.SCREEN_WIDTH)
                map.XMap += mainCharacter.STEP_LENGHT;
        }

        if (mainCharacter.Y - map.YMap < 110)
        {
                map.YMap -= 6;
        }

        if (mainCharacter.Y - map.YMap > 110)
        {
            map.YMap += 6;
        }

        if (map.XMap < 0)
            map.XMap = 0;
        else if (map.XMap > map.Width - GameController.SCREEN_WIDTH)
            map.XMap = (short)(map.Width - GameController.SCREEN_WIDTH);
        if (map.YMap < 0)
            map.YMap = 0;
        else if (map.YMap > map.Height - GameController.SCREEN_HEIGHT)
            map.YMap = (short)(map.Height - GameController.SCREEN_HEIGHT);
        if (mainCharacter.X < 0)
            mainCharacter.X = 0;
        else if (mainCharacter.X > map.Width - mainCharacter.SPRITE_WIDTH)
            mainCharacter.X = (short)(map.Width - mainCharacter.SPRITE_WIDTH);
        if (mainCharacter.Y - map.YMap < 0)
            mainCharacter.Y = 0;
        else if (mainCharacter.Y > map.Height - mainCharacter.SPRITE_HEIGHT)
            mainCharacter.Y = (short)(map.Height - mainCharacter.SPRITE_HEIGHT);

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
                        w.SpriteImage.Y += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.LEFT:
                        w.SpriteImage.X -= Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.LEFT_DOWN:
                        w.SpriteImage.X -= Weapon.STEP_LENGTH;
                        w.SpriteImage.Y += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.LEFT_UP:
                        w.SpriteImage.X -= Weapon.STEP_LENGTH;
                        w.SpriteImage.Y -= Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.RIGHT:
                        w.SpriteImage.X += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.RIGHT_DOWN:
                        w.SpriteImage.X += Weapon.STEP_LENGTH;
                        w.SpriteImage.Y += Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.RIGHT_UP:
                        w.SpriteImage.X += Weapon.STEP_LENGTH;
                        w.SpriteImage.Y -= Weapon.STEP_LENGTH;
                        break;
                    case MovableSprite.SpriteDirections.UP:
                        w.SpriteImage.Y -= Weapon.STEP_LENGTH;
                        break;
                }
            
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

                    if (line != null && line != "")
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
                Catch("Path too long");

            }
            catch (IOException e)
            {
                Catch("I/O error: " + e.Message);
            }
            catch (Exception e)
            {
                Catch("Oooops... " + e.Message);
            }
        }
    }

    public void Save()
    {
        string name = "Score.txt";
        Scores scoreLine = new Scores();

        try
        {
            scoreLine.num = Convert.ToInt16((scoreList.Count + 1));
            scoreLine.score = Convert.ToInt16(score);
            scoreLine.jumps = Convert.ToInt16(jumps);

            StreamWriter writer = new StreamWriter(name,true);
            writer.WriteLine((scoreList.Count + 1) + "-" + score + "-" + jumps);

            writer.Close();
            scoreList.Add(scoreLine);
        }
        catch (PathTooLongException)
        {
             Catch("Path too long");

        }
        catch (IOException e)
        {
            Catch("I/O error: " + e.Message);
        }
        catch (Exception e)
        {
            Catch("Oooops... " + e.Message);
        }
    }

    public void Catch(string error)
    {
        try
        {
            StreamWriter writer = new StreamWriter("LogError.txt", true);
            writer.WriteLine(error);
            writer.Close();
        }
        catch (Exception) { }
    }

    public override void Show()
    {
        short oldX, oldY, oldXMap, oldYMap;
        DateTime timeStampFromLastShot = DateTime.Now;
        DateTime timeStampFromLastScoreIncrement = DateTime.Now;
        DateTime timeStampFromLastDamage = DateTime.Now;
        map.BackGround.MoveTo(0, 0);

        audio.PlayMusic(0,-1);
        gameOver = false;

        isFalling = false;
        isJumping = true;
        verticalSpeed = 100.0f;
        horizontalSpeed = 0.0f;
        movement_increment = 1.2f + mainCharacter.STEP_LENGHT;

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
            
            hardware.DrawImageMap(map.BackGround, map.XMap, map.YMap);

            foreach (Wall wall in map.Walls)
                 hardware.DrawImageMap(wall.SpriteImage, map.XMap, map.YMap);
            foreach (Platform platform in map.Platforms)
                 hardware.DrawImageMap(platform.SpriteImage, map.XMap, map.YMap);
            foreach (DangerousFloor spikes in map.DangerousFloors)
                hardware.DrawImageMap(spikes.SpriteImage, map.XMap, map.YMap);
            foreach (Ladder ladder in map.Ladders)
                hardware.DrawImageMap(ladder.SpriteImage, map.XMap, map.YMap);
            foreach (Enemy enemy in map.Enemy)
            {
                enemy.SpriteImage.MoveTo(enemy.X, enemy.Y);
                hardware.DrawImageMap(enemy.SpriteImage, map.XMap, map.YMap);
            }

            mainCharacter.SpriteImage.MoveTo(mainCharacter.X,mainCharacter.Y);
            hardware.DrawImageMap(mainCharacter.SpriteImage, map.XMap, map.YMap);

            foreach (Weapon w in mainCharacter.Weapons)
                hardware.DrawImageMap(w.SpriteImage, map.XMap, map.YMap);


            foreach (Enemy Enemy in Enemies)
            {
                Enemy.SpriteImage.MoveTo(Enemy.X, Enemy.Y);
                hardware.DrawImageMap(Enemy.SpriteImage, map.XMap, map.YMap);
            }
  
            hardware.UpdateScreen();

            //2.-Move_Character_from_keyboard_input
            oldX = mainCharacter.X;
            oldY = mainCharacter.Y;
            oldXMap = map.XMap;
            oldYMap = map.YMap;
            MoveCharacter();
            if (hardware.IsKeyPressed(Hardware.KEY_C) ||
                Hardware.JoystickPressed(2))
            {
                if ((DateTime.Now - timeStampFromLastShot).TotalMilliseconds 
                    > SHOT_INTERVAL)
                {
                    timeStampFromLastShot = DateTime.Now;
                    mainCharacter.AddWeapon();
                }
                if(mainCharacter.Weapons.Count > 7)
                    mainCharacter.RemoveWeapon(0);
            }

            //TO DO
            //3.-Move_Enemies_And_Objects
            MoveEnemy(ref timeStampFromLastDamage);
            MoveWeapon();
            //TO DO
            //4-.Check_Colisions_AndUpdateGameState
            isFalling = !isJumping;
            map.CollideWeaponsWithWalls(mainCharacter);
            short points = map.CollideWeaponsWithEnemies(mainCharacter);
            if (points > 0)
            {
                mainCharacter.Points += points;
            }

            foreach (Platform platforms in map.Platforms)
                if (mainCharacter.IsOver(platforms.SpriteImage))
                {
                    mainCharacter.MoveTo(mainCharacter.X, (short)
                        (platforms.SpriteImage.Y - mainCharacter.SPRITE_HEIGHT));
                    isFalling = false;
                    isJumping = false;
                }

            foreach (Wall walls in map.Walls)
            {
                if (mainCharacter.IsOver(walls.SpriteImage))
                {
                    mainCharacter.MoveTo(mainCharacter.X, (short)
                        (walls.SpriteImage.Y - mainCharacter.SPRITE_HEIGHT));
                    isFalling = false;
                    isJumping = false;
                }

                else if (mainCharacter.CollidesWithImage(walls.SpriteImage))
                {
                    mainCharacter.X = oldX;
                    mainCharacter.Y = oldY;
                    map.XMap = oldXMap;
                    map.YMap = oldYMap;
                    mainCharacter.MoveTo(mainCharacter.X, mainCharacter.Y);
                    isFalling = false;
                    isJumping = false;
                }
            }

            foreach (DangerousFloor spikes in map.DangerousFloors)
                if (mainCharacter.CollidesWithImage(spikes.SpriteImage))
                {
                    mainCharacter.Lives = 0;
                }

            foreach (Ladder ladder in map.Ladders)
                if (mainCharacter.CollidesWithImage(ladder.SpriteImage) 
                    && hardware.IsKeyPressed(Hardware.KEY_UP))
                {
                    mainCharacter.Y -= 2;
                    isFalling = false;
                }


            foreach (Enemy Enemy in Enemies)
            {
                oldX = Enemy.X;
                oldY = Enemy.Y;
                foreach (Platform platforms in map.Platforms)
                    if (Enemy.IsOver(platforms.SpriteImage))
                    {
                        Enemy.MoveTo(Enemy.X, (short)
                            (platforms.SpriteImage.Y - Enemy.SPRITE_HEIGHT));
                        isFalling = false;
                        isJumping = false;
                    }

                if (Enemy.Y >= floorPosition -
               mainCharacter.SPRITE_HEIGHT)
                {
                    Enemy.MoveTo(Enemy.X, (short)
                        (floorPosition - Enemy.SPRITE_HEIGHT));
                    isFalling = false;
                    isJumping = false;
                }

                foreach (Wall walls in map.Walls)
                {
                    if (Enemy.IsOver(walls.SpriteImage))
                    {
                        Enemy.MoveTo(Enemy.X, (short)
                            (walls.SpriteImage.Y - Enemy.SPRITE_HEIGHT));
                        
                    }

                    else if (Enemy.CollidesWithImage(walls.SpriteImage))
                    {
                        Enemy.X = oldX;
                        Enemy.Y = oldY;
                        map.XMap = oldXMap;
                        map.YMap = oldYMap;
                        Enemy.MoveTo(Enemy.X, Enemy.Y);
                        
                    }
                }
            }

            if (mainCharacter.CollidesWith(map.Exit))
            {
                    gameOver = true;
            }

            //5.-Puse_Game
            //TO DO
            if (hardware.IsKeyPressed(Hardware.KEY_ESC) ||
                keyPressed == Hardware.KEY_ESC)
            {
                gameOver = true;
            }
            if (mainCharacter.Lives <= 0)
                gameOver = true;

        } while (!gameOver);
        audio.StopMusic();
        Save();
    }
}
