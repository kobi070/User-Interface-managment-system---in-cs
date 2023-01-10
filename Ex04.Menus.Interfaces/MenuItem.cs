namespace Ex04.Menus.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MenuItem // Employee in our example
    {
        private List<MenuItem> m_MenuItems = new List<MenuItem>(); // sub-menus we might posses
        private MenuItem m_CurrentMenuItemsMainMenu = null;
        private string m_Title = string.Empty; // Tilte of the a menu/sub-menue

        private List<IMenuItemObserver> m_MenuItemObservers = new List<IMenuItemObserver>(); // who is listening to our MenuItems => could be a few MainMenus

        public List<MenuItem> MenuItems
        {
            get { return this.m_MenuItems; }
            set { this.m_MenuItems = value; }
        }

        public MenuItem CurrentMenuItemsMainMenu
        {
            get
            {
                return this.m_CurrentMenuItemsMainMenu;
            }

            set
            {
                this.m_CurrentMenuItemsMainMenu = value;
            }
        }

        public string Title
        {
            get { return this.m_Title; }
            set { this.m_Title = value; }
        }

        // add a listener to m_MenuItemObservers
        public void AttachObserver(IMenuItemObserver i_MenuItemToAdd)
        {
            this.m_MenuItemObservers.Add(i_MenuItemToAdd);
        }

        public void AttachSubObserver(MenuItem i_MenuItemToAdd)
        {
            this.m_MenuItems.Add(i_MenuItemToAdd);
        }

        // removes a listener to m_MenuItemObservers
        public void DetachSubObserver(MenuItem i_MenuItemToRemove)
        {
            if (this.checkIfMenuItemIsSubMenu(this.CurrentMenuItemsMainMenu))
            {
                this.m_MenuItems.Remove(i_MenuItemToRemove);
            }
            else
            {
                throw new ArgumentException("Could no remove {0} from the main activaty", this.Title);
            }
        }

        public void DetachObserver(IMenuItemObserver i_MenuItemToRemove)
        {
            this.m_MenuItemObservers.Remove(i_MenuItemToRemove);
        }

        public void NotifyMenuItemObservers()
        {
            foreach (IMenuItemObserver MenuItemObserver in this.m_MenuItemObservers)
            {
                MenuItemObserver.menuItemChoice(this);
            }
        }

        private bool checkIfMenuItemIsSubMenu(MenuItem i_MenuItem)
        {
            bool isSubMenu = false;
            foreach (IMenuItemObserver MenuItemObserver in this.m_MenuItemObservers)
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

            stringBuilder.Append("**").Append(this.m_Title).AppendLine("**");
            stringBuilder.AppendLine("================");
            for (int i = 1; i <= this.m_MenuItems.Count; i++)
            {
                stringBuilder.Append(i.ToString()).Append(" -> ").AppendLine(this.m_MenuItems[i - 1].Title);
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
            stringBuilder.Append("Enter your request (1 to ").Append(m_MenuItems.Count).Append(" or press '0' to ");
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

        public bool checkIfLeaf()
        {
            return m_MenuItems.Count == 0;
        }
    }
}
