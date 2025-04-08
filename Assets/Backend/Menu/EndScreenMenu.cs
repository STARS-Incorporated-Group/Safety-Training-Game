using System;

namespace Backend.Menu
{
    public class EndScreenMenu: AbstractMenu
    {
        private readonly MainMenu _mainMenu;
        private readonly Func<int> _replayFunc;
        
        public EndScreenMenu(MenuManager manager, Func<int> replayFunc, MainMenu mainMenu)
            : base(manager)
        {
            _mainMenu = mainMenu;
            _replayFunc = replayFunc;
        }

        public void GoToMainMenu()
        {
            Manager.SelectRoot(_mainMenu);
        }

        public void Replay()
        {
            _replayFunc();
            Manager.Close();
        }
    }
}