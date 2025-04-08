using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Backend.Hazards;

namespace Backend.Menu
{
    public abstract class AbstractMenu
    {
        public readonly MenuState State;
        protected MenuStateMachine Manager;

        protected AbstractMenu(MenuStateMachine manager, MenuState state)
        {
            this.Manager = manager;
            this.State = state;
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