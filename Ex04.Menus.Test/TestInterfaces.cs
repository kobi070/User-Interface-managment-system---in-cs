using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Inerfaces;

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
            Console.WriteLine(string.Format("The data is: {0}{1}", DateTime.Now.ToShortDateString(), Environment.NewLine));
        }

        private void countSpaces()
        {
            string inputString = string.Empty;
            int amountOfSpaces = 0;

            Console.WriteLine("Please enter your sentence: ");
            inputString = Console.ReadLine();
            foreach (char ch in inputString)
            {
                if (ch == ' ')
                {
                    amountOfSpaces++;
                }
            }

            Console.WriteLine("The amount of spaces in the sentence: {0}", amountOfSpaces);
        }

        private void showVersion()
        {
            Console.WriteLine("0.4.2.22: Version");
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
            else if (i_MenuItem.Title.Equals("Count Spaces"))
            {
                countSpaces();
            }
            else if (i_MenuItem.Title.Equals("Show Version"))
            {
                showVersion();
            }
        }

        public static void Main()
        {

        }
    }
}