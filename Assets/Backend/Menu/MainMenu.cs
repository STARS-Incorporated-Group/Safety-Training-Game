namespace Backend.Menu
{
    public class MainMenu : AbstractMenu
    {
        protected RoomSelectionMenu roomSelectionMenu { get; private set; }
        protected SettingsMenu settingsMenu { get; private set; }
        protected InfoSelectorMenu infoMenu { get; private set; }

        public void Configure(RoomSelectionMenu roomSelectionMenu, SettingsMenu settingsMenu,
            InfoSelectorMenu infoMenu)
        {
            this.roomSelectionMenu = roomSelectionMenu;
            this.settingsMenu = settingsMenu;
            this.infoMenu = infoMenu;
        }

        public void GoToRoomSelectionMenu()
        {
            manager.Select(roomSelectionMenu);
        }

        public void GoToSettingsMenu()
        {
            manager.Select(settingsMenu);
        }

        public void GoToInfoMenu()
        {
            manager.Select(infoMenu);
        }

        public override void Back()
        {
            //throw new System.NotImplementedException("No previous menu from MainMenu");
        }
    }
}