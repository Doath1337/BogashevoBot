using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using System.Data.SqlClient;
using System.Data;
using Telegram.Bot.Types.ReplyMarkups;

namespace testbot2;

internal static class Test
{
    
    internal static  async Task frst(TelegramBotClient client, object sender, MessageEventArgs e,  int cnt)
    {
        
        var frstQuestionkeyboard = new InlineKeyboardMarkup(new[] {
            new[]
           {
                InlineKeyboardButton.WithCallbackData("1593", "a"),
                InlineKeyboardButton.WithCallbackData("1604", "b"),
                 InlineKeyboardButton.WithCallbackData("1646", "c")

            }
            });
        var msg = e.Message;
        client.SendTextMessageAsync(msg.Chat.Id, "Год основанимя Богашево? ", replyMarkup: frstQuestionkeyboard);

        client.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
        {
            var msg = ev.CallbackQuery.Message;
            if (ev.CallbackQuery.Data == "c")
            {
                cnt += 1;
                 Test.scnd(client, sender, e, cnt);
                
            }
            else
            {
                 Test.scnd(client, sender, e, cnt);
            }                          
        };
    }

    internal static async Task scnd(TelegramBotClient client, object sender, MessageEventArgs e, int cnt)
    {
        var scndQuestionkeyboard = new InlineKeyboardMarkup(new[] {
            new[]
           {
                InlineKeyboardButton.WithCallbackData("Кузнеца", "a"),
                InlineKeyboardButton.WithCallbackData("Пахаря", "b"),
                 InlineKeyboardButton.WithCallbackData("Мельника", "c")

            }
            });
        var msg = e.Message;
        client.SendTextMessageAsync(msg.Chat.Id, "В честь чьей фамилии было названо Федосеево? ", replyMarkup: scndQuestionkeyboard);

        client.OnCallbackQuery +=  (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
        {
            var msg = ev.CallbackQuery.Message;
            if (ev.CallbackQuery.Data == "b")
            {
                cnt += 1;
                 Test.thrd(client, sender, e, cnt);
                
            }
            else
            {
                Test.thrd(client, sender, e, cnt);
            }


        };
    }

    internal static async Task thrd(TelegramBotClient client, object sender, MessageEventArgs e, int cnt)
    {
        var scndQuestionkeyboard = new InlineKeyboardMarkup(new[] {
            new[]
           {

                InlineKeyboardButton.WithCallbackData("Машинистом", "a"),
                InlineKeyboardButton.WithCallbackData("Инженер-технолог", "b"),
                 InlineKeyboardButton.WithCallbackData("Начальник железной дороги", "c")

            }
            });
        var msg = e.Message;
        client.SendTextMessageAsync(msg.Chat.Id, "Кем был Степан Михайлович Богашев? ", replyMarkup: scndQuestionkeyboard);

        client.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
        {
            var msg = ev.CallbackQuery.Message;
            if (ev.CallbackQuery.Data == "b" || ev.CallbackQuery.Data == "c")
            {
                cnt += 1;
                client.SendTextMessageAsync(msg.Chat.Id, text: $"Вы набрали {cnt} /4 баллов");
                
            }
            else
            {
                client.SendTextMessageAsync(msg.Chat.Id, text: $"Вы набрали {cnt} /4 баллов");
                 //Quiz.HandleQuizMessage(client, sender, e);
            }


        };
    }


}
