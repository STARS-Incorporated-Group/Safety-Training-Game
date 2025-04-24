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
        [SerializeField] protected SettingsMenu     settingsMenu;
        [SerializeField] protected InfoSelectorMenu infoMenu;
        [SerializeField] protected MainMenu         mainMenu;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected Button resumeButton;
        [SerializeField] protected Button restartButton;
        [SerializeField] protected Button settingsButton;
        [SerializeField] protected Button infoButton;
        [SerializeField] protected Button exitButton;

        [Header("Configure Events (assign in Inspector)")] 
        [SerializeField] protected UnityEvent restartEvent;
        [SerializeField] protected UnityEvent resumeEvent;
        
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
            manager.Select(settingsMenu);
        }
        
        public void GoToInfoMenu()
        {
            manager.Select(infoMenu);
        }
        
        public void GoToMainMenu()
        {
            manager.Select(mainMenu);
        }
        
        public virtual void RestartLevel()
        {
            restartEvent.Invoke();
            manager.Close();
        }
        
        public virtual void ExitLevel()
        {
            manager.SelectRoot(mainMenu);
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