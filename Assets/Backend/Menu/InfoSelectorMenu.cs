using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class InfoSelectorMenu: AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected GameObject controlsMenuGameObject;
        [SerializeField] protected GameObject instructionsMenuGameObject;
        [SerializeField] protected GameObject scoringMenuGameObject;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button controlsButton;
        [SerializeField] protected Button instructionsButton;
        [SerializeField] protected Button scoringButton;
        [SerializeField] protected Button backButton;
        
        private InfoMenu _controlsMenu;
        private InfoMenu _instructionsMenu;
        private InfoMenu _scoringMenu;

        protected override void Awake()
        {
            base.Awake();
            _controlsMenu = controlsMenuGameObject.GetComponent<InfoMenu>();
            _instructionsMenu = instructionsMenuGameObject.GetComponent<InfoMenu>();
            _scoringMenu = scoringMenuGameObject.GetComponent<InfoMenu>();
        }

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
            manager.Select(_controlsMenu);
        }
        
        public void GoToInstructionsMenu()
        {
            manager.Select(_instructionsMenu);
        }
        
        public void GoToScoringMenu()
        {
            manager.Select(_scoringMenu);
        }
    }
}