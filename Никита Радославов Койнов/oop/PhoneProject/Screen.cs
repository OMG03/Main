using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProject
{
    public class Screen
    {
        // големина и цветове

        public float Size { get; set; }

        public string Colors { get; set; }

        public Screen(float size, string colors)
        {
            Size = size;
            Colors = colors;
        }

        public Screen()
            : this(0, null)
        {

        }
    }
}
