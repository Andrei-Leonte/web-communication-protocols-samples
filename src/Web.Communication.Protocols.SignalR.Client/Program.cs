// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;

var url = "http://localhost:7010/api";

var connection = new HubConnectionBuilder()
    .WithUrl(url)
    .WithAutomaticReconnect()
    .Build();

connection.On<string>("AssistTrigger", message => Console.WriteLine($"AssistTrigger: {message}"));
connection.On<string>("USVTrigger", message => Console.WriteLine($"USVTrigger: {message}"));
connection.On<string>("Masterclass", message => Console.WriteLine($"Masterclass: {message}"));

bool isConnected = false;

while (true)
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Connect");
    Console.WriteLine("2. Send Message to AssistTrigger");
    Console.WriteLine("3. Send Message to USVTrigger");
    Console.WriteLine("4. Send Message to Masterclass");
    Console.WriteLine("5. Exit");

    int option;

    if (int.TryParse(Console.ReadLine(), out option))
    {
        switch (option)
        {
            case 1:
                if (!isConnected)
                {
                    isConnected = await Connect(connection);
                }
                else
                {
                    Console.WriteLine("Already connected.");
                }
                break;
            case 2:
                if (isConnected)
                {
                    await SendMessage(connection, "AssistTrigger");
                }
                else
                {
                    Console.WriteLine("Not connected.");
                }
                break;
            case 3:
                if (isConnected)
                {
                    await SendMessage(connection, "USVTrigger");
                }
                else
                {
                    Console.WriteLine("Not connected.");
                }
                break;
            case 4:
                if (isConnected)
                {
                    await SendMessage(connection, "Masterclass");
                }
                else
                {
                    Console.WriteLine("Not connected.");
                }
                break;
            case 5:
                Console.WriteLine("Exiting...");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

static async Task<bool> Connect(HubConnection connection)
{
    Console.WriteLine("Connecting...");

    try
    {
        await connection.StartAsync();
        Console.WriteLine("Connected.");
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return false;
    }
}

static async Task SendMessage(HubConnection connection, string target)
{
    Console.Write("Enter your message: ");
    string message = Console.ReadLine();

    try
    {
        await connection.InvokeAsync(target, message);
        Console.WriteLine($"Message sent to {target}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}