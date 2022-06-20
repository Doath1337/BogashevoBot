﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace testbot2;

internal class Facts
{   
    internal static async Task intrestingFacts(TelegramBotClient client, object sender, MessageEventArgs e)
    {
        var msg = e.Message;
        Random rnd = new Random();
        int cnt = rnd.Next(0, 2);
        switch (cnt)
        {
            case 0:
                client.SendTextMessageAsync(msg.Chat.Id, "В Богашево «украли» вокзал"
+ " \n \n Вокзал в Богашево  был построен в 1895 году.Красивое деревянное здание в стиле модерн было сооружено по проекту известного томского архитектора Константина Лыгина.Купол вокзала был выполнен в виде кедровой шишки, символизируя кедрач, среди которого и расположено село Богашево. Уже несколько лет здание вокзала не эксплуатировалось.И владелец вокзала - Кемеровское отделение Западно - Сибирской железной дороги - обратился к Томскому центру по охране памятников с просьбой о передаче вокзала  администрации Томского района.Вопрос об этой передаче рассматривался на секции Деревянное зодчество и музеи под открытым небом на федеральном научно - методическом совете Министерства культуры РФ.Представлял вопрос специалист томского областного комитета по культуре и туризму Павел Рачковский.Когда 31 октября Рачковский ехал поездом на совет в Москву, вокзал еще стоял на месте.Пятого ноября, когда он возвращался обратно, жемчужины архитектуры на месте не оказалось. Архитектор Центра по охране памятников Ирина Яковлева, памятник разобрали его владельцы - Кемеровское отделение ЗСЖД.Почему они это сделали, куда дели материалы от разборки, не известно"); ;
                client.SendPhotoAsync(chatId: msg.Chat.Id,
                       photo: "https://sun9-1.userapi.com/c856132/v856132536/5084a/bWisPG9dPLA.jpg",                     
                       replyMarkup: Button.GetButtons());
                break;
            case 1:
                client.SendTextMessageAsync(msg.Chat.Id, @"На 2022 год, по данным Росстата, в Богашево проживает порядка 3,8 тыс. человек.
Из них:
~1800 мужчин,
~2000 женщин,
~1000 детей и подростков.

А средний возраст населения — 40 лет.");
                break;

            case 2:
                 
                break;
        }
        
    }

}