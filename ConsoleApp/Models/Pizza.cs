using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    internal class Pizza
    {
        /*public Pizza(bool sauce)
        {

        }
        public Pizza(bool cheese)
        {
            Cheese = cheese;
        }
        public Pizza(bool cheese, bool sauce, bool onion)
        {
            Cheese = cheese;
            Sauce = sauce;
            Onion = onion;
        }*/

        public bool Cheese { get; set; }
        public bool Sauce { get; set; }
        public bool Ham { get; set; }
        private bool Onion { get; set; }
        public bool Tomato { get; set; }
    }
}
