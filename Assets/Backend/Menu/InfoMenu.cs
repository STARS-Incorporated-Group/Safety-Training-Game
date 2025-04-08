namespace Backend.Menu
{
    public class InfoMenu: AbstractMenu
    {
        protected InfoMenu PreviousPage;
        protected InfoMenu NextPage;
        
        InfoMenu(MenuStateMachine manager, InfoMenu previousPage, InfoMenu nextPage) :
            base(manager)
        {
            PreviousPage = previousPage;
            NextPage = nextPage;
        }

        public void Next()
        {
            if (NextPage != null)
            {
                Manager.Select(NextPage);
            }
        }

        public void Previous()
        {
            if (PreviousPage != null)
            {
                Manager.Select(PreviousPage);
            }
        }
    }
}