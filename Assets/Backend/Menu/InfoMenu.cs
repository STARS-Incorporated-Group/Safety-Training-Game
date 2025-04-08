namespace Backend.Menu
{
    public class InfoMenu: AbstractMenu
    {
        private readonly InfoMenu _previousPage;
        private readonly InfoMenu _nextPage;
        
        public InfoMenu(MenuManager manager, InfoMenu previousPage, InfoMenu nextPage) :
            base(manager)
        {
            _previousPage = previousPage;
            _nextPage = nextPage;
        }

        public void Next()
        {
            if (_nextPage != null)
            {
                Manager.OverwriteCurrentMenu(_nextPage);
            }
        }

        public void Previous()
        {
            if (_previousPage != null)
            {
                Manager.OverwriteCurrentMenu(_previousPage);
            }
        }
    }
}