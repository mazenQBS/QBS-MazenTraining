using System;
using System.Collections.Generic;
using System.Text;
using QBS_training_restaurant;

namespace QBS_training_help
{
    public class help
    {
        public static string space(string word, int totalSize)
        {
            string result = "";
            int spaceSize = totalSize - word.Length;

            for (int i = 0; i < spaceSize; i++) {
                result += " ";
            }
            return result;
        }

        public static string halfSpace(string word, int totalSize) {
            string result = "";
            int spaceSize = totalSize - word.Length;

            for (int i = 0; i < (spaceSize / 2); i++)
            {
                result += " ";
            }
            return result;

        }
        public static string doneMessage(string messag) {

            string resut;
            resut = "\n****************************************************************************************************\n";
            resut += halfSpace(messag, 100);
            resut += messag + "\n****************************************************************************************************\n";
            return resut;
        }
    }

    public class  ChefUserMenu
    {
        object _userChoice;
        string _title;
        Chef _objectDriver;
        List<ChefUserMenu> _userMenuList;


        public ChefUserMenu() {
            userChoice = -1;
            objectDriver = null;
            userMenuList = new List<ChefUserMenu>();
            title = "";
        }

        public ChefUserMenu(object userChoice,string choiceTitle,Chef objectDriver)
        {
            this.userChoice = userChoice;
            _objectDriver = objectDriver;
            userMenuList = new List<ChefUserMenu>();
            title = choiceTitle;
        }

        public object userChoice { get { return _userChoice; } set { _userChoice = value; } }

        public Chef objectDriver { get { return _objectDriver; } set { _objectDriver = value; } }
        
        public List<ChefUserMenu> userMenuList { get { return _userMenuList; } set { _userMenuList = value; } }

        public string title { get { return _title; } set { _title = value; } }

        public void addChoice(object userChoice,string choiceTitle,Chef objectDriver) {
            ChefUserMenu newItem = new ChefUserMenu(userChoice,choiceTitle,objectDriver);
            userMenuList.Add(newItem);
        }

        public void deleteChoice(object userChoice) {

            int index = indexOf(userChoice);
            if ( index== -1)
            {
                Console.WriteLine("this choice not exist");
            }
            else
            {
                userMenuList.RemoveAt(index);
                Console.WriteLine("this choice is deleted");
            
            }
        
        }

        public int indexOf(object userChoice) {

            int i;
            for (i = 0; i < userMenuList.Count; i++) {
                if (userChoice.ToString() == userMenuList[i].userChoice.ToString())
                { return i; }
            }
            return -1;
        }

        public override string ToString() {

            string result = "";
            foreach (ChefUserMenu x in userMenuList) {
                result += x.userChoice + "- " + x.title + "\n";           
            }
            return result;
        }
    
    }


}


