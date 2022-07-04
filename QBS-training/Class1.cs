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


    interface UserMenu {
        public void addChoice(object userChoice, string choiceTitle);
        public void deleteChoice(object userChoice);
        public int indexOf(object userChoice);

    }

    abstract class Chef
    {
        string _chifName;
        string _foodPlate;

        public string chifName { get { return _chifName; } set { _chifName = value; } }
        public string foodPlate { get { return _foodPlate; } set { _foodPlate = value; } }        
        public abstract string PrintChefOfTheOrder();


    }

    class ChefUserControl { 
        public ChefUserMenu _userMenu;
        public ChefUserControl() { userMenu = new ChefUserMenu(); }

        public ChefUserMenu userMenu { get { return _userMenu; } set{ _userMenu=value; }}
    }

    class ChefUserMenu :UserMenu
    {
        object _userChoice;
        string _title;
        Chef _objectDriver;
        List<ChefUserMenu> _userMenuList;


        public ChefUserMenu()
        {
            userChoice = -1;
            objectDriver = null;
            userMenuList = new List<ChefUserMenu>();
            title = "";
        }
        //ChefPrint
        public ChefUserMenu(object userChoice, string choiceTitle, Chef objectDriver)
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

        //ChefPrint
        public void addChoice(object userChoice, string choiceTitle)
        {
            if (objectDriver == null)
            { Console.WriteLine("Error : objectDriver = null"); }
            else { 
            ChefUserMenu newItem = new ChefUserMenu(userChoice, choiceTitle, objectDriver);
            userMenuList.Add(newItem);
                }
        }

        public void deleteChoice(object userChoice)
        {

            int index = indexOf(userChoice);
            if (index == -1)
            {
                Console.WriteLine("this choice not exist");
            }
            else
            {
                userMenuList.RemoveAt(index);
                Console.WriteLine("this choice is deleted");

            }

        }

        public int indexOf(object userChoice)
        {

            int i;
            for (i = 0; i < userMenuList.Count; i++)
            {
                if (userChoice.ToString() == userMenuList[i].userChoice.ToString())
                { return i; }
            }
            return -1;
        }

        public override string ToString()
        {

            string result = "";
            foreach (ChefUserMenu x in userMenuList)
            {
                result += x.userChoice + "- " + x.title + "\n";
            }
            return result;
        }

    }

    class ItalianChef :Chef
    {
        public override string PrintChefOfTheOrder()
        {
            return help.doneMessageFormat("The order is prepared by a chef who is an expert in the Italian dish");
        }
    }

    class IndianChef :Chef
    {
        public override string PrintChefOfTheOrder()
        {
            return help.doneMessageFormat ("The order is prepared by a chef who is an expert in the Indian dish");
        }
    }

    class ArabicChef :Chef
    {
        public override string PrintChefOfTheOrder()
        {
            return help.doneMessageFormat ("The order is prepared by an expert chef in the Arabic dish");
        }

    }





    














}
