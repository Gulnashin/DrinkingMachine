# Drinking-Machine-Demo
A demo of Drinking machine logic. Based on .Net Core, Vue and SignalR. UI is very limited/absent. Bootstrap CSS is used for some basics

Open the solution file (DrinkingMachine.sln) with Visual Studio 2017 or higher. 
Hit F5 Debug to run.
Notes:

All the Vue code is in site.js located in the wwwwroot/js folder of the Drinking machine web application project
All C# logic is in the Drinking.Machine.Logic project.
Tests are in the Unit tests project.
A SignalR websocket connection is used for the connection of UI with the Server. Logic for that is in the Hub.cs file located in the DrinkingMachine project root.
Cancel will return the same inserted coins.
Change with a purchase is based on less coins possible.

Not added:
Security for clients via SignalR is not implemented. 
No Database or storage used. All runs in memory. To reset to default values just hit the red button or refresh teh page.
A better ui and mobile friedly. 
UI Logic does not include stock checks now.
Reconnection logic for web sockets in case of failure. So having a long session might break the connection and a refresh of the window is needed.
Tighter integration with node and vue based on parcel js, vuex and vue templates

