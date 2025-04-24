using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class InfoMenu: AbstractMenu
    {
        
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected InfoMenu previousMenu;
        [SerializeField] protected InfoMenu nextMenu;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button nextButton;
        [SerializeField] protected Button previousButton;
        [SerializeField] protected Button backButton;

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
            if (nextMenu != null)
            {
                manager.OverwriteCurrentMenu(nextMenu);
            }
        }

        public void Previous()
        {
            if (previousMenu != null)
            {
                manager.OverwriteCurrentMenu(previousMenu);
            }
        }
    }
}