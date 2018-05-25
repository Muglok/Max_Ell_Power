
class Enemy : MovableSprite
{
    public byte STEP_LENGHT = 2;
    const byte DESTROY_SCORE = 50;
    const byte DAMAGE = 1;

    public void Move(MainCharacter mainCharacter)
    {
        short xDist = (short) (mainCharacter.X - this.X);
        short yDist = (short)(mainCharacter.Y - this.Y);

        if(this.GetType().ToString() == "AerialEnemy")
        {
            if (xDist < 0 && yDist == 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.LEFT;
                this.X -= STEP_LENGHT;
            }

            else if (xDist > 0 && yDist == 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.RIGHT;
                this.X += STEP_LENGHT;
            }

            else if (xDist == 0 && yDist < 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.UP;
                this.X -= STEP_LENGHT;
            }

            else if (xDist == 0 && yDist > 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.DOWN;
                this.X += STEP_LENGHT;
            }

            else if (xDist < 0 && yDist < 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.LEFT_UP;
                this.X -= STEP_LENGHT;
                this.Y -= STEP_LENGHT;
            }

            else if (xDist < 0 && yDist > 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.LEFT_DOWN;
                this.X -= STEP_LENGHT;
                this.Y += STEP_LENGHT;
            }

            else if (xDist > 0 && yDist > 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.RIGHT_DOWN;
                this.X += STEP_LENGHT;
                this.Y += STEP_LENGHT;
            }

            else if (xDist > 0 && yDist < 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.RIGHT_UP;
                this.X += STEP_LENGHT;
                this.Y -= STEP_LENGHT;
            }
        }

        else
        {
            this.Fall(1);

            if (xDist < 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.LEFT;
                this.X -= STEP_LENGHT;
            }

            else if (xDist > 0)
            {
                this.CurrentDirection = MovableSprite.SpriteDirections.RIGHT;
                this.X += STEP_LENGHT;
            }
        }

        this.Animate(CurrentDirection);
    }
}
