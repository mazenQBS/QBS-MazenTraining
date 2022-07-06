using System;
using System.Collections.Generic;
using System.Text;

namespace QBS_training.ChefFile
{
    public class ChefUserMenu : IUserMenu
    {
        public ChefUserMenu()
        {
            ChoiceNumber = -1;
            ChefDerivedClass = null;
            UserMenu = new List<ChefUserMenu>();
            TitleOfChoice = new StringBuilder();
        }
        public ChefUserMenu(object choiceNumber, StringBuilder titleOfChoice, Chef ChefDerivedClass)
        {
            this.ChoiceNumber = choiceNumber;
            this.ChefDerivedClass = ChefDerivedClass;
            UserMenu = new List<ChefUserMenu>();
            this.TitleOfChoice = titleOfChoice;
        }
        public object ChoiceNumber { get; set; }
        public Chef ChefDerivedClass { get; set; }
        public List<ChefUserMenu> UserMenu { get; set; }
        public StringBuilder TitleOfChoice { get; set; }
        public void AddChoice(object choiceNumber, StringBuilder titleOfChoice)
        {
            if (ChefDerivedClass == null)
            { Console.WriteLine("Error : objectDriver = null"); }
            else
            {
                ChefUserMenu newChoice = new ChefUserMenu(choiceNumber, titleOfChoice, ChefDerivedClass);
                UserMenu.Add(newChoice);
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
                UserMenu.RemoveAt(index);
                Console.WriteLine("this choice is deleted");

            }

        }
        public int IndexOf(object choiceNumber)
        {

            int index;
            for (index = 0; index < UserMenu.Count; index++)
            {
                if (choiceNumber.ToString() == UserMenu[index].ChoiceNumber.ToString())
                { return index; }
            }
            return -1;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (ChefUserMenu choice in UserMenu)
            {
                result.Append(choice.ChoiceNumber)
                  .Append("- ")
                  .Append(choice.TitleOfChoice)
                  .AppendLine();
            }
            return result.ToString();
        }

    }

}
