
class Shoot : Weapon
{
    public Shoot()
    {
        SPRITE_WIDTH = 44;
        SPRITE_HEIGHT = 30;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/Shoot1RightV2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot2RightV2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot3RightV2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot4RightV2.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/Shoot1LeftV2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot2LeftV2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot3LeftV2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot4LeftV2.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        UpdateSpriteCoordinates();
    }
}

