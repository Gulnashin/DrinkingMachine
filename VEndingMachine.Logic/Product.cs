using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkingMachine.Logic
{

    /// <summary>
    /// The product object with price in cents
    /// </summary>
    public class Product
    {   public int Id { get; set;}
        public string Title { get; set; }
        public int Price { get; set; }
        public int Stock { get; set;}
        public bool AvailStock { get; set; }

    }
}
