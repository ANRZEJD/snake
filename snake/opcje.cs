using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class opcje
    {
        public static int width {  get; set; }
        public static int height { get; set; }

        public static string direction;

        public opcje()
        {
            width = 16;
            height = 16;
            direction = "left";
            
        }

    }
}
