using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DrinkingMachine.Logic;
namespace DrinkingMachine
{
    /// <summary>
    /// The SignalR hub which is called via a websocket
    /// </summary>
    public class DrinkingHub : Hub
    {
        /// <summary>
        /// Send message returns the currect machine object in the server
        /// </summary>
        /// <returns></returns>
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage", Program.DrinkingMachine);
        }

        /// <summary>
        /// Called when a coin is inserted. Communicates the updated machine object back to the user
        /// </summary>
        /// <param name="cents">the cents the coin represents</param>
        /// <returns></returns>
        public async Task ReceivedCoin(int cents)
        {
            Program.DrinkingMachine.CoinInsertCustomer(new Coin { Cents = cents, Quantity = 1});
            await SendMessage();
           
        }

        /// <summary>
        /// Called when a sale is made. Communicates the updated machine object back to the user
        /// </summary>
        /// <param name="id">The id from the product object</param>
        /// <returns></returns>
        public async Task ReceivedSale(int id)
        {
            Program.DrinkingMachine.MakeSale(id);

            await SendMessage();
        
        }

        /// <summary>
        /// Reset the machine with base value. Communicates the updated machine object back to the user
        /// </summary>
        /// <returns></returns>
        public async Task Restock()
        {
            Program.DrinkingMachine = Machine.StartMachine();

            await SendMessage();

        }
        /// <summary>
        /// Cancel purchase remove coins 
        /// </summary>
        /// <returns></returns>
        public async Task Cancel(bool withchange)
        {
            if (withchange) {
                Program.DrinkingMachine.ChangeCoins = Program.DrinkingMachine.CustomerCoins;
            }

            Program.DrinkingMachine.CustomerCoins = new List<Coin>();

            await SendMessage();

        }
        //validate
        public async Task Validate(int id)
        {
            Program.DrinkingMachine.ValidateStock(id);

            await SendMessage();

        }

        //default function
        public Task SendMessageToGroups(string message)
        {
            List<string> groups = new List<string>() { "SignalR Users" };
            return Clients.Groups(groups).SendAsync("ReceiveMessage", message);
        }

        //called when  socket connects Start communication back directly
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            //reset machine coins
            await Cancel(false);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
