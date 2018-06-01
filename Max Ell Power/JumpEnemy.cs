
class JumpEnemy : Enemy
{
    //TO DO
    public JumpEnemy() : base()
    {
        SPRITE_WIDTH = 118;
        SPRITE_HEIGHT = 69;
        STEP_LENGHT = 4;

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/Enemies/JumpEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
           new Image("imgs/Enemies/JumpEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.UP] = new Image[]{
           new Image("imgs/Enemies/JumpEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.DOWN] = new Image[]{
           new Image("imgs/Enemies/JumpEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT_DOWN] = new Image[]{
            new Image("imgs/Enemies/JumpEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.LEFT_UP] = new Image[]{
             new Image("imgs/Enemies/JumpEnemyLeft1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyLeft4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.RIGHT_DOWN] = new Image[]{
           new Image("imgs/Enemies/JumpEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        Sprites[(int)SpriteDirections.RIGHT_UP] = new Image[]{
            new Image("imgs/Enemies/JumpEnemyRight1.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight2.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight3.png", SPRITE_WIDTH, SPRITE_HEIGHT),
        new Image("imgs/Enemies/JumpEnemyRight4.png", SPRITE_WIDTH, SPRITE_HEIGHT)};

        UpdateSpriteCoordinates();
    }
    public JumpEnemy(short x, short y) : this()
    {
        this.MoveTo(x, y);
    }
}

