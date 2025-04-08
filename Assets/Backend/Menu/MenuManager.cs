using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Backend.Menu
{
    public class MenuManager
    {
        private readonly List<AbstractMenu> _menuHistory;
        private AbstractMenu _currentMenu;

        public MenuManager()
        {
            _menuHistory = new List<AbstractMenu>();
            _currentMenu = null;
        }
        
        public void Back()
        {
            if (_menuHistory.Count > 0)
            {
                _currentMenu.Close();
                _currentMenu = _menuHistory[-1];
                _menuHistory.RemoveAt(-1);
                _currentMenu.Load();
            }
            else
            {
                // log warning
                System.Diagnostics.Debug.WriteLine("\033[1;31mTried to go back to previous menu but menu was already the root.\033[0m");
            }
        }
        
        public void Select(AbstractMenu menu)
        {
            _menuHistory.Add(_currentMenu);
            _currentMenu.Close();
            _currentMenu = menu;
            _currentMenu.Load();
        }
        
        public void OverwriteCurrentMenu(AbstractMenu menu)
        {
            _currentMenu.Close();
            _currentMenu = menu;
            _currentMenu.Load();
        }
        
        public void SelectRoot(AbstractMenu menu)
        {
            _menuHistory.Clear();
            _currentMenu.Close();
            _currentMenu = menu;
            _currentMenu.Load();
        }

        public void Open(AbstractMenu menu)
        {
            if (_currentMenu != null || _menuHistory.Count != 0)
            {
                System.Diagnostics.Debug.WriteLine("\033[1;31mTried to open menu but it was already open.\033[0m");
                return;
            }
            _currentMenu = menu;
        }
        
        public void Close()
        {
            _currentMenu.Close();
            _currentMenu = null;
            _menuHistory.Clear();
        }
    }
}