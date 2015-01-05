using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.project.model.Model
{
    class Sales
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _timestamp;

        public string Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }
        private int _customerid;

        public int CustomerID
        {
            get { return _customerid; }
            set { _customerid = value; }
        }
        private int _registerID;

        public int RegisterID
        {
            get { return _registerID; }
            set { _registerID = value; }
        }
        private int _productid;

        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private double _totalprice;

        public double TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }

    }
}
