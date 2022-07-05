using System;
using System.Text;
using System.Collections.Generic;
using QBS_training_Help;

namespace QBS_training_restaurant
{

    interface IUserMenu {
        public void Add_Choice(object userChoice, StringBuilder choiceTitle);
        public void Delete_Choice(object userChoice);
        public int IndexOf(object userChoice);    

    }

    abstract class Chef
    {
        public StringBuilder Chif_name { get; set; }
        public StringBuilder Food_Plate { get; set; }
        public abstract StringBuilder Print_Chef_Of_The_Order();


    }

    class ChefUserControl { 
        public ChefUserMenu User_Menu { get; set; }
        public ChefUserControl() { User_Menu = new ChefUserMenu(); }
        public Chef Get_Object(int choice) {
            return User_Menu.User_Menu_List[User_Menu.IndexOf(choice)].Object_Driver;
        }
        
    }

    class ChefUserMenu :IUserMenu
    {
        public ChefUserMenu()
        {
            User_Choice = -1;
            Object_Driver = null;
            User_Menu_List = new List<ChefUserMenu>();
            Title = new StringBuilder();
        }        
        public ChefUserMenu(object userChoice, StringBuilder choiceTitle, Chef objectDriver)
        {
            User_Choice = userChoice;
            Object_Driver = objectDriver;
            User_Menu_List = new List<ChefUserMenu>();
            Title = choiceTitle;
        }
        public object User_Choice { get; set; }
        public Chef Object_Driver { get; set; }
        public List<ChefUserMenu> User_Menu_List { get; set; }
        public StringBuilder Title { get ; set ; }
        public void Add_Choice(object userChoice, StringBuilder choiceTitle)
        {
            if (Object_Driver == null)
            { Console.WriteLine("Error : objectDriver = null"); }
            else { 
            ChefUserMenu newItem = new ChefUserMenu(userChoice, choiceTitle, Object_Driver);
            User_Menu_List.Add(newItem);
                }
        }
        public void Delete_Choice(object userChoice)
        {

            int index = IndexOf(userChoice);
            if (index == -1)
            {
                Console.WriteLine("this choice not exist");
            }
            else
            {
                User_Menu_List.RemoveAt(index);
                Console.WriteLine("this choice is deleted");

            }

        }
        public int IndexOf(object userChoice)
        {

            int i;
            for (i = 0; i < User_Menu_List.Count; i++)
            {
                if (userChoice.ToString() == User_Menu_List[i].User_Choice.ToString())
                { return i; }
            }
            return -1;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (ChefUserMenu x in User_Menu_List)
            {
                result.Append(x.User_Choice)
                  .Append("- ")
                  .Append(x.Title)
                  .AppendLine();
            }
            return result.ToString();
        }

    }

    class ItalianChef :Chef
    {
        public override StringBuilder Print_Chef_Of_The_Order()
        { return Help.Done_Message_Format(new StringBuilder("The order is prepared by a chef who is an expert in the Italian dish")); }
    }

    class IndianChef :Chef
    {
        public override StringBuilder Print_Chef_Of_The_Order()
        { return Help.Done_Message_Format(new StringBuilder("The order is prepared by a chef who is an expert in the Indian dish")); }
        
    }

    class ArabicChef :Chef
    {
        public override StringBuilder Print_Chef_Of_The_Order()
        { return Help.Done_Message_Format(new StringBuilder("The order is prepared by an expert chef in the Arabic dish")); }

    }





    














}
