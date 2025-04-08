namespace Backend.Menu
{
    public class MenuButton
    {
        private static int _globalId = 0;
        private int _id;
        
        
        MenuButton()
        {
            this._id = _globalId++;
        }
    }
}