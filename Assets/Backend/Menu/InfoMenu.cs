namespace Backend.Menu
{
    public class InfoMenu: AbstractMenu
    {
        protected InfoMenu previousPage { get; private set; }
        protected InfoMenu nextPage { get; private set; }

        public void Configure(InfoMenu previousPage, InfoMenu nextPage)
        {
            this.previousPage = previousPage;
            this.nextPage = nextPage;
        }

        public void Next()
        {
            if (nextPage != null)
            {
                manager.OverwriteCurrentMenu(nextPage);
            }
        }

        public void Previous()
        {
            if (previousPage != null)
            {
                manager.OverwriteCurrentMenu(previousPage);
            }
        }
    }
}