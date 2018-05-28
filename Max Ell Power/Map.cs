﻿using System.Collections.Generic;
/*
    * This class contains all the diferent elements in the map, draw the map and 
    * check colisions with diferent objects.
    * */
class Map
{
    public List<Sprite> Walls { get; }
    public List<Enemy> Enemies { get; }
    public List<EnemiesGenerator> Generators { get; }
    public List<DangerousFloor> DangerousFloors { get; }
    public List<Treasure> Treasures { get; }
    public List<Trap> Traps { get; }
    public List<Ladder> Ladders { get; }
    public List<CheckPoint> CheckPoints { get; }
    public StartPoint Start { get; set; }
    public StartPoint Exit { get; set; }
        

    public short Width { get; set; }
    public short Height { get; set; }
    public short XMap { get; set; }
    public short YMap { get; set; }

    public Map()
    {
        Walls = new List<Sprite>();

    }

    public void AddWall(Wall w)
    {
        Walls.Add(w);
    }

    public void CollidesCharacterWithTreasure()
    {
        //TO DO
    }

    public void CollidesCharacterWithScoreItems()
    {
        //TO DO
    }

    public void CollidesCharacterWithWalls()
    {
        //TO DO
    }

    public void CollidesCharacterWithEnemies()
    {
        //TO DO
    }
}

