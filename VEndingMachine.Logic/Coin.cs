using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DrinkingMachine.Logic
{
    /// <summary>
    /// The coin object which can represent multipe coins of the same value in cents. Totalcents is accumulated
    /// </summary>
    public class Coin
    {
        private int _quantity;

        public int Cents { get; set;}

        public string Name { get; set; }

        public int Quantity {
            get { return _quantity; }
            set
            {
                _quantity = value;
                TotalCents = value * Cents;
            }
        }
        public int TotalCents { get; private set; }

     
    }
}
