using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileExplorer
{
    public class ChangeColor
    {
        public static void ChangeColors(ConsoleColor color,string text)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void ChangeTextColor(ConsoleColor color,string text)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
