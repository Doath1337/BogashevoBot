using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace testbot2;

internal static class Button
{
    internal static IReplyMarkup GetButtons()
    {
        return new ReplyKeyboardMarkup
        {
            Keyboard = new List<List<KeyboardButton>>
            {
                new List<KeyboardButton>{ new KeyboardButton { Text = "История Села"}, new KeyboardButton { Text = "Достопримечательность" } },
                new List<KeyboardButton>{ new KeyboardButton { Text = "Интересные факты" }, new KeyboardButton { Text = "Теоретический тест"} }
            }
        };
    }
   
        
  
}