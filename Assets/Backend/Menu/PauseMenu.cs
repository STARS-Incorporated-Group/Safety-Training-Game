using System;

namespace Backend.Menu
{
    public class PauseMenu: AbstractMenu
    {
        private readonly SettingsMenu _settingsMenu;
        private readonly InfoSelectorMenu _infoMenu;
        private readonly MainMenu _mainMenu;
        private readonly Func<int> _restartFunc;
        
        public PauseMenu(MenuManager manager, Func<int> restartFunc, SettingsMenu settingsMenu, InfoSelectorMenu infoMenu, MainMenu mainMenu) :
            base(manager)
        {
            _settingsMenu = settingsMenu;
            _infoMenu = infoMenu;
            _mainMenu = mainMenu;
            _restartFunc = restartFunc;
        }
        
        public void GoToSettingsMenu()
        {
            Manager.Select(_settingsMenu);
        }
        
        public void GoToInfoMenu()
        {
            Manager.Select(_infoMenu);
        }
        
        public void GoToMainMenu()
        {
            Manager.Select(_mainMenu);
        }
        
        public virtual void RestartLevel()
        {
            _restartFunc();
            Manager.Close();
        }
        
        public virtual void ExitLevel()
        {
            Manager.SelectRoot(_mainMenu);
        }
        
        public virtual void ResumeGame()
        {
            Manager.Close();
        }
        
        public override void Back()
        {
            ResumeGame();
        }
    }
}