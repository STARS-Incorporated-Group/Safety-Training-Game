using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class EndScreenMenu: AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected GameObject mainMenuGameObject;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button replayButton;
        [SerializeField] protected Button exitButton;

        [Header("Configure Events (assign in Inspector)")] 
        [SerializeField] protected UnityEvent replayEvent;
        
        private MainMenu _mainMenu;

        protected override void Awake()
        {
            base.Awake();
            _mainMenu = mainMenuGameObject.GetComponent<MainMenu>();
        }

        protected override void WireButtons()
        {
            replayButton.onClick.AddListener(Replay);
            exitButton.onClick.AddListener(GoToMainMenu);
        }
        
        protected override void UnwireButtons()
        {
            replayButton.onClick.RemoveListener(Replay);
            exitButton.onClick.RemoveListener(GoToMainMenu);
        }
        
        public void GoToMainMenu()
        {
            manager.SelectRoot(_mainMenu);
        }

        public void Replay()
        {
            replayEvent.Invoke();
            manager.Close();
        }

        public override void Back()
        {
            throw new NotImplementedException();
        }
    }
}