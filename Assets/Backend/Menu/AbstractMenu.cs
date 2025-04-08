using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Backend.Hazards;

namespace Backend.Menu
{
    public abstract class AbstractMenu
    {
        protected readonly MenuManager Manager;

        protected AbstractMenu(MenuManager manager)
        {
            this.Manager = manager;
        }

        public virtual void Close()
        {
        }

        public virtual void Load()
        {
        }

        public virtual void Back()
        {
            Manager.Back();
        }
        
    }
}