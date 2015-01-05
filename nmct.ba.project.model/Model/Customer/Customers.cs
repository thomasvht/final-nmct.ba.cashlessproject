using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.project.model.Model
{
    public class Customers
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
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        private double _balance;

        public double  Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        
    }
}
