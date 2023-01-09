namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfacesMainMenu = new Interfaces.MainMenu();
            TestInterfaces testInterfacesMenu;
        }

        public static void Run(TestInterfaces i_TestInterfaces, TestInterfaces i_TestDelegates) { return; }

        private static void BuildInterfacesCase(Interfaces.MainMenu o_InterfacesMenuToBuildUpon)
        {
            // create a main menue
            o_InterfacesMenuToBuildUpon.Title = "** Delegates Main Menu**";

            // creation of sub-menus
            o_InterfacesMenuToBuildUpon.AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[0].Title = "**Version and Uppercases**";
            o_InterfacesMenuToBuildUpon.CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon;
            o_InterfacesMenuToBuildUpon.MenuItems[1].AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[1].Title = "**Dates/Time**";
            o_InterfacesMenuToBuildUpon.MenuItems[1].CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon;
            // create the actions in each sub-menu
            o_InterfacesMenuToBuildUpon.MenuItems[0].AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[0].MenuItems[0].Title = "Show Version";
            o_InterfacesMenuToBuildUpon.MenuItems[0].MenuItems[0].CurrentMenuItemsMainMenu= o_InterfacesMenuToBuildUpon.MenuItems[0];
            o_InterfacesMenuToBuildUpon.MenuItems[0].AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[0].MenuItems[1].Title = "Show Uppercas";
            o_InterfacesMenuToBuildUpon.MenuItems[0].MenuItems[1].CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon.MenuItems[0];
            o_InterfacesMenuToBuildUpon.MenuItems[1].AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[0].Title = "Show Date";
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[0].CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon.MenuItems[1];
            o_InterfacesMenuToBuildUpon.MenuItems[1].AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[1].Title = "Show Time";
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[1].CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon.MenuItems[1];
        }
    }
}
