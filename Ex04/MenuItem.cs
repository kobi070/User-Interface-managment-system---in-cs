namespace Ex04.Menus.Inerfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MenuItem // Employee in our example
    {
        private readonly List<MenuItem> r_MenuItems; // sub-menus we might posses
        private readonly MenuItem r_CurrentMenuItemsMainMenu = null;
        private readonly string r_Title = string.Empty; // Tilte of the a menu/sub-menue
        private readonly List<IMenuItemObserver> r_MenuItemObservers; // who is listening to our MenuItems => could be a few MainMenus

        public List<MenuItem> MenuItems
        {
            get { return this.r_MenuItems; }
        }

        public MenuItem CurrentMenuItemsMainMenu
        {
            get
            {
                return this.r_CurrentMenuItemsMainMenu;
            }
        }

        public string Title
        {
            get { return this.r_Title; }
        }

        public List<IMenuItemObserver> MenuItemObservers
        {
            get { return this.r_MenuItemObservers; }
        }

        // add a listener to r_MenuItemObservers
        public void AttachObserver(IMenuItemObserver i_MenuItemObserver)
        {
            this.r_MenuItemObservers.Add(i_MenuItemObserver);
        }

        // removes a listener to r_MenuItemObservers
        public void DetachObserver(IMenuItemObserver i_MenuItemObserver)
        {
            if (this.checkIfMenuItemIsSubMenu(this.CurrentMenuItemsMainMenu))
            {
                this.r_MenuItemObservers.Remove(i_MenuItemObserver);
            }
            else
            {
                throw new ArgumentException("Could no remove {0} from the main activaty", this.Title);
            }
        }

        public void NotifyMenuItemObservers()
        {
            foreach (IMenuItemObserver MenuItemObserver in this.r_MenuItemObservers)
            {
                MenuItemObserver.menuItemChoice(this);
            }
        }

        private bool checkIfMenuItemIsSubMenu(MenuItem i_MenuItem)
        {
            bool isSubMenu = false;
            foreach (IMenuItemObserver MenuItemObserver in this.r_MenuItemObservers)
            {
                if (i_MenuItem == MenuItemObserver)
                {
                    isSubMenu = true;
                    break;
                }
            }

            return isSubMenu;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("**").Append(this.r_Title).AppendLine("**");
            stringBuilder.AppendLine("================");
            for (int i = 1; i <= this.r_MenuItems.Count; i++)
            {
                stringBuilder.Append(i.ToString()).Append(" -> ").AppendLine(this.r_MenuItems[i - 1].Title);
            }

            if (this is MainMenu)
            {
                stringBuilder.AppendLine("0 -> Exit");
            }
            else
            {
                stringBuilder.AppendLine("0 -> Back");
            }

            stringBuilder.AppendLine("-------------------------");
            stringBuilder.Append("Enter your request (1 to ").Append(r_MenuItems.Count).Append(" or press '0' to ");
            if (this is MainMenu)
            {
                stringBuilder.Append("Exit).");
            }
            else
            {
                stringBuilder.Append("Back).");
            }

            return stringBuilder.ToString();
        }

        public bool checkIfLeaf(MenuItem i_MenuItem)
        {
            return this.r_MenuItems.Count == 0;
        }
    }
}
