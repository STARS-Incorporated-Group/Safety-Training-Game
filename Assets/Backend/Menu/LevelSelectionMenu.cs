using Backend.Menu;
using System;

namespace Backend.Menu
{
    public class LevelSelectionMenu : AbstractMenu
    {
        private Func<int>[] _startFunctions;
        
        public void Configure(Func<int>[] startFunctions)
        {
            this._startFunctions = startFunctions;
        }

        public void SelectLevel(int index)
        {
            if (index < _startFunctions.Length)
            {
                manager.Close();
                _startFunctions[index]();
            }
        }
    }
}