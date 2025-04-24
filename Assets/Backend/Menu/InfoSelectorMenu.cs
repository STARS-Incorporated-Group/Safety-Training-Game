using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class InfoSelectorMenu: AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected InfoMenu controlsMenu;
        [SerializeField] protected InfoMenu instructionsMenu;
        [SerializeField] protected InfoMenu scoringMenu;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button controlsButton;
        [SerializeField] protected Button instructionsButton;
        [SerializeField] protected Button scoringButton;
        [SerializeField] protected Button backButton;

        protected override void WireButtons()
        {
            controlsButton.onClick.AddListener(GoToControlsMenu);
            instructionsButton.onClick.AddListener(GoToInstructionsMenu);
            scoringButton.onClick.AddListener(GoToScoringMenu);
            backButton.onClick.AddListener(Back);
        }
        
        protected override void UnwireButtons()
        {
            controlsButton.onClick.RemoveListener(GoToControlsMenu);
            instructionsButton.onClick.RemoveListener(GoToInstructionsMenu);
            scoringButton.onClick.RemoveListener(GoToScoringMenu);
            backButton.onClick.RemoveListener(Back);
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