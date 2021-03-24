using System;
using System.Collections.Generic;

namespace Shopping_List
{
    class Program
    {


        static void Main(string[] args)
        {
            /* display list of at least 8 items+
            *  ask user to enter an item name+
            *  if item exists display item and price and add item and price to users order+
            *  if item doesn't exist display an error and reprompt user, display menu again+
            *  ask if they want to add another+
            *  when done adding items, displya a list of all items ordered with prices in columns+
            *  display the average price of tiems ordered+
            *  app uses dictionary to keep track of menue items+
            *  app uses parallel arraylists to store items ordered and price+
            *  app take name input and responds that the item doesn't exist or adds it's name and price to a relevent list+
            *  app asks user if they want to quit or continue+
            *  app displays list of items with prices+
            *  app displays correct average for list+
            *  ===============================
            *  implement a menue system so user can enter a letter or number for the item -
            *  make a third list for quantities of items and allow user to order more than one at a time==
            *  if order is already in cart, increase the quantity rather than adding another entry==
            *  display the most and least expensive item== 
            */

            //setting variables

            Dictionary<string, decimal> menuItems = new Dictionary<string, decimal>();  //main dictionary
            menuItems.Add("apple", 0.99m);
            menuItems.Add("banana", 0.59m);
            menuItems.Add("cauliflower", 1.59m);
            menuItems.Add("dragonfruit", 2.19m);
            menuItems.Add("elderberry", 1.79m);
            menuItems.Add("figs", 2.09m);
            menuItems.Add("grapefruit", 1.99m);
            menuItems.Add("honeydew", 3.49m);

            List<string> shoppingCart = new List<string>();

            List<decimal> bill = new List<decimal>();


            int i;
            bool loop = true;
            string input;
            int selection;
            decimal total = 0.00m;
            decimal average = 0.00m;


            Console.WriteLine("Welcome to Guenther's Market!");



            while (loop == true)  //loop to continue the program
            {
                bool validLoop = false;  //resetting for the loop


                while (validLoop == false)
                {
                    i = 1;

                    Console.WriteLine($"\nNo.\tItem\t\tPrice\n==============================");  //menue
                    foreach (var item in menuItems)
                    {
                        if (item.Key.Length < 8)
                        {

                            Console.WriteLine($"{i}\t{item.Key}\t\t${item.Value}"); //for shorter entries
                        }
                        else
                        {
                            Console.WriteLine($"{i}\t{item.Key}\t${item.Value}");  //for longer entries
                        }
                        i++;
                    }

                    Console.Write("\nWhat item would you like to order? ");   // order entry input

                    input = Console.ReadLine();

                    if (Int32.TryParse(input, out selection) && selection <= menuItems.Count && selection > 0)  //checking to see if a number and in the range
                    {
                        int connector = 1;  //counter to match up with input

                        foreach (var item in menuItems)  //cycling through dictionary
                        {
                            
                            if (connector == selection)  // if it matches then the following
                            {

                                shoppingCart.Add(item.Key);
                                bill.Add(item.Value);

                                Console.Write($"Adding {item.Key} to cart at ${menuItems[item.Key]}");  //displaying what they ordered
                            }

                            connector++;
                        }

                        

                        validLoop = true;
                    }
                    else if (menuItems.ContainsKey(input))
                    {

                        shoppingCart.Add(input);
                        bill.Add(menuItems[input]);

                        Console.Write($"Adding {input} to cart at ${menuItems[input]}");  //displaying what they ordered

                        validLoop = true;

                    }
                    else
                    {
                        Console.WriteLine("\nSorry, we don't have those. Please try again.");
                    }

                }
                Console.Write($"\n\nWould you like to order anything else? (y/n)? ");  // continue question

                string input2 = Console.ReadLine();

                if (input2.Contains("n"))             //ending loop if they don't want to continue
                {

                    Console.Write($"\nThanks for your order!\nHere's what you got:\n=============================\n");

                    for (int j = 0; j < shoppingCart.Count; j++)
                    {

                        if (shoppingCart[j].Length < 8)
                        {

                            Console.WriteLine($"{j+1}\t{shoppingCart[j]}\t\t${bill[j]}"); //for shorter entries
                        }
                        else
                        {
                            Console.WriteLine($"{j+1}\t{shoppingCart[j]}\t${bill[j]}");  //for longer entries
                        }

                        total = total + bill[j];
                        
                    }
                    average = total / shoppingCart.Count;
                    Console.WriteLine("=============================");
                    Console.Write($"Your total today is: ${total}\nAverage price is ${Math.Round(average, 2)}\n\n");


                    Console.WriteLine("\nHave a great day!");
                    loop = false;
                }


            }


        }
    }
}
