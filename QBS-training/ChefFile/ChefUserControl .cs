namespace QBS_training.ChefFile
{
    public class ChefUserControl
    {
        public ChefUserMenu UserMenu { get; set; }
        public ChefUserControl() { UserMenu = new ChefUserMenu(); }
        public Chef GetObject(int choice)
        {
            return UserMenu.UserMenu[UserMenu.IndexOf(choice)].ChefDerivedClass;
        }

    }
}
