using System;

namespace Backend.Menu
{
    public class SettingsMenu: AbstractMenu
    {
        protected GameParams.UserConfig userConfiguration { get; private set; }

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