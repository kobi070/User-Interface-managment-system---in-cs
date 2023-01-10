namespace Ex04.Menus.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Ex04.Menus.Delegates;

    public class TestDelegatesAndEvents 
    {

        public TestDelegatesAndEvents(MainMenu o_UtilsMainMenu)
        {
            o_UtilsMainMenu.MenuItems[0].MenuItems[0].m_MenuItemChooseDelegate += this.showTime;
            o_UtilsMainMenu.MenuItems[0].MenuItems[1].m_MenuItemChooseDelegate += this.showDate;
            o_UtilsMainMenu.MenuItems[1].MenuItems[0].m_MenuItemChooseDelegate += this.countUppercase;
            o_UtilsMainMenu.MenuItems[1].MenuItems[1].m_MenuItemChooseDelegate += this.showVersion;
        }

        private void showTime()
        {
            Console.WriteLine(string.Format("The time is: {0}{1}", DateTime.Now.ToString("HH:mm:ss"), Environment.NewLine));
        }

        private void showDate()
        {
            Console.WriteLine(string.Format("The data is: {0}{1}", DateTime.Now.ToShortDateString(), Environment.NewLine));
        }

        private void countUppercase()
        {
            string inputString = string.Empty;
            int amountOfUppercase = 0;

            Console.WriteLine("Please enter your sentence: ");
            inputString = Console.ReadLine();
            foreach (char ch in inputString)
            {
                if (char.IsUpper(ch))
                {
                    amountOfUppercase++;
                }
            }
            Console.WriteLine("The amount of uppercases in your string: {0}{1}", amountOfUppercase, Environment.NewLine);
        }

        public void showVersion()
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
            else if (i_MenuItem.Title.Equals("Count Upercases"))
            {
                countUppercase();
            }
            else if (i_MenuItem.Title.Equals("Show Version"))
            {
                showVersion();
            }
        }
    }
}
