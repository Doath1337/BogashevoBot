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
    private static string Token { get; set; } = "5596761923:AAGS2QcKN3TP8IGOPH5JstPMkMeBq7M0qo4";
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
        DataBase db = new DataBase();

        if (msg.Text !=null)
        {
            Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
            switch (msg.Text)
            {
                case "Авторизация":
                    // здесь будет авторизация
                default:
                    await Quiz.HandleQuizMessage(client, sender, e,db);
                    break;
            }
        }
        else
        {

        }
    }
}