namespace Ex04.Menus.Inerfaces
{
    using System;
    using System.Collections.Generic;

    public class MainMenu : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public void Show()
        {
            /* Show() function:
             * in this function we will show the given things:
             * 1. We will show the user the current lvl menu (the MainMenu)
             * 2. we will as the user to choose an item (item as MenuItem) or in other words we will let him chose a sub-menu
             * 3. we will get the input from the user (params)
             * 4. check input validation && give exeptions
             * 5. Navigation through sub-menu's and choosing a certain action 
                  a. in case the user choice is a sub-menu it will show the sub-menu/actions it contains
                  b. in case the user choice is an action the sys will use a function to preform the task
                     afterwards the sys will show the latest menu we was on */
            int userChoice;
            MenuItem currentMenuItem = this, choosenMenuItem; // this, chosenMenuItem
            bool isCurrentMenuIsAMainMenu;
            bool userIsActive = true;
            while (userIsActive)
            {
                isCurrentMenuIsAMainMenu = currentMenuItem == null;
                Console.WriteLine(currentMenuItem.ToString());
                userChoice = this.GetUserInput(currentMenuItem.MenuItems.Count);
                if (userChoice == 0)
                {
                    if (isCurrentMenuIsAMainMenu)
                    {
                        userIsActive = false;
                    }

                    currentMenuItem = currentMenuItem.CurrentMenuItemsMainMenu;
                }
                else
                {
                    choosenMenuItem = currentMenuItem.MenuItems[userChoice - 1];
                    if (this.checkIfLeaf(choosenMenuItem))
                    {
                        Console.Clear();
                        choosenMenuItem.NotifyMenuItemObservers();
                    }
                    else
                    {
                        currentMenuItem = choosenMenuItem;
                    }
                }
            }
        }


        private bool ChekIfChoiceIsValid(string i_ChoiceInString, int i_AmoutOfMenus)
        {
            bool isValid = true;
            int choiceAsInt;

            if (int.TryParse(i_ChoiceInString, out choiceAsInt) == false)
            {
                isValid = false;
            }
            else
            {
                if (choiceAsInt < 0 || choiceAsInt > i_AmoutOfMenus)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private int GetUserInput(int i_AmoutOfMenus)
        {
            bool isValid = false;
            string choiceAsString;
            int choiceAsInteger = 0;
            if (!isValid)
            {
                choiceAsString = Console.ReadLine();
                if (this.ChekIfChoiceIsValid(choiceAsString, i_AmoutOfMenus))
                {
                    Console.WriteLine(string.Format("Invalid input. Please enter a number between 0 to {0}", i_AmoutOfMenus));
                }
                else
                {
                    int.TryParse(choiceAsString, out choiceAsInteger);
                    isValid = true;
                }
            }

            return choiceAsInteger;
        }
    }
}
