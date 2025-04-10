using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Management
{
    public class UtilManager
    {
        //Print text delay
        public static void DelayedPrint(string text, ConsoleColor color, int delay = 1000)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Thread.Sleep(delay);
            Console.ResetColor();
        }

        //Print press anykey to continue
        public static void ReadAnyKey(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("계속하려면 아무 키나 누르세요");
            Console.ReadKey(true);
        }

    }
}
