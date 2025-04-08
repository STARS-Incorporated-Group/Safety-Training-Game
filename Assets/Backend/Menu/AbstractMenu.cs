using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Backend.Hazards;

namespace Backend.Menu
{
    public abstract class AbstractMenu
    {
        protected MenuStateMachine Manager;

        protected AbstractMenu(MenuStateMachine manager)
        {
            this.Manager = manager;
        }

        public virtual void Close()
        {
        }

        public virtual void Load()
        {
        }

        public void Back()
        {
            Manager.Back();
        }
    }
}