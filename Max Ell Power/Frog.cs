
class Frog : MainCharacter
{
    public Frog() : base()
    {
        /* SPRITE_WIDTH = 118;
        SPRITE_HEIGHT = 69;*/

        Sprites[(int)SpriteDirections.RIGHT] = new Image[]{
            new Image("imgs/ranitaRight1.png", 118, 69),
        new Image("imgs/ranitaRight3.png", 118, 69),
        new Image("imgs/ranitaRight2.png", 118, 69),
        new Image("imgs/ranitaRight4.png", 118, 69)};

        Sprites[(int)SpriteDirections.LEFT] = new Image[]{
            new Image("imgs/ranitaLeft1.png", 118, 69),
        new Image("imgs/ranitaLeft2.png", 118, 69),
        new Image("imgs/ranitaLeft3.png", 118, 69),
        new Image("imgs/ranitaLeft4.png", 118, 69)};

        UpdateSpriteCoordinates();
    }
}

