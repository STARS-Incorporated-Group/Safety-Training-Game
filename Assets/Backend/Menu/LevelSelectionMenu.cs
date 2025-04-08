using Backend.Menu;
using System;

namespace Backend.Menu
{
    public class LevelSelectionMenu : AbstractMenu
    {
        private Func<int>[] _startFunctions;
        private MenuStateMachine _manager;

        public LevelSelectionMenu(MenuStateMachine manager, Func<int>[] startFunctions) : 
            base(manager, MenuState.LevelSelector)
        {
            _startFunctions = startFunctions;
        }

        public void SelectLevel(int index)
        {
            if (index < _startFunctions.Length)
            {
                Manager.Close();
                _startFunctions[index]();
            }
        }
    }
}