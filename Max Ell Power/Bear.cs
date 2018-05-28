
class Bear : MainCharacter
{
    public Bear() : base()
    {
        STEP_LENGHT = 4;
        SPRITE_WIDTH = 138;
        SPRITE_HEIGHT = 129;
        SPRITE_BASE = 30;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/bearRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/bearRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/bearRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/bearRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/bearLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/bearLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/bearLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/bearLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        UpdateSpriteCoordinates();
    }

    public override void AddWeapon()
    {
        Shoot newShoot = new Shoot();
        base.AddWeapon(newShoot);
    }
}

