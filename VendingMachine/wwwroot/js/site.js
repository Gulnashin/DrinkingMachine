//setup connection with SignalR hub uses signalr.js
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/drinkingHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();
connection.start().catch(err => console.error(err.toString()));

//Start vue app users vue.js
var app = new Vue({
    el: '#app',
    data: {
        message: 'Please insert coins, no credit',
        machine: {products:[],coins:[],customerCoins:[],changeCoins:[]},
        totalInserted: 0,
        totalChange: 0,
        lowOnCoins: false

    },
    methods: {
        insertCoin: function (coin) {
            connection.invoke("ReceivedCoin", coin.cents).catch(err => console.error(err.toString()));
        },
        validate: function (product)
        {
            connection.invoke("Validate", product).catch(err => console.error(err.toString()));
            //display msg;
        },
        selectProduct: function (product) {

            connection.invoke("ReceivedSale", product).catch(err => console.error(err.toString()));
        },
        restock: function () {
            connection.invoke("Restock").catch(err => console.error(err.toString()));
        },
        cancel: function () {

            //cancel and return change
            connection.invoke("Cancel",true).catch(err => console.error(err.toString()));
        }


    },
    beforeCreate: function() {
        var vm = this;
        console.log('Before Create');

        //Respond to returning data from websocket;    
        connection.on("ReceiveMessage", (message) => {
            console.log('Message from websocket');
            console.log(message);

            //update machine;
            vm.machine = message;

            //set accumlated values
           
            if (vm.machine.customerCoins && vm.machine.customerCoins.length > 0) {
                vm.totalInserted = vm.machine.customerCoins.reduce(function (accumulator, coin) {
                    return accumulator + coin.totalCents;
                }, 0);
            } else {
                vm.totalInserted = 0;
            }

            if (vm.machine.changeCoins && vm.machine.changeCoins.length > 0) {
                vm.totalChange = vm.machine.changeCoins.reduce(function (accumulator, coin) {
                    return accumulator + coin.totalCents;
                }, 0);
            } else {
                vm.totalChange = 0;
            }

            //set instructions
            
            if (vm.totalInserted > 250) {
                vm.message = "Select a product or insert more credit";
            } else if (vm.totalInserted > 0) {
                vm.message = "Please insert coins, insufficent credit";
            } else
            {
                vm.message = "Please insert coins, no credit";
            }

           
        });
    },
    created: function() {
        console.log('Created');
        //show app
        document.getElementById('app').classList.remove("notready");
    }
});