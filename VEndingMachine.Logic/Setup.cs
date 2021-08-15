using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkingMachine.Logic
{

   public partial class Machine
   {
        /// <summary>
        /// Start machine with base values
        /// </summary>
        /// <returns></returns>
        public static Machine StartMachine()
        {
            //set products
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Title = "Coke", Price = 250, Stock = 5 , AvailStock =true});
            products.Add(new Product { Id = 2, Title = "Pepsi", Price = 360, Stock = 15, AvailStock = true });
            products.Add(new Product { Id = 3, Title = "Soda", Price = 450, Stock = 3, AvailStock = true });
           
            //set coins
            List<Coin> coins = new List<Coin>();
           
            coins.Add(new Coin { Cents = 1, Name ="Penny",  Quantity = 100 }); //cents
            coins.Add(new Coin { Cents = 20, Name = "Nickle", Quantity = 10 }); //nickle
            coins.Add(new Coin { Cents = 10, Name = "Dime", Quantity = 5 }); // dims
            coins.Add(new Coin { Cents = 25, Name = "Quarter", Quantity = 25 }); // quarters

            Machine machine = new Machine(products,coins);

            return machine;
        } 

   }
}
