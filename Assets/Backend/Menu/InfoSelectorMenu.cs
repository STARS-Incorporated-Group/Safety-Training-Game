namespace Backend.Menu
{
    public class InfoSelectorMenu: AbstractMenu
    {
        protected InfoMenu controlsMenu { get; private set; }
        protected InfoMenu instructionsMenu { get; private set; }
        protected InfoMenu scoringMenu { get; private set; }

        public void Configure(InfoMenu controlsMenu, InfoMenu instructionsMenu, InfoMenu scoringMenu)
        {
            this.controlsMenu = controlsMenu;
            this.instructionsMenu = instructionsMenu;
            this.scoringMenu = scoringMenu;
        }

        public void GoToControlsMenu()
        {
            manager.Select(controlsMenu);
        }
        
        public void GoToInstructionsMenu()
        {
            manager.Select(instructionsMenu);
        }
        
        public void GoToScoringMenu()
        {
            manager.Select(scoringMenu);
        }
    }
}