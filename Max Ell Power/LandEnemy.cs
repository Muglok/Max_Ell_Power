
class LandEnemy : Enemy
{
    public LandEnemy() : base()
    {
        SPRITE_WIDTH = 138;
        SPRITE_HEIGHT = 129;
        STEP_LENGHT = 2;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/Enemies/LandEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/Enemies/LandEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.UP] = new Image[]{
            new Image("imgs/Enemies/LandEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.DOWN] = new Image[]{
            new Image("imgs/Enemies/LandEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT_DOWN ] = new Image[]{
            new Image("imgs/Enemies/LandEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT_UP] = new Image[]{
            new Image("imgs/Enemies/LandEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.RIGHT_DOWN ] = new Image[]{
             new Image("imgs/Enemies/LandEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.RIGHT_UP] = new Image[]{
            new Image("imgs/Enemies/LandEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/LandEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};



        UpdateSpriteCoordinates();
    }
}

