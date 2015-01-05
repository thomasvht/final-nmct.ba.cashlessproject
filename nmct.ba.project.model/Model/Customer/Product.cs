using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.project.model
{
    public class Product
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        
    }
}
