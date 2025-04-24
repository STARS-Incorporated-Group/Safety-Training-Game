using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class PauseMenu: AbstractMenu
    {
        
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected GameObject settingsMenuGameObject;
        [SerializeField] protected GameObject infoMenuGameObject;
        [SerializeField] protected GameObject mainMenuObGameObject;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button resumeButton;
        [SerializeField] protected Button restartButton;
        [SerializeField] protected Button settingsButton;
        [SerializeField] protected Button infoButton;
        [SerializeField] protected Button exitButton;

        [Header("Configure Events (assign in Inspector)")] 
        [SerializeField] protected UnityEvent restartEvent;
        [SerializeField] protected UnityEvent resumeEvent;
        
        private SettingsMenu     _settingsMenu;
        private InfoSelectorMenu _infoMenu;
        private MainMenu         _mainMenu;

        protected override void Awake()
        {
            base.Awake();
            _infoMenu = infoMenuGameObject.GetComponent<InfoSelectorMenu>();
            _settingsMenu = settingsMenuGameObject.GetComponent<SettingsMenu>();
            _mainMenu = mainMenuObGameObject.GetComponent<MainMenu>();
        }

        protected override void WireButtons()
        {
            resumeButton.onClick.AddListener(ResumeGame);
            restartButton.onClick.AddListener(RestartLevel);
            settingsButton.onClick.AddListener(GoToSettingsMenu);
            infoButton.onClick.AddListener(GoToInfoMenu);
            exitButton.onClick.AddListener(ExitLevel);
        }

        protected override void UnwireButtons()
        {
            resumeButton.onClick.RemoveListener(ResumeGame);
            restartButton.onClick.RemoveListener(RestartLevel);
            settingsButton.onClick.RemoveListener(GoToSettingsMenu);
            infoButton.onClick.RemoveListener(GoToInfoMenu);
            exitButton.onClick.RemoveListener(ExitLevel);
        }
        
        public void GoToSettingsMenu()
        {
            manager.Select(_settingsMenu);
        }
        
        public void GoToInfoMenu()
        {
            manager.Select(_infoMenu);
        }
        
        public void GoToMainMenu()
        {
            manager.Select(_mainMenu);
        }
        
        public virtual void RestartLevel()
        {
            restartEvent.Invoke();
            manager.Close();
        }
        
        public virtual void ExitLevel()
        {
            manager.SelectRoot(_mainMenu);
        }
        
        public virtual void ResumeGame()
        {
            resumeEvent.Invoke();
            manager.Close();
        }
        
        public override void Back()
        {
            ResumeGame();
        }
    }
}