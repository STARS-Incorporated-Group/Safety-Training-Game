namespace Backend.Menu
{
    public class SettingsMenu: AbstractMenu
    {
        SettingsMenu(MenuStateMachine manager) :
            base(manager, MenuState.Settings)
        {
            
        }
    }
}