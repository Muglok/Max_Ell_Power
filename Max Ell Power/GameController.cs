using System;
using Tao.Sdl;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Ell_Power
{
    /*
     * This class contaisn the flow of the game
     */
    class GameController
    {
        public const short SCREEN_WIDTH = 800;
        public const short SCREEN_HEIGHT = 500;

        public void Start()
        {
            //TO DO
            Hardware hardware = new Hardware(1200, 720, 24, false);

            IntroScreen intro = new IntroScreen(hardware);
            CreditsScreen credits = new CreditsScreen(hardware);
            PlayerSelectScreen playerSelect = new PlayerSelectScreen(hardware);
            ScoreBoardScreen scoreBoard = new ScoreBoardScreen(hardware);
            MainMenuScreen mainMenu = new MainMenuScreen(hardware);


            mainMenu.Show();

        }
    }
}
