using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT3Wrapper.Extensions
{
    public static class BotTypeExtensions
    {
        public static string ExtractBotType(this string prompt)
        {
            return "Chat";
        }
    }
}