using System;

namespace Backend.Menu
{
    public class SettingsMenu: AbstractMenu
    {
        private GameParams.UserConfig _userConfig;
        
        SettingsMenu(MenuStateMachine manager, GameParams.UserConfig userConfig):
            base(manager)
        {
            this._userConfig = userConfig;
        }
        
        public void SetFloatOption(GameParams.EUserOptions option, float value)
        {
            switch (option)
            {
                case GameParams.EUserOptions.PlayerHeight:
                    _userConfig.PlayerHeight = value;
                    break;
                case GameParams.EUserOptions.Brightness:
                    _userConfig.Brightness = value;
                    break;
                case GameParams.EUserOptions.FoV:
                    _userConfig.FoV = value;
                    break;
                case GameParams.EUserOptions.Sensitivity:
                    _userConfig.Sensitivity = value;
                    break;
                default:
                    // error
                    throw new ArgumentOutOfRangeException(nameof(option), option, null);
            }
        }
    }
}