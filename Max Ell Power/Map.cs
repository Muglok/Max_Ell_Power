using System.Collections.Generic;
using System.IO;
/*
    * This class contains all the diferent elements in the map, draw the map and 
    * check colisions with diferent objects.
    * */
class Map
{
    public List<Wall> Walls { get; }
    public List<Platform> Platforms { get; }
    public List<Enemy> Enemy { get; }
    public List<EnemiesGenerator> Generators { get; }
    public List<DangerousFloor> DangerousFloors { get; }
    public List<Treasure> Treasures { get; }
    public List<Trap> Traps { get; }
    public List<Ladder> Ladders { get; }
    public List<CheckPoint> CheckPoints { get; }
    public StartPoint Start { get; set; }
    public ExitPoint Exit { get; set; }
    public Image BackGround { get; set; }

    public short XMeasure = 50;
    public short YMeasure = 50; 
    public short Width { get; set; }
    public short Height { get; set; }
    public short XMap { get; set; }
    public short YMap { get; set; }

    public Map(string fileName)
    {
        
        Walls = new List<Wall>();
        Platforms = new List<Platform>();
        DangerousFloors = new List<DangerousFloor>();
        Ladders = new List<Ladder>();
        Enemy = new List<Enemy>();
        XMap = 0;
        YMap = 720;
        BackGround = new Image("Map/FondoFinal.png", 4800, 1440);

        string[] lines = File.ReadAllLines(fileName);
        if (lines.Length > 0)
        {
            Width = (short)(lines[0].Length * XMeasure);
            Height = (short)(lines.Length * YMeasure);

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '5')
                    {
                        AddWall(new Wall(5, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '4')
                    {
                        AddWall(new Wall(4, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '6')
                    {
                        AddWall(new Wall(6, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '7')
                    {
                        AddWall(new Wall(7, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '8')
                    {
                        AddWall(new Wall(8, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '9')
                    {
                        AddWall(new Wall(9, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '1')
                    {
                        AddWall(new Wall(1, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '2')
                    {
                        AddWall(new Wall(2, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == '3')
                    {
                        AddWall(new Wall(3, (short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'p')
                    {
                        AddPlatform(new Platform(1,(short)(j * XMeasure), 
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'P')
                    {
                        AddPlatform(new Platform(2,(short)(j * XMeasure), 
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'Y')
                    {
                        AddDangerousFloor(new DangerousFloor((short)(j * XMeasure), 
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'L')
                    {
                        AddLadder(new Ladder((short)(j * XMeasure),
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'A')
                    {
                        Enemy.Add(new AerialEnemy((short)(j * XMeasure),
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'J')
                    {
                        Enemy.Add(new JumpEnemy((short)(j * XMeasure),
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'T')
                    {
                        Enemy.Add(new LandEnemy((short)(j * XMeasure),
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'X')
                    {
                        XMap = (short)(j * XMeasure);
                        YMap = (short)(i * YMeasure);
                        
                    }
                    else if (lines[i][j] == 'x')
                    {
                        XMap = (short)(j * XMeasure);
                        YMap = (short)(i * YMeasure);
                    }
                   else if (lines[i][j] == 'S')
                    {
                        AddWall(new Wall(8, (short)(j * XMeasure), (short)(i * YMeasure)));
                        Start = new StartPoint((short)(j * XMeasure), (short)(i * YMeasure));
                    }
                    else if (lines[i][j] == 'E')
                    {
                        Exit = new ExitPoint((short)(j * XMeasure), (short)(i * YMeasure));
                    }
                    
                }
            }
        }
    }

    public void AddWall(Wall w)
    {
        Walls.Add(w);
    }

    public void AddPlatform(Platform P)
    {
        Platforms.Add(P);
    }

    public void AddDangerousFloor(DangerousFloor Y)
    {
        DangerousFloors.Add(Y);
    }

    public void AddLadder(Ladder L)
    {
        Ladders.Add(L);
    }

    public void CollidesCharacterWithTreasure()
    {
        //TO DO
    }

    public void CollidesCharacterWithScoreItems()
    {
        //TO DO
    }

    public short CollideWeaponsWithEnemies(MainCharacter mainCharacter)
    {
        short result = 0;
        int i = 0, j;
        bool weaponDestroyed;
        while (i < mainCharacter.Weapons.Count)
        {
            j = 0;
            weaponDestroyed = false;
            while (j < Enemy.Count && !weaponDestroyed)
            {
                if (mainCharacter.Weapons[i].CollidesWithImageShoot(Enemy[j].SpriteImage))
                {
                    mainCharacter.RemoveWeapon(i);
                    Enemy.RemoveAt(j);
                    weaponDestroyed = true;
                    result += global::Enemy.DESTROY_SCORE;
                }
                else
                    j++;
            }
            if (!weaponDestroyed)
                i++;
        }
        return result;
    }

    public void CollideWeaponsWithWalls(MainCharacter mainCharacter)
    {
        int i = 0;
        while (i < mainCharacter.Weapons.Count)
        {
            if (mainCharacter.Weapons[i].CollidesWithImage(Walls[i].SpriteImage))
                mainCharacter.RemoveWeapon(i);
            else
                i++;
        }
    }
}

