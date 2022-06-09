using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
namespace testbot2;

internal static class RandomPhoto
{
    internal async static Task RandowyzePhoto(TelegramBotClient client, object sender, MessageEventArgs e)
    {
        var msg = e.Message;
        Random rnd = new Random();
        int rand = rnd.Next(0, 3);
        switch (rand)
        {
            case 0:
                using (FileStream fs = new FileStream(@"C:\Users\Dead Ghoul\source\repos\testbot2\testbot2\School.jpg", FileMode.Open))
                {
                    InputOnlineFile photoToBeSent = new InputOnlineFile(fs);
                    Message msg2 = await client.SendPhotoAsync(msg.Chat.Id, photoToBeSent);

                }
                break;
            case 1:
                using (FileStream fs = new FileStream(@"C:\Users\Dead Ghoul\source\repos\testbot2\testbot2\b7932667d931e24c5d850942acd2f780.jpg", FileMode.Open))
                {
                    InputOnlineFile photoToBeSent = new InputOnlineFile(fs);                   
                    Message msg2 = await client.SendPhotoAsync(msg.Chat.Id, photoToBeSent);
                   
                }
                break;
            case 2:
                using (FileStream fs = new FileStream(@"C:\Users\Dead Ghoul\source\repos\testbot2\testbot2\BogashevoStation.jpg", FileMode.Open))
                { 
                    InputOnlineFile photoToBeSent = new InputOnlineFile(fs);                 
                    Message msg2 = await client.SendPhotoAsync(msg.Chat.Id, photoToBeSent);
                  
                }
                break;
            case 3:
                using (FileStream fs = new FileStream("C:\\Users\\Dead Ghoul\\source\\repos\\testbot2\\testbot2\\1.jpg", FileMode.Open))
                {
                    InputOnlineFile photoToBeSent = new InputOnlineFile(fs);                   
                    Message msg2 = await client.SendPhotoAsync(msg.Chat.Id, photoToBeSent);                  
                }
                break;

        }
    }
}
