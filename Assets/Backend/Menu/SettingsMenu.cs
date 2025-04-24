using System;
using System.Collections.Generic;
using Backend.GameParams;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class SettingsMenu: AbstractMenu
    {   
        [Header("UI Sliders and Buttons")]
        [SerializeField] protected Slider heightSlider;
        [SerializeField] protected Slider brightnessSlider;
        [SerializeField] protected Slider fovSlider;
        [SerializeField] protected Slider sensitivitySlider;
        [SerializeField] protected Slider volumeSlider;
        [SerializeField] protected Button backButton;
        
        public GameParams.UserConfig userConfiguration { get; private set; }
        
        private readonly List<UnityAction<float>> _listeners = new List<UnityAction<float>>();

        protected override void Awake()
        {
            base.Awake();
            userConfiguration = new GameParams.UserConfig();
        }
        
        protected override void WireButtons()
        {
            if (_listeners.Count == 0)
            {
                _listeners.Add((float v) => userConfiguration.playerHeight = v);
                _listeners.Add((float v) => userConfiguration.brightness = v);
                _listeners.Add((float v) => userConfiguration.fov = v);
                _listeners.Add((float v) => userConfiguration.sensitivity = v);
                _listeners.Add((float v) => userConfiguration.volume = v);
            }

            heightSlider.onValueChanged.AddListener(_listeners[0]);
            brightnessSlider.onValueChanged.AddListener(_listeners[1]);
            fovSlider.onValueChanged.AddListener(_listeners[2]);
            sensitivitySlider.onValueChanged.AddListener(_listeners[3]);
            volumeSlider.onValueChanged.AddListener(_listeners[4]);
            
            backButton.onClick.AddListener(Back);
        }

        protected override void UnwireButtons()
        {
            heightSlider.onValueChanged.RemoveListener(_listeners[0]);
            brightnessSlider.onValueChanged.RemoveListener(_listeners[1]);
            fovSlider.onValueChanged.RemoveListener(_listeners[2]);
            sensitivitySlider.onValueChanged.RemoveListener(_listeners[3]);
            volumeSlider.onValueChanged.RemoveListener(_listeners[4]);
            backButton.onClick.RemoveListener(Back);
        }
        
        public void Configure(GameParams.UserConfig userConfig)
        {
            this.userConfiguration = userConfig;
        }
        
        public void SetFloatOption(GameParams.EUserOptions option, float value)
        {
            switch (option)
            {
                case GameParams.EUserOptions.PlayerHeight:
                    userConfiguration.playerHeight = value;
                    break;
                case GameParams.EUserOptions.Brightness:
                    userConfiguration.brightness = value;
                    break;
                case GameParams.EUserOptions.FoV:
                    userConfiguration.fov = value;
                    break;
                case GameParams.EUserOptions.Sensitivity:
                    userConfiguration.sensitivity = value;
                    break;
                case GameParams.EUserOptions.Volume:
                    userConfiguration.volume = value;
                    break;
                default:
                    // error
                    throw new ArgumentOutOfRangeException(nameof(option), option, null);
                    break;
            }
        }
    }
}