﻿/*
* This class contaisn the flow of the game
*/
class GameController
{
    public const short SCREEN_WIDTH = 1200;
    public const short SCREEN_HEIGHT = 720;

    public void Start()
    {
        //TO DO
        Hardware hardware = new Hardware(SCREEN_WIDTH, SCREEN_HEIGHT, 24, false);

        IntroScreen intro = new IntroScreen(hardware);
        CreditsScreen credits = new CreditsScreen(hardware);
        PlayerSelectScreen playerSelect = new PlayerSelectScreen(hardware);
        ScoreBoardScreen scoreBoard = new ScoreBoardScreen(hardware);
        MainMenuScreen mainMenu = new MainMenuScreen(hardware);
        GameScreen game;

        do
        {
            mainMenu.Show();
            if (!mainMenu.GetExit())
            {
                switch (mainMenu.GetChosenOption())
                {
                    case 1:
                        playerSelect.Show();
                        game = new GameScreen(hardware);
                        game.ChosenPlayer = playerSelect.ChosenPlayer();
                        game.Show();
                        break;
                    default:
                        break;
                }
                    
            }
        } while (!mainMenu.GetExit());

    }
}
