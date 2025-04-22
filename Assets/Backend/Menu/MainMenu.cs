using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class MainMenu : AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected SettingsMenu      settingsMenu;
        [SerializeField] protected InfoSelectorMenu  infoMenu;
        [SerializeField] protected RoomSelectionMenu roomSelectionMenu;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button settingsButton;
        [SerializeField] protected Button infoButton;
        [SerializeField] protected Button roomButton;
        
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