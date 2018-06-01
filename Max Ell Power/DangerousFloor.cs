
class DangerousFloor : StaticSprite
{
     public DangerousFloor()
    {
        SPRITE_WIDTH = 50;
        SPRITE_HEIGHT = 50;

        SpriteImage = new Image("imgs/Spikes2.png",
            SPRITE_WIDTH, SPRITE_HEIGHT);
    }

    public DangerousFloor( short x, short y) : this()
    {
        this.SpriteImage.X = x;
        this.SpriteImage.Y = (short)(y);
    }
}
