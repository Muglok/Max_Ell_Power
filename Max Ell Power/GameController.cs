﻿/*
* This class contaisn the flow of the game
*/
class GameController
{
    public const short SCREEN_WIDTH = 1200;
    public const short SCREEN_HEIGHT = 720;
    public static short lastGame = 0;
    public static short language = 1;

    public void Start()
    {
        //TO DO
        Hardware hardware = new Hardware(SCREEN_WIDTH, SCREEN_HEIGHT, 24, false);
        IntroScreen intro = new IntroScreen(hardware);
        GameScreen game = new GameScreen(hardware);
        CreditsScreen credits = new CreditsScreen(hardware);
        PlayerSelectScreen playerSelect = new PlayerSelectScreen(hardware);
        ScoreBoardScreen scoreBoard;
        MainMenuScreen mainMenu = new MainMenuScreen(hardware);
        HelpScreen helpScreen = new HelpScreen(hardware);
        OptionsScreen optionsScreen = new OptionsScreen(hardware);
        intro.Show();

        HordeModeScreen hordeMode;
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
                    case 2:
                        if(lastGame != 0)
                        {
                            if(lastGame == 1)
                            {
                                playerSelect.Show();
                                game = new GameScreen(hardware);
                                game.ChosenPlayer = playerSelect.ChosenPlayer();
                                game.Show();
                            }
                            else
                            {
                                playerSelect.Show();
                                hordeMode = new HordeModeScreen(hardware);
                                hordeMode.ChosenPlayer = playerSelect.ChosenPlayer();
                                hordeMode.Show();
                            }
                        }
                        break;
                    case 3:
                        playerSelect.Show();
                        hordeMode = new HordeModeScreen(hardware);
                        hordeMode.ChosenPlayer = playerSelect.ChosenPlayer();
                        hordeMode.Show();
                        break;
                    case 4:
                        scoreBoard = new ScoreBoardScreen(hardware);
                        scoreBoard.Show();
                        break;
                    case 5:
                        helpScreen.Show();
                        break;
                    case 6:
                        optionsScreen.Show();
                        break;
                    case 7:
                        credits.Show();
                        break;
                    default:
                        break;
                }
            }
        } while (!mainMenu.GetExit());

    }
}
