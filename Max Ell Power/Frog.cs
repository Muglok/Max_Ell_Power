
class Frog : MainCharacter
{
    public Frog() : base()
    {
        STEP_LENGHT = 6;
        SPRITE_WIDTH = 118;
        SPRITE_HEIGHT = 69;
        SPRITE_BASE = 40;
        SPRITE_CHANGE = 6;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/ranitaRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/ranitaRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/ranitaRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/ranitaRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/ranitaLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/ranitaLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/ranitaLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/ranitaLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        UpdateSpriteCoordinates();
    }

    public override void AddWeapon()
    {
        Shoot newShoot = new Shoot();
        base.AddWeapon(newShoot);
    }
}

