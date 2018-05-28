using System;
using Tao.Sdl;

/**
* This class will manage every hardware issue: screen resolution, keyboard 
* input and some other aspects
*/
class Hardware
{
    public const int KEY_ESC = Sdl.SDLK_ESCAPE;
    public const int KEY_UP = Sdl.SDLK_UP;
    public const int KEY_DOWN = Sdl.SDLK_DOWN;
    public const int KEY_LEFT = Sdl.SDLK_LEFT;
    public const int KEY_RIGHT = Sdl.SDLK_RIGHT;
    public const int KEY_SPACE = Sdl.SDLK_SPACE;
    public const int KEY_C = Sdl.SDLK_c;

    short screenWidth;
    short screenHeight;
    short colorDepth;
    IntPtr screen;

    static bool isThereJoystick;
    static IntPtr joystick;

    public Hardware(short width, short height, short depth, bool fullScreen)
    {
        screenWidth = width;
        screenHeight = height;
        colorDepth = depth;

        int flags = Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT;
        if (fullScreen)
            flags = flags | Sdl.SDL_FULLSCREEN;

        //Initialization of sdl Joystick
        Sdl.SDL_Init(Sdl.SDL_INIT_JOYSTICK);

        // Joystick initialization
        isThereJoystick = true;
        if (Sdl.SDL_NumJoysticks() < 1)
            isThereJoystick = false;

        if (isThereJoystick)
        {
            joystick = Sdl.SDL_JoystickOpen(0);
            if (joystick == IntPtr.Zero)
                isThereJoystick = false;
        }

        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        screen = Sdl.SDL_SetVideoMode(screenWidth, screenHeight, colorDepth, flags);
        Sdl.SDL_Rect rect = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
        Sdl.SDL_SetClipRect(screen, ref rect);

        SdlTtf.TTF_Init();
    }

    ~Hardware()
    {
        Sdl.SDL_Quit();
    }

    // Draws an image in its current coordinates
    public void DrawImage(Image img)
    {
        Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, img.ImageWidth,
            img.ImageHeight);
        Sdl.SDL_Rect target = new Sdl.SDL_Rect(img.X, img.Y,
            img.ImageWidth, img.ImageHeight);
        Sdl.SDL_BlitSurface(img.ImagePtr, ref source, screen, ref target);
    }



    // Draws a sprite from a sprite sheet in the specified X and Y position of the screen
    // The sprite to be drawn is determined by the x and y coordinates within the image, and the width and height to be cropped
    public void DrawSprite(Image image, short xScreen, short yScreen, short x, short y, short width, short height)
    {
        Sdl.SDL_Rect src = new Sdl.SDL_Rect(x, y, width, height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect(xScreen, yScreen, width, height);
        Sdl.SDL_BlitSurface(image.ImagePtr, ref src, screen, ref dest);
    }

    // Update screen
    public void UpdateScreen()
    {
        Sdl.SDL_Flip(screen);
    }

    // Detects if the user presses a key and returns the code of the key pressed
    public int KeyPressed()
    {
        int pressed = -1;

        Sdl.SDL_PumpEvents();
        Sdl.SDL_Event keyEvent;
        if (Sdl.SDL_PollEvent(out keyEvent) == 1)
        {
            if (keyEvent.type == Sdl.SDL_KEYDOWN)
            {
                pressed = keyEvent.key.keysym.sym;
            }
        }

        return pressed;
    }

    // Checks if a given key is now being pressed
    public bool IsKeyPressed(int key)
    {
        bool pressed = false;
        Sdl.SDL_PumpEvents();
        Sdl.SDL_Event evt;
        Sdl.SDL_PollEvent(out evt);
        int numKeys;
        byte[] keys = Sdl.SDL_GetKeyState(out numKeys);
        if (keys[key] == 1)
            pressed = true;
        return pressed;
    }

    // Clears the screen
    public void ClearScreen()
    {
        Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
        Sdl.SDL_FillRect(screen, ref source, 0);
    }

    // Clears the bottom of the screen
    public void ClearBottom()
    {
        Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, GameController.SCREEN_HEIGHT, screenWidth, (short)(screenHeight - GameController.SCREEN_HEIGHT));
        Sdl.SDL_FillRect(screen, ref source, 0);
    }

    // Writes a text in the specified coordinates
    public void WriteText(IntPtr textAsImage, short x, short y)
    {
        Sdl.SDL_Rect src = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect(x, y, screenWidth, screenHeight);
        Sdl.SDL_BlitSurface(textAsImage, ref src, screen, ref dest);
    }

    // Writes a line in the specified coordinates, with the specified color and alpha
    public void DrawLine(short x, short y, short x2, short y2, byte r, byte g, byte b, byte alpha)
    {
        SdlGfx.lineRGBA(screen, x, y, x2, y2, r, g, b, alpha);
    }

    // Joystick methods

    /** JoystickPressed: returns TRUE if
        *  a certain button in the joystick/gamepad
        *  has been pressed
        */
    public static bool JoystickPressed(int boton)
    {
        if (!isThereJoystick)
            return false;

        if (Sdl.SDL_JoystickGetButton(joystick, boton) > 0)
            return true;
        else
            return false;
    }

    /** JoystickMoved: returns TRUE if
        *  the joystick/gamepad has been moved
        *  up to the limit in any direction
        *  Then, int returns the corresponding
        *  X (1=right, -1=left)
        *  and Y (1=down, -1=up)
        */
    public static bool JoystickMoved(out int posX, out int posY)
    {
        posX = 0; posY = 0;
        if (!isThereJoystick)
            return false;

        posX = Sdl.SDL_JoystickGetAxis(joystick, 0);  // Leo valores (hasta 32768)
        posY = Sdl.SDL_JoystickGetAxis(joystick, 1);
        // Normalizo valores
        if (posX == -32768) posX = -1;  // Normalizo, a -1, +1 o 0
        else if (posX == 32767) posX = 1;
        else posX = 0;
        if (posY == -32768) posY = -1;
        else if (posY == 32767) posY = 1;
        else posY = 0;

        if ((posX != 0) || (posY != 0))
            return true;
        else
            return false;
    }


    /** JoystickMovedRight: returns TRUE if
        *  the joystick/gamepad has been moved
        *  completely to the right
        */
    public static bool JoystickMovedRight()
    {
        if (!isThereJoystick)
            return false;

        int posX = 0, posY = 0;
        if (JoystickMoved(out posX, out posY) && (posX == 1))
            return true;
        else
            return false;
    }

    /** JoystickMovedLeft: returns TRUE if
        *  the joystick/gamepad has been moved
        *  completely to the left
        */
    public static bool JoystickMovedLeft()
    {
        if (!isThereJoystick)
            return false;

        int posX = 0, posY = 0;
        if (JoystickMoved(out posX, out posY) && (posX == -1))
            return true;
        else
            return false;
    }


    /** JoystickMovedUp: returns TRUE if
        *  the joystick/gamepad has been moved
        *  completely upwards
        */
    public static bool JoystickMovedUp()
    {
        if (!isThereJoystick)
            return false;

        int posX = 0, posY = 0;
        if (JoystickMoved(out posX, out posY) && (posY == -1))
            return true;
        else
            return false;
    }

    /** JoystickMovedDown: returns TRUE if
        *  the joystick/gamepad has been moved
        *  completely downwards
        */
    public static bool JoystickMovedDown()
    {
        if (!isThereJoystick)
            return false;

        int posX = 0, posY = 0;
        if (JoystickMoved(out posX, out posY) && (posY == 1))
            return true;
        else
            return false;
    }
}
