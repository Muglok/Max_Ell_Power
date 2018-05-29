using System.Collections.Generic;
using System;
using System.IO;
/*
    * This class contains all the diferent elements in the map, draw the map and 
    * check colisions with diferent objects.
    * */
class Map
{
    public List<Wall> Walls { get; }
    public List<Platform> Platforms { get; }
    public List<Enemy> Enemies { get; }
    public List<EnemiesGenerator> Generators { get; }
    public List<DangerousFloor> DangerousFloors { get; }
    public List<Treasure> Treasures { get; }
    public List<Trap> Traps { get; }
    public List<Ladder> Ladders { get; }
    public List<CheckPoint> CheckPoints { get; }
    public StartPoint Start { get; set; }
    public StartPoint Exit { get; set; }
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
        Enemies = new List<Enemy>();
        XMap = YMap = 0;
        BackGround = new Image("Map/fondo.png", 4800, 1440);

        string[] lines = File.ReadAllLines(fileName);
        if (lines.Length > 0)
        {
            Width = (short)(lines[0].Length * XMeasure);
            Height = (short)(lines.Length * YMeasure);

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == 'W')
                    {
                        AddWall(new Wall((short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'P')
                    {
                        AddPlatform(new Platform(1,(short)(j * XMeasure), 
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'p')
                    {
                        AddPlatform(new Platform(2,(short)(j * XMeasure), 
                            (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'X')
                    {
                        XMap = (short)(j * XMeasure);
                        YMap = (short)(i * YMeasure);
                        AddWall(new Wall((short)(j * XMeasure), (short)(i * YMeasure)));
                    }
                    else if (lines[i][j] == 'x')
                    {
                        XMap = (short)(j * XMeasure);
                        YMap = (short)(i * YMeasure);
                    }
                    /*else if (lines[i][j] == 'S')
                    {
                        Start = new StartPoint((short)(j * XMeasure), (short)(i * YMeasure));
                        //                           Start.X -= XMap;
                        //                           Start.Y -= YMap;
                    }
                    else if (lines[i][j] == 'E')
                    {
                        Exit = new ExitPoint((short)(j * XMeasure), (short)(i * YMeasure));
                    }*/
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
            while (j < Enemies.Count && !weaponDestroyed)
            {
                if (mainCharacter.Weapons[i].CollidesWithImage(Enemies[j].
                    SpriteImage))
                {
                    mainCharacter.RemoveWeapon(i);
                    Enemies.RemoveAt(j);
                    weaponDestroyed = true;
                    result += Enemy.DESTROY_SCORE;
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

