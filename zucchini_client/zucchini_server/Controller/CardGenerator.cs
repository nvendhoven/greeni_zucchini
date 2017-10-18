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
            Random rndV = new Random();
            vegetable = (Vegetable)values.GetValue(rndV.Next(values.Length));

            Random rndA = new Random();
            amount = rndA.Next(1, 6);
        }
    }

    public enum Vegetable {
        ZUCCHINI, EGGPLANT, TOMATO, CARROT, CORN
    }
}
