using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model.Klant
{
    public class Sale
    {
        #region properties

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        private int _customerID;
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        private int _registerID;
        public int RegisterID
        {
            get { return _registerID; }
            set { _registerID = value; }
        }

        private string _registerName;
        public string RegisterName
        {
            get { return _registerName; }
            set { _registerName = value; }
        }

        private int _productID;
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        

        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        

        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        
        #endregion
    }
}
