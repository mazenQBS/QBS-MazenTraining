using System;
using System.Collections.Generic;
using QBS_training_help;

namespace QBS_training_restaurant
{

    //class Restaurant 
    //{
    //    string plate;

    
    
    //}

    //class Customer {
    //    string _name;
    //    Order _order;

    //    Customer() {
    //        _name = "";
    //        //order = new List<Order>();
    //    }
    //    public string name { get { return _name; } set { _name = value; } }

    //    public Order order { get { return _order; } set { _order = value; } }
        

    //}

    //class Item {
    //    string _itemName;
    //    int _quantity;
    //    double _price;
    //    int _itemNumber;
    //    //Chef _chef;

    //    public Item()
    //    {
    //         _itemName="";
    //         _quantity=0;
    //         _price=0.0;
    //        _itemNumber = 0;
    //        //_chef = new Chef();
    //    }

    //    public Item(int itenNumber,string itemName,int quantity,double price) 
    //    {
    //        _itemName=itemName;
    //        _quantity=quantity;
    //        _price=price;
    //        itemNumber++;
    //    }
    //    public string itemName{ get { return _itemName; } set { _itemName = value; } }

    //    public int quantity { get { return _quantity; } set { _quantity = value; } }

    //    public double price { get { return _price; } set { _price = value; } }

    //    public int itemNumber { get { return _itemNumber; } set { _itemNumber = value; } }

    //    //public Chef chef { get { return _chef; } set { _chef = value; } }

    //    public override string  ToString() 
    //    { 
    //        return 
    //            itemNumber+help.space(itemNumber.ToString(),15)+" | "+
    //            itemName+help.space(itemName,15)+" | "+
    //            quantity+help.space(quantity.ToString(),15)+" | "+
    //            price; 
    //    }

        
    
    //}

    //class Order {

    //    List<Item> items;
    //    int _itemNumber;
    //    static int _orderNumber=0;

    //    public Order() {
    //        _orderNumber++;
    //        items = new List<Item>();
    //        itemNumber = 0;
        
    //    }

    //    public int itemNumber { get { return _itemNumber; }set { _itemNumber = value; } }
        
    //    /*
    //    public string addItem(string itemName, int quantity, double price)
    //    {
    //        Item newOrder = new Item(itemName, quantity, price);
    //        items.Add(newOrder);
    //        return help.doneMessage("The item has been successfully added");
    //    */
    //    }



    //public string orderTitle()
    //{
    //    return "itemName" + help.space("itemName", 15) + " | " + "quantity" + help.space("quantity", 15) + " | " + "price";
    //}


    interface IUserMenu {
        public void Add_Choice(object userChoice, string choiceTitle);
        public void Delete_Choice(object userChoice);
        public int IndexOf(object userChoice);

    }

    abstract class Chef
    {
        public string Chif_name { get; set; }
        public string Food_Plate { get; set; }
        public abstract string Print_Chef_Of_The_Order();


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
            Title = "";
        }        
        public ChefUserMenu(object userChoice, string choiceTitle, Chef objectDriver)
        {
            User_Choice = userChoice;
            Object_Driver = objectDriver;
            User_Menu_List = new List<ChefUserMenu>();
            Title = choiceTitle;
        }
        public object User_Choice { get; set; }
        public Chef Object_Driver { get; set; }
        public List<ChefUserMenu> User_Menu_List { get; set; }
        public string Title { get ; set ; }
        public void Add_Choice(object userChoice, string choiceTitle)
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

            string result = "";
            foreach (ChefUserMenu x in User_Menu_List)
            {
                result += x.User_Choice + "- " + x.Title + "\n";
            }
            return result;
        }

    }

    class ItalianChef :Chef
    {
        public override string Print_Chef_Of_The_Order()
        {
            return Help.doneMessageFormat("The order is prepared by a chef who is an expert in the Italian dish");
        }
    }

    class IndianChef :Chef
    {
        public override string Print_Chef_Of_The_Order()
        {
            return Help.doneMessageFormat ("The order is prepared by a chef who is an expert in the Indian dish");
        }
    }

    class ArabicChef :Chef
    {
        public override string Print_Chef_Of_The_Order()
        {
            return Help.doneMessageFormat ("The order is prepared by an expert chef in the Arabic dish");
        }

    }





    














}
