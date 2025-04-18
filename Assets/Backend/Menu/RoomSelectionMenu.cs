using System;
using System.Collections;
using Unity.VisualScripting;

namespace Backend.Menu
{
    public class RoomSelectionMenu: AbstractMenu
    {
        protected LevelSelectionMenu[] rooms { get; private set; }
        
        public void Configure(LevelSelectionMenu[] children)
        {
            this.rooms = children;
        }
        
        public void SelectRoom(int index)
        {
            if (index < rooms.Length)
            {
                this.manager.Select(rooms[index]);
            }
        }
    }
}