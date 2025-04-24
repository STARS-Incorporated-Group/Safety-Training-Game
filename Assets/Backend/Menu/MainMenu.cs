using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class MainMenu : AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected GameObject settingsMenuGameObject;
        [SerializeField] protected GameObject infoMenuGameObject;
        [SerializeField] protected GameObject roomSelectionMenuGameObject;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button settingsButton;
        [SerializeField] protected Button infoButton;
        [SerializeField] protected Button roomButton;
        
        private SettingsMenu      _settingsMenu;
        private InfoSelectorMenu  _infoMenu;
        private RoomSelectionMenu _roomSelectionMenu;

        protected override void Awake()
        {
            base.Awake();
            _settingsMenu = settingsMenuGameObject.GetComponent<SettingsMenu>();
            _infoMenu = infoMenuGameObject.GetComponent<InfoSelectorMenu>();
            _roomSelectionMenu = roomSelectionMenuGameObject.GetComponent<RoomSelectionMenu>();
        }

        protected override void WireButtons()
        {
            settingsButton.onClick.AddListener(GoToSettingsMenu);
            infoButton.onClick.AddListener(GoToInfoMenu);
            roomButton.onClick.AddListener(GoToRoomSelectionMenu);
        }

        protected override void UnwireButtons()
        {
            settingsButton.onClick.RemoveListener(GoToSettingsMenu);
            infoButton.onClick.RemoveListener(GoToInfoMenu);
            roomButton.onClick.RemoveListener(GoToRoomSelectionMenu);
        }

        public void GoToRoomSelectionMenu()
        {
            manager.Select(_roomSelectionMenu);
        }

        public void GoToSettingsMenu()
        {
            manager.Select(_settingsMenu);
        }

        public void GoToInfoMenu()
        {
            manager.Select(_infoMenu);
        }

        public override void Back()
        {
            //throw new System.NotImplementedException("No previous menu from MainMenu");
        }
    }
}