using System;
using System.Text;
using System.Collections.Generic;
using QBS_training_Help;

namespace QBS_training_restaurant
{

    interface IUserMenu {
        public void AddChoice(object choiceNumber, StringBuilder titleOfChoice);
        public void DeleteChoice(object choiceNumber);
        public int IndexOf(object choiceNumber);    

    }

    abstract class Chef
    {
        public StringBuilder ChifName { get; set; }
        public StringBuilder FoodPlate { get; set; }
        public abstract StringBuilder ToStringChefResponsible();


    }

    class ChefUserControl { 
        public ChefUserMenu UserMenu { get; set; }
        public ChefUserControl() { UserMenu = new ChefUserMenu(); }
        public Chef Get_Object(int choice) {
            return UserMenu.userMenu[UserMenu.IndexOf(choice)].ChefDerivedClass;
        }
        
    }

    class ChefUserMenu :IUserMenu
    {
        public ChefUserMenu()
        {
            choiceNumber = -1;
            ChefDerivedClass = null;
            userMenu = new List<ChefUserMenu>();
            titleOfChoice = new StringBuilder();
        }        
        public ChefUserMenu(object choiceNumber, StringBuilder titleOfChoice, Chef ChefDerivedClass)
        {
            this.choiceNumber = choiceNumber;
            this.ChefDerivedClass = ChefDerivedClass;
            userMenu = new List<ChefUserMenu>();
            this.titleOfChoice = titleOfChoice;
        }
        public object choiceNumber { get; set; }
        public Chef ChefDerivedClass { get; set; }
        public List<ChefUserMenu> userMenu { get; set; }
        public StringBuilder titleOfChoice { get ; set ; }
        public void AddChoice(object choiceNumber, StringBuilder titleOfChoice)
        {
            if (ChefDerivedClass == null)
            { Console.WriteLine("Error : objectDriver = null"); }
            else { 
            ChefUserMenu newChoice = new ChefUserMenu(choiceNumber, titleOfChoice, ChefDerivedClass);
            userMenu.Add(newChoice);
                }
        }
        public void DeleteChoice(object choiceNumber)
        {

            int index = IndexOf(choiceNumber);
            if (index == -1)
            {
                Console.WriteLine("this choice not exist");
            }
            else
            {
                userMenu.RemoveAt(index);
                Console.WriteLine("this choice is deleted");

            }

        }
        public int IndexOf(object choiceNumber)
        {

            int Index;
            for (Index = 0; Index < userMenu.Count; Index++)
            {
                if (choiceNumber.ToString() == userMenu[Index].choiceNumber.ToString())
                { return Index; }
            }
            return -1;
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (ChefUserMenu choice in userMenu)
            {
                result.Append(choice.choiceNumber)
                  .Append("- ")
                  .Append(choice.titleOfChoice)
                  .AppendLine();
            }
            return result.ToString();
        }

    }

    class ItalianChef :Chef
    {
        public override StringBuilder ToStringChefResponsible()
        { return Help.DoneMessageFormat(new StringBuilder("The order is prepared by a chef who is an expert in the Italian dish")); }
    }

    class IndianChef :Chef
    {
        public override StringBuilder ToStringChefResponsible()
        { return Help.DoneMessageFormat(new StringBuilder("The order is prepared by a chef who is an expert in the Indian dish")); }
        
    }

    class ArabicChef :Chef
    {
        public override StringBuilder ToStringChefResponsible()
        { return Help.DoneMessageFormat(new StringBuilder("The order is prepared by an expert chef in the Arabic dish")); }

    }





    














}
