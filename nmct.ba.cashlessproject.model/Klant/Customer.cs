using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model.Klant
{
    public class Customer : IDataErrorInfo
    {
        #region properties

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _customerName;
        [Required(ErrorMessage = "De naam is verplicht")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De naam moet tussen de 3 en 50 karakters bevatten.")]
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private byte[] _picture;
        public byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private double _balance;
        [Required(ErrorMessage = "Het saldo is verplicht")]
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        } 

        #endregion

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true);
        }

        public string this[string columnName]
        {
            get
            {
                try
                {
                    object value = this.GetType().GetProperty(columnName).GetValue(this);
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = columnName });
                }
                catch (ValidationException ex)
                {
                    return ex.Message;
                }
                return String.Empty;
            }
        }

        public string Error
        {
            get { return null; }
        }
    }
}
