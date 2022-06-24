using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InputFiles;

namespace testbot2;

class Program
{
    private static string Token { get; set; } = "KEY";
    private static TelegramBotClient client;
    
    static void Main(string[] args)
    {
         
        client = new TelegramBotClient(Token);
        client.StartReceiving();
        client.OnMessage += OnMessageHandler;
        Console.ReadLine();
        client.StopReceiving();
    }

    public static async void OnMessageHandler(object sender, MessageEventArgs e)
    {

        var msg = e.Message;
  

        if (msg.Text !=null)
        {
            Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
            switch (msg.Text)
            {
                case "Авторизация":
                    // здесь будет авторизация
                default:
                    await Quiz.HandleQuizMessage(client, sender, e);
                    break;
            }
        }
        else
        {

        }
    }
}