using UnityEditor;

namespace Backend.Menu
{
    public class MainMenu : AbstractMenu
    {
        private readonly RoomSelectionMenu _roomSelectionMenu;
        private readonly SettingsMenu _settingsMenu;
        private readonly InfoSelectorMenu _infoMenu;

        public MainMenu(MenuManager manager, RoomSelectionMenu roomSelectionMenu, SettingsMenu settingsMenu,
            InfoSelectorMenu infoMenu) :
            base(manager)
        {
            _roomSelectionMenu = roomSelectionMenu;
            _settingsMenu = settingsMenu;
            _infoMenu = infoMenu;
        }

        public void GoToRoomSelectionMenu()
        {
            Manager.Select(_roomSelectionMenu);
        }

        public void GoToSettingsMenu()
        {
            Manager.Select(_settingsMenu);
        }

        public void GoToInfoMenu()
        {
            Manager.Select(_infoMenu);
        }

        public override void Back()
        {
            throw new System.NotImplementedException("No previous menu from MainMenu");
        }
    }
}