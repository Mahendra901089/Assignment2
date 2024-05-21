using System;
using System.Collections.Generic;

namespace Assignment2
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public Item(int id, string name, float price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Display()
        {
            Console.WriteLine($"ID:{ID}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Price:{Price}");
            Console.WriteLine($"Quantity:{Quantity}");
        }
    }
    public class Inventory
    {
        private List<Item> items;
        public Inventory()
        {
            items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void DisplayAllItems()
        {
            foreach(var item in items)
            {
                item.Display();
                Console.WriteLine();
            }
        }
        public Item FindItemById(int id)
        {
            return items.Find(Item => Item.ID == id);
        }
        public void UpdateItem(int id,string name,float price,int quantity)
        {
            var item = FindItemById(id);
            if(item!=null)
            {
                item.Name = name;
                item.Price = price;
                item.Quantity = quantity;
            }
            else
            {
                Console.WriteLine($"Item with ID {id} not found!");
            }
        }
        public void DeleteItem(int id)
        {
            var item = FindItemById(id);
            if(item!= null)
            {
                items.Remove(item);
            }
            else
            {
                Console.WriteLine($"Item with ID {id} not found!");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            while(true)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1.Add Item");
                Console.WriteLine("2.Display All Items");
                Console.WriteLine("3.Find Item by ID");
                Console.WriteLine("4.Update Item");
                Console.WriteLine("5.Delete Item");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter ID:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Price:");
                        float price = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Quantity");
                        int quantity = int.Parse(Console.ReadLine());
                        inventory.AddItem(new Item(id, name, price, quantity));
                        break;

                    case 2:
                        inventory.DisplayAllItems();
                        break;

                    case 3:
                        Console.Write("Enter ID to find:");
                        id = int.Parse(Console.ReadLine());
                        var item = inventory.FindItemById(id);
                        if(item!= null)
                        {
                            item.Display();
                        }
                        else
                        {
                            Console.WriteLine($"Item with ID {id} not found! ");
                        }
                        break;

                    case 4:
                        Console.Write("Enter ID to update:");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Name:");
                        name = Console.ReadLine();
                        Console.Write("Enter new Price:");
                        price = float.Parse(Console.ReadLine());
                        Console.Write("Enter new Quantity:");
                        quantity = int.Parse(Console.ReadLine());
                        inventory.UpdateItem(id, name, price, quantity);
                        break;

                    case 5:
                        Console.Write("Enter ID to delete:");
                        id = int.Parse(Console.ReadLine());
                        inventory.DeleteItem(id);
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }

}
