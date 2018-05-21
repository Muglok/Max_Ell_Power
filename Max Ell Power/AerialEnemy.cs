
class AerialEnemy : Enemy
{
    //TO DO
    public AerialEnemy() : base()
    {
        SPRITE_WIDTH = 196;
        SPRITE_HEIGHT = 181;
        STEP_LENGHT = 3;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/Enemies/AerialEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/Enemies/AerialEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.UP] = new Image[]{
            new Image("imgs/Enemies/AerialEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT) };

        Sprites[(int)SpriteDirections.DOWN] = new Image[]{
            new Image("imgs/Enemies/AerialEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT) };

        Sprites[(int)SpriteDirections.LEFT_DOWN] = new Image[]{
             new Image("imgs/Enemies/AerialEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT_UP] = new Image[]{
             new Image("imgs/Enemies/AerialEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.RIGHT_DOWN] = new Image[]{
            new Image("imgs/Enemies/AerialEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.RIGHT_UP] = new Image[]{
            new Image("imgs/Enemies/AerialEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/AerialEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        UpdateSpriteCoordinates();
    }
}

