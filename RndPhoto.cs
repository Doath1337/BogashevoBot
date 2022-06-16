using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
namespace testbot2;

internal static class RandomPhoto
{
    internal async static Task RandowyzePhoto(TelegramBotClient client, object sender, MessageEventArgs e, IReplyMarkup inlineKeyboard)
    {

        var msg = e.Message;
        client.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
        {
            var message = ev.CallbackQuery.Message;
            if (ev.CallbackQuery.Data == "Church")
            {
                using (FileStream fs = new FileStream(@"C:\Users\Dead Ghoul\source\repos\testbot2\testbot2\b7932667d931e24c5d850942acd2f780.jpg", FileMode.Open))
                {
                    InputOnlineFile photoToBeSent = new InputOnlineFile(fs);
                    Message msg2 = await client.SendPhotoAsync(msg.Chat.Id, photoToBeSent);

                }
                client.SendTextMessageAsync(msg.Chat.Id, "Достопримечательности", replyMarkup:inlineKeyboard);
            }
            else if (ev.CallbackQuery.Data == "School")
            {
                using (FileStream fs = new FileStream(@"C:\Users\Dead Ghoul\source\repos\testbot2\testbot2\School.jpg", FileMode.Open))
                {
                    InputOnlineFile photoToBeSent = new InputOnlineFile(fs);
                    Message msg2 = await client.SendPhotoAsync(msg.Chat.Id, photoToBeSent);

                }
            }
            else if (ev.CallbackQuery.Data == "RailwayStation")
            {
                using (FileStream fs = new FileStream(@"C:\Users\Dead Ghoul\source\repos\testbot2\testbot2\BogashevoStation.jpg", FileMode.Open))
                {
                    InputOnlineFile photoToBeSent = new InputOnlineFile(fs);
                    Message msg2 = await client.SendPhotoAsync(msg.Chat.Id, photoToBeSent);

                }
            }
        };
    }
}
