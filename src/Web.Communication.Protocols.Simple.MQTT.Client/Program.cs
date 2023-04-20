using MQTTnet.Client;
using MQTTnet;
using System.Text.Json;

Console.WriteLine("Hello, World!");

var mqttFactory = new MqttFactory();

using (var mqttClient = mqttFactory.CreateMqttClient())
{
    var mqttClientOptions = new MqttClientOptionsBuilder()
        .WithTcpServer("localhost")
        .Build();

    await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

    int choice;

    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("1. Masterclass");
        Console.WriteLine("2. Assist");
        Console.WriteLine("3. USV");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice (1-4): ");
        choice = Convert.ToInt32(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Green;
        MqttApplicationMessage applicationMessage = null;

        switch (choice)
        {
            case 1:
                applicationMessage = new MqttApplicationMessageBuilder()
                     .WithTopic("masterclasstopic")
                     .WithPayload("Hi from masterclasstopic")
                     .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                break;
            case 2:

                applicationMessage = new MqttApplicationMessageBuilder()
                     .WithTopic("assisttopic")
                     .WithPayload("Hi from assist")
                     .Build();
                break;
            case 3:

                applicationMessage = new MqttApplicationMessageBuilder()
                     .WithTopic("usvtopic")
                     .WithPayload("Hi from usvtopic")
                     .Build();

                break;
        }

        var message = await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

        Console.WriteLine($"{JsonSerializer.Serialize(message)}");

        Console.ReadKey();

    } while (choice != 4);


    await mqttClient.DisconnectAsync();

    Console.WriteLine("MQTT application message is published.");
}