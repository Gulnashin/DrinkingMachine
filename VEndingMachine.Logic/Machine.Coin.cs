using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkingMachine.Logic
{
    /// <summary>
    /// Main machine class coin functions
    /// </summary>
   public partial class Machine
   {

        /// <summary>
        /// Called when a customer inserts a coin
        /// </summary>
        /// <param name="coin"></param>
        /// <returns>Total inserted value in cents</returns>
        public int CoinInsertCustomer(Coin coin)
        {
            if (CustomerCoins.Count == 0)
            {
                CustomerCoins.Add(coin);
            }
            else
            {
                if (CustomerCoins.Where(x => x.Cents == coin.Cents).Count() == 0)
                {
                    CustomerCoins.Add(coin);
                }
                else
                {
                    CustomerCoins.Where(x => x.Cents == coin.Cents).Single().Quantity++;
                }
            }

            //reset
            ChangeCoins = new List<Coin>();

            return CustomerCoinsValue();
        }

        /// <summary>
        /// Called when customer inserted money is transferred to machine
        /// </summary>
        /// <param name="coin"></param>
        public void CoinInsertMachine(Coin coin)
        {
            //if empty
            if (Coins.Count == 0)
            {
                Coins.Add(coin);
            }
            else
            {
                //check if coins of the same value are in machine
                if (Coins.Where(x => x.Cents == coin.Cents).Count() == 0)
                {
                    Coins.Add(coin);
                }
                else
                {
                    //add to existing coins
                    //insert of machine coin can have multipe coins of the same type at once.
                    Coins.Where(x => x.Cents == coin.Cents).Single().Quantity += coin.Quantity;
                }
            }


        }

        /// <summary>
        /// Called when change is dispursed
        /// </summary>
        /// <param name="coin"></param>
        public void RemoveCoin(Coin coin)
        {
            if (Coins.Where(x => x.Cents == coin.Cents).Count() > 0)
            {
                Coins.Where(x => x.Cents == coin.Cents).Single().Quantity -= coin.Quantity;
            }


        }

        /// <summary>
        /// Sum value of customer inserted coins in cents
        /// </summary>
        /// <returns></returns>
        public int CustomerCoinsValue()
        {
            if (CustomerCoins.Count == 0)
            {
                return 0;
            }
            else
            {
                //sum the accumulated total cents per coin value
                return CustomerCoins.Sum(x => x.TotalCents);
            }
        }
    }
}
