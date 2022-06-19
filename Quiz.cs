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
 

internal static class Quiz
{
    
    public async static Task HandleQuizMessage(TelegramBotClient client, object sender, MessageEventArgs e)
    {
        var inlineKeyboardRndPhotos = new InlineKeyboardMarkup(new[]
           {
                InlineKeyboardButton.WithCallbackData("Церковь", "Church"),
                InlineKeyboardButton.WithCallbackData("Школа", "School"),
                 InlineKeyboardButton.WithCallbackData("Станция", "RailwayStation")

            });

        var msg = e.Message;
    
        switch (msg.Text)
        {
            case "История Села":
                await client.SendTextMessageAsync(
                    chatId: msg.Chat.Id,
                    text: "    Богашево возникло на полвека позже города Томска, в 1646 году, и являлось его заимкой .Ранее село называлось деревней Федосеево, в честь пахаря, служивого человека Федосея. Люди занимались охотой, рыбной ловлей, коневодством, пчеловодством, земледелием и ремеслами. Деревня Федосеево располагалась в кедраче и уступала ранее возникшим селам в количестве жителей и благоустройстве. Первые сведения  относятся к 1859," +
                   " тогда в деревне насчитывалось всего 14 дворов. Спустя 61 год, количество дворов возросло до 50.\n " + "  В 1891 году началось строительство железной дороги. Службой движения на этом участке занимался Богашев Степан Михайлович.В 1908 году, начальником Томской железной дороги был назначен Богашев Степан Михайлович. Богашев имел в Федосеево деревянную дачу, которая была построена в 1895 по проекту архитектора Константина Лыгина. Позже дача стала использоваться как вокзал станции Богашёво. Наиболее заметным элементом в оформлении дачи был купол, сделанный в виде кедровой шишки, символизирующей окружающий кедрач.\n" +
                   "    В годы гражданской войны в деревне организуется «Комитет взаимопомощи», который затем перерастает в колхоз «Красный пахарь». В колхоз входили деревни Некрасово, Аксеново, Федосеево. Первым председателем колхоза была Колесникова Т. Е. В 1927 г. в деревне создается товарищество «Смычка», впоследствии ставшая филиалом томской артели «Краснодеревец». \n" +
                   "    В честь заслуг С. М. Богашева разъезд 1 (Федосеевский) приказом Министра переименован в «Богашево».\n" + "https://st.weblancer.net/download/2506879_935xp.jpg",
                    replyToMessageId: msg.MessageId,
                    replyMarkup: Button.GetButtons());
                break;
            case "Достопримечательности":
                client.SendTextMessageAsync(msg.Chat.Id, "Выберите Достопримечательность: ", replyMarkup:inlineKeyboardRndPhotos);
                await RandomPhoto.RandowyzePhoto(client, sender, e, inlineKeyboardRndPhotos);
                
                break;
            case "Теоретический тест":
                await Test.TeoreticalTest(client, sender, e);
                break;
            case "Интересные факты":
                await Facts.intrestingFacts(client, sender, e);

                break;
            default:
                await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду: ", replyMarkup: Button.GetButtons());
                break;
        }
      
        return;
    }
   

}
