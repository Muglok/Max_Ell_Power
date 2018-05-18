﻿
class Bear : MainCharacter
{
    public Bear() : base()
    {
        STEP_LENGHT = 4;
        SPRITE_WIDTH = 138;
        SPRITE_HEIGHT = 129;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/bearRight1.png", 138, 129),
        new Image("imgs/bearRight2.png", 138, 129),
        new Image("imgs/bearRight3.png", 138, 129),
        new Image("imgs/bearRight4.png", 138, 129)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/bearLeft1.png", 138, 129),
        new Image("imgs/bearLeft2.png", 138, 129),
        new Image("imgs/bearLeft3.png", 138, 129),
        new Image("imgs/bearLeft4.png", 138, 129)};

        UpdateSpriteCoordinates();
    }
}

