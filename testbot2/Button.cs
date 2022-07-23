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
        ReplyKeyboardMarkup Keyboard = new(new[]
           {
            new KeyboardButton[] { "История Села", "Достопримечательности" },
            new KeyboardButton[] { "Интересные факты", "Теоретический тест" }

        })
        {
            ResizeKeyboard = true
        };

        return Keyboard;
        
        
    }
   
        
  
}