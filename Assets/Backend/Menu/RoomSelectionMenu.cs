using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class RoomSelectionMenu: AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected LevelSelectionMenu labMenu;
        [SerializeField] protected LevelSelectionMenu officeMenu;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] private Button labButton;
        [SerializeField] private Button officeButton;
        [SerializeField] private Button backButton;
        
        protected override void WireButtons()
        {
            officeButton.onClick.AddListener(GoToOfficeLevelMenu);
            labButton.onClick.AddListener(GoToLabLevelMenu);
            backButton.onClick.AddListener(Back);
        }

        protected override void UnwireButtons()
        {
            officeButton.onClick.RemoveListener(GoToOfficeLevelMenu);
            labButton.onClick.RemoveListener(GoToLabLevelMenu);
            backButton.onClick.RemoveListener(Back);
        }
        
        public void GoToLabLevelMenu()
        {
            this.manager.Select(labMenu);
        }
        
        public void GoToOfficeLevelMenu()
        {
            this.manager.Select(officeMenu);
        }
    }
}