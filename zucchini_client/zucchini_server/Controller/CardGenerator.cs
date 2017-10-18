using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_server.Controller
{
    class CardGenerator
    {

        public static void Generate(out Vegetable vegetable, out int amount) {

            Array values = Enum.GetValues(typeof(Vegetable));

            Random rnd = new Random();
            vegetable = (Vegetable)values.GetValue(rnd.Next(values.Length));
            var pick = rnd.Next(1, 27);

            if (pick <= 10)
            {
                amount = 1;
            }
            else if (pick <= 18)
            {
                amount = 2;
            }
            else if (pick <= 23)
            {
                amount = 3;
            }
            else if (pick <= 26)
            {
                amount = 4;
            }
            else {
                amount = 5;
            }
        }
    }

    public enum Vegetable {
        ZUCCHINI, EGGPLANT, TOMATO, CARROT, CORN
    }
}
