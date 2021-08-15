using System;
using System.Collections.Generic;
using System.Linq;

namespace DrinkingMachine.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Machine
    {
        public List<Product> Products { get; set; }
        public List<Coin> Coins { get; set; }
        public List<Coin> CustomerCoins { get; set; }
        public List<Coin> ChangeCoins { get; set; }

        /// <summary>
        /// Base Machine class. Products and coins are added via overides
        /// </summary>
        public Machine()
        {
            //set products
            Products = new List<Product>();
                      
            //set coins
            Coins = new List<Coin>();

            //set customer coins
            CustomerCoins = new List<Coin>();
            ChangeCoins = new List<Coin>();

        }

        /// <summary>
        /// Start the machine with base products and coins
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="coins">List os coins</param>
        public Machine(List<Product> products, List<Coin> coins)
        {
            Products = products;
            Coins = coins;
            CustomerCoins = new List<Coin>();
        } 

       

    }

    
}
