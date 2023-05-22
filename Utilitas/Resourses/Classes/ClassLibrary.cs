using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitas.Resourses.Classes
{
    public class ClassLibrary
    {
        string name;
        int number;
        double cost_price;
        double price;
        double profit_crisis;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Profit_crisis
        {
            get { return profit_crisis; }
            set { profit_crisis = value;}
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public double Cost_Price
        {
            get { return cost_price; }
            set { cost_price = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public ClassLibrary()
        {
            name = string.Empty;
            number = 0;
            price = 0;
            cost_price = 0;
            profit_crisis = 0;
        }
        public ClassLibrary(string nm, int num, double cp, double pr, double pc)
        {
            name = nm;
            number = num;
            cost_price = cp;
            price = pr;
            profit_crisis = pc;
        }
    }
}
