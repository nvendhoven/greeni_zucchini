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
            Console.WriteLine($"--! Greeni Zucchini Server !--\n- Made by: Lois Gussenhoven & Nick van Endhoven -\n\n");
            new Server();
        }
    }
}
