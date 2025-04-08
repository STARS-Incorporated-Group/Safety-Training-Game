using Backend.Menu;
using System;

namespace Backend.Menu
{
    public class LevelSelectionMenu : AbstractMenu
    {
        private readonly Func<int>[] _startFunctions;

        public LevelSelectionMenu(MenuManager manager, Func<int>[] startFunctions) : 
            base(manager)
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