using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zucchini_server.Network;

namespace zucchini_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Greeni Zucchini Server\nby: Lois Gussenhoven & Nick van Endhoven\n");
            new Server();
        }

        public static void Print(PrintType type, string message) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            switch (type) {
                case PrintType.SUCC:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"[SUCC]");
                    break;
                case PrintType.ACK:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"[ACK]");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case PrintType.REC:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"[REC]");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case PrintType.ERR:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"[ERR]");
                    break;
                case PrintType.DISCON:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[DISCONN]");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case PrintType.CONN:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"[CONN]");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.Write($" {message}\n");
        }
    }

    enum PrintType {
        SUCC, ACK, ERR, DISCON, CONN, REC
    }
}
