namespace Backend.Menu
{
    public class InfoSelectorMenu: AbstractMenu
    {
        private readonly InfoMenu _controlsMenu;
        private readonly InfoMenu _instructionsMenu;
        private readonly InfoMenu _scoringMenu;

        public InfoSelectorMenu(MenuManager manager, InfoMenu controlsMenu, InfoMenu instructionsMenu, InfoMenu scoringMenu)
            : base(manager)
        {
            _controlsMenu = controlsMenu;
            _instructionsMenu = instructionsMenu;
            _scoringMenu = scoringMenu;
        }

        public void GoToControlsMenu()
        {
            Manager.Select(_controlsMenu);
        }
        
        public void GoToInstructionsMenu()
        {
            Manager.Select(_instructionsMenu);
        }
        
        public void GoToScoringMenu()
        {
            Manager.Select(_scoringMenu);
        }
    }
}