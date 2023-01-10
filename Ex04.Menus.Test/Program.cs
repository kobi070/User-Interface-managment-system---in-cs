namespace Ex04.Menus.Test
{
    using System;
    public class Program
    {
        public static void Main()
        {
            Run();
        }

        public static void Run()
        {
            // Create the test cases
            TestInterfaces testInterfacesMenu;
            TestDelegatesAndEvents testDelegatesAndEvents;

            // Create the two typess of solutions
            Interfaces.MainMenu interfacesMainMenu = new Interfaces.MainMenu();
            Delegates.MainMenu delegatesMainMenu = new Delegates.MainMenu();

            // init the solutions
            buildInterfacesCase(interfacesMainMenu);
            buildDelegatesAndEventsCase(delegatesMainMenu);

            // fill test's that was require for the assigment
            testInterfacesMenu = new TestInterfaces(interfacesMainMenu);
            testDelegatesAndEvents = new TestDelegatesAndEvents(delegatesMainMenu);

            // use show methods on both Menu's
            interfacesMainMenu.Show();
            Console.Clear();
            delegatesMainMenu.Show();
            

        }

        private static void buildInterfacesCase(Interfaces.MainMenu o_InterfacesMenuToBuildUpon)
        {
            // create a main menue
            o_InterfacesMenuToBuildUpon.Title = "**Delegates Main Menu**";

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
            o_InterfacesMenuToBuildUpon.MenuItems[0].MenuItems[1].Title = "Count Uppercas";
            o_InterfacesMenuToBuildUpon.MenuItems[0].MenuItems[1].CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon.MenuItems[0];
            o_InterfacesMenuToBuildUpon.MenuItems[1].AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[0].Title = "Show Date";
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[0].CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon.MenuItems[1];
            o_InterfacesMenuToBuildUpon.MenuItems[1].AttachSubObserver(new Interfaces.MenuItem());
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[1].Title = "Show Time";
            o_InterfacesMenuToBuildUpon.MenuItems[1].MenuItems[1].CurrentMenuItemsMainMenu = o_InterfacesMenuToBuildUpon.MenuItems[1];
        }

        private static void buildDelegatesAndEventsCase(Delegates.MainMenu o_DelegatesMenuToBuilld)
        {
            // create a main menue
            o_DelegatesMenuToBuilld.Title = "**Delegates Main Menu**";

            // creation of sub-menus
            o_DelegatesMenuToBuilld.AttachSubObserver(new Delegates.MenuItem());
            o_DelegatesMenuToBuilld.MenuItems[0].Title = "**Version and Uppercases**";
            o_DelegatesMenuToBuilld.CurrentMenuItemsMainMenu = o_DelegatesMenuToBuilld;
            o_DelegatesMenuToBuilld.MenuItems[1].AttachSubObserver(new Delegates.MenuItem());
            o_DelegatesMenuToBuilld.MenuItems[1].Title = "**Dates/Time**";
            o_DelegatesMenuToBuilld.MenuItems[1].CurrentMenuItemsMainMenu = o_DelegatesMenuToBuilld;
            // create the actions in each sub-menu
            o_DelegatesMenuToBuilld.MenuItems[0].AttachSubObserver(new Delegates.MenuItem());
            o_DelegatesMenuToBuilld.MenuItems[0].MenuItems[0].Title = "Show Version";
            o_DelegatesMenuToBuilld.MenuItems[0].MenuItems[0].CurrentMenuItemsMainMenu = o_DelegatesMenuToBuilld.MenuItems[0];
            o_DelegatesMenuToBuilld.MenuItems[0].AttachSubObserver(new Delegates.MenuItem());
            o_DelegatesMenuToBuilld.MenuItems[0].MenuItems[1].Title = "Count Uppercas";
            o_DelegatesMenuToBuilld.MenuItems[0].MenuItems[1].CurrentMenuItemsMainMenu = o_DelegatesMenuToBuilld.MenuItems[0];
            o_DelegatesMenuToBuilld.MenuItems[1].AttachSubObserver(new Delegates.MenuItem());
            o_DelegatesMenuToBuilld.MenuItems[1].MenuItems[0].Title = "Show Date";
            o_DelegatesMenuToBuilld.MenuItems[1].MenuItems[0].CurrentMenuItemsMainMenu = o_DelegatesMenuToBuilld.MenuItems[1];
            o_DelegatesMenuToBuilld.MenuItems[1].AttachSubObserver(new Delegates.MenuItem());
            o_DelegatesMenuToBuilld.MenuItems[1].MenuItems[1].Title = "Show Time";
            o_DelegatesMenuToBuilld.MenuItems[1].MenuItems[1].CurrentMenuItemsMainMenu = o_DelegatesMenuToBuilld.MenuItems[1];
        }
    }
}
