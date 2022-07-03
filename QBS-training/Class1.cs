using System;
using System.Collections.Generic;
using System.Text;
using QBS_training_help;

namespace QBS_training_restaurant
{

    class Restaurant 
    {
        string plate;

    
    
    }

    class Customer {
        string _name;
        Order _order;

        Customer() {
            _name = "";
            //order = new List<Order>();
        }
        public string name { get { return _name; } set { _name = value; } }

        public Order order { get { return _order; } set { _order = value; } }
        

    }

    class Item {
        string _itemName;
        int _quantity;
        double _price;
        int _itemNumber;
        //Chef _chef;

        public Item()
        {
             _itemName="";
             _quantity=0;
             _price=0.0;
            _itemNumber = 0;
            //_chef = new Chef();
        }

        public Item(int itenNumber,string itemName,int quantity,double price) 
        {
            _itemName=itemName;
            _quantity=quantity;
            _price=price;
            itemNumber++;
        }
        public string itemName{ get { return _itemName; } set { _itemName = value; } }

        public int quantity { get { return _quantity; } set { _quantity = value; } }

        public double price { get { return _price; } set { _price = value; } }

        public int itemNumber { get { return _itemNumber; } set { _itemNumber = value; } }

        //public Chef chef { get { return _chef; } set { _chef = value; } }

        public override string  ToString() 
        { 
            return 
                itemNumber+help.space(itemNumber.ToString(),15)+" | "+
                itemName+help.space(itemName,15)+" | "+
                quantity+help.space(quantity.ToString(),15)+" | "+
                price; 
        }

        
    
    }

    class Order {

        List<Item> items;
        int _itemNumber;
        static int _orderNumber=0;

        public Order() {
            _orderNumber++;
            items = new List<Item>();
            itemNumber = 0;
        
        }

        public int itemNumber { get { return _itemNumber; }set { _itemNumber = value; } }
        
        /*
        public string addItem(string itemName, int quantity, double price)
        {
            Item newOrder = new Item(itemName, quantity, price);
            items.Add(newOrder);
            return help.doneMessage("The item has been successfully added");
        */
        }



        //public string orderTitle()
        //{
        //    return "itemName" + help.space("itemName", 15) + " | " + "quantity" + help.space("quantity", 15) + " | " + "price";
        //}

    
    class Chef
    {
        string _chifName;
        string _foodPlate;
        public string chifName { get { return _chifName; } set { _chifName = value; } }
        public string foodPlate { get { return _foodPlate; } set { _foodPlate = value; } }
        public virtual string PrintChefOfTheOrder() {
            return "";
        }

    }

    class italianChef :Chef
    {
        public override string PrintChefOfTheOrder()
        {
            return help.doneMessage("The order is prepared by a chef who is an expert in the Italian dish");
        }
    }
    class indianChef :Chef
    {
        public override string PrintChefOfTheOrder()
        {
            return help.doneMessage ("The order is prepared by a chef who is an expert in the Indian dish");
        }
    }

    class arabicChef :Chef
    {
        public override string PrintChefOfTheOrder()
        {
            return help.doneMessage ("The order is prepared by an expert chef in the Arabic dish");
        }

    }

}
