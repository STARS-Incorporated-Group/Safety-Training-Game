using UnityEditor;

namespace Backend.Menu
{
    public class MainMenu : AbstractMenu

    {
        private RoomSelectionMenu _roomSelectionMenu;
        private SettingsMenu _settingsMenu;
        private InfoMenu _infoMenu;

        public MainMenu(MenuStateMachine manager, RoomSelectionMenu roomSelectionMenu, SettingsMenu settingsMenu,
            InfoMenu infoMenu) :
            base(manager, MenuState.MainMenu)
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
    }
}