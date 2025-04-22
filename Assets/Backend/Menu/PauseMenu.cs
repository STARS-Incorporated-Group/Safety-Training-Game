using System;
using UnityEngine;
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
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button infoButton;
        [SerializeField] private Button exitButton;
        protected Func<int> restartFunc {get; set;}

        public void Configure(Func<int> restartFunc)
        {
            this.restartFunc = restartFunc;
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
            restartFunc();
            manager.Close();
        }
        
        public virtual void ExitLevel()
        {
            manager.SelectRoot(mainMenu);
        }
        
        public virtual void ResumeGame()
        {
            manager.Close();
        }
        
        public override void Back()
        {
            ResumeGame();
        }
    }
}