using System;

namespace Backend.Menu
{
    public class PauseMenu: AbstractMenu
    {
        protected SettingsMenu settingsMenu {get; set;}
        protected InfoSelectorMenu infoMenu {get; set;}
        protected MainMenu mainMenu {get; set;}
        protected Func<int> restartFunc {get; set;}

        public void Configure(Func<int> restartFunc, SettingsMenu settingsMenu, InfoSelectorMenu infoMenu,
            MainMenu mainMenu)
        {
            this.settingsMenu = settingsMenu;
            this.infoMenu = infoMenu;
            this.mainMenu = mainMenu;
            this.restartFunc = restartFunc;
        }
        
        public void GoToSettingsMenu()
        {
            manager.Select(settingsMenu);
        }
        
        public void GoToInfoMenu()
        {
            manager.Select(infoMenu);
        }
        
        public void GoToMainMenu()
        {
            manager.Select(mainMenu);
        }
        
        public virtual void RestartLevel()
        {
            restartFunc();
            manager.Close();
        }
        
        public virtual void ExitLevel()
        {
            manager.SelectRoot(mainMenu);
        }
        
        public virtual void ResumeGame()
        {
            manager.Close();
        }
        
        public override void Back()
        {
            ResumeGame();
        }
    }
}