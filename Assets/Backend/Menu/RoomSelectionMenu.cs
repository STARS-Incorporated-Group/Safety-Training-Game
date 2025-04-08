using System;
using System.Collections;
using Unity.VisualScripting;

namespace Backend.Menu
{
    public class RoomSelectionMenu: AbstractMenu
    {
        private AbstractMenu[] _children;
        
        public RoomSelectionMenu(MenuManager manager, AbstractMenu[] children): 
            base(manager)
        {
            this._children = children;
        }

        public void SelectRoom(int index)
        {
            if (index < _children.Length)
            {
                this.Manager.Select(_children[index]);
            }
        }
    }
}