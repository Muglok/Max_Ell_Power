
class Soldier : MainCharacter
{
    public Soldier() : base()
    {
        STEP_LENGHT = 4;
        SPRITE_WIDTH = 44;
        SPRITE_HEIGHT = 30;
        SPRITE_BASE = 0;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/Shoot1Right.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot2Right.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot3Right.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot4Right.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/Shoot1Left.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot2Left.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot3Left.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Shoot4Left.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        UpdateSpriteCoordinates();
    }

    public override void AddWeapon()
    {
        Shoot newShoot = new Shoot();
        base.AddWeapon(newShoot);
    }
}

