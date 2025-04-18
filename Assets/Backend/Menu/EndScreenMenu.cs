using System;

namespace Backend.Menu
{
    public class EndScreenMenu: AbstractMenu
    {
        protected MainMenu mainMenu {get; private set;}
        protected Func<int> replayFunc {get; private set;}
        
        public void Configure(Func<int> replayFunc, MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
            this.replayFunc = replayFunc;
        }

        public void GoToMainMenu()
        {
            manager.SelectRoot(mainMenu);
        }

        public void Replay()
        {
            replayFunc();
            manager.Close();
        }
    }
}