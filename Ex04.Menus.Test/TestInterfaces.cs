using System;
using Ex04.Menus.Interfaces;
namespace Ex04.Menus.Test
{

    public class TestInterfaces : IMenuItemObserver
    {
        public TestInterfaces(MainMenu o_UtilsMainMenu)
        {
            o_UtilsMainMenu.MenuItems[0].MenuItems[0].AttachObserver(this);
            o_UtilsMainMenu.MenuItems[0].MenuItems[1].AttachObserver(this);
            o_UtilsMainMenu.MenuItems[1].MenuItems[0].AttachObserver(this);
            o_UtilsMainMenu.MenuItems[1].MenuItems[1].AttachObserver(this);
        }

        private void showTime()
        {
            Console.WriteLine(string.Format("The time is: {0}{1}", DateTime.Now.ToString("HH:mm:ss"), Environment.NewLine));
        }

        private void showDate()
        {
            Console.WriteLine(string.Format("The date is: {0}{1}", DateTime.Now.ToShortDateString(), Environment.NewLine));
        }

        private void countUpperCase()
        {
            string inputString = string.Empty;
            int amountOfUppercases = 0;

            Console.WriteLine("Please enter your sentence: ");
            inputString = Console.ReadLine();
            foreach (char ch in inputString)
            {
                if (char.IsUpper(ch))
                {
                    amountOfUppercases++;
                }
            }

            Console.WriteLine("The amount of spaces in the sentence: {0}", amountOfUppercases);
        }

        private void showVersion()
        {
            Console.WriteLine("Version: 23.1.4.8859");
        }

        public void menuItemChoice(MenuItem i_MenuItem)
        {

            if (i_MenuItem.Title.Equals("Show Time"))
            {
                showTime();
            }
            else if (i_MenuItem.Title.Equals("Show Date"))
            {
                showDate();
            }
            else if (i_MenuItem.Title.Equals("Count Uppercases"))
            {
                countUpperCase();
            }
            else if (i_MenuItem.Title.Equals("Show Version"))
            {
                showVersion();
            }
        }
    }
}