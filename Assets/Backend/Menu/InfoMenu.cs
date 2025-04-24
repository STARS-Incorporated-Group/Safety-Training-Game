using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class InfoMenu: AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected GameObject previousMenuObject;
        [SerializeField] protected GameObject nextMenuObject;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button nextButton;
        [SerializeField] protected Button previousButton;
        [SerializeField] protected Button backButton;
    
        private InfoMenu _previousMenu;
        private InfoMenu _nextMenu;

        protected override void Awake()
        {
            base.Awake();
            _previousMenu = previousMenuObject.GetComponent<InfoMenu>();
            _nextMenu = nextMenuObject.GetComponent<InfoMenu>();
        }

        protected override void WireButtons()
        {
            nextButton.onClick.AddListener(Next);
            previousButton.onClick.AddListener(Previous);
            backButton.onClick.AddListener(Back);
        }
        
        protected override void UnwireButtons()
        {
            nextButton.onClick.RemoveListener(Next);
            previousButton.onClick.RemoveListener(Previous);
            backButton.onClick.RemoveListener(Back);
        }
        
        public void Next()
        {
            if (_nextMenu != null)
            {
                manager.OverwriteCurrentMenu(_nextMenu);
            }
        }

        public void Previous()
        {
            if (_previousMenu != null)
            {
                manager.OverwriteCurrentMenu(_previousMenu);
            }
        }
    }
}