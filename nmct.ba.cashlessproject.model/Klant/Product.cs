using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model.Klant
{
    public class Product : IDataErrorInfo
    {
        #region properties

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _productName;
        [Required(ErrorMessage = "Productnaam is verplicht.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Productnaam moeten tussen de 3 en 50 karakters lang zijn.")]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private double _price;
        [Required(ErrorMessage = "Prijs is verplicht")]
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private Boolean _deleted;

        public Boolean Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
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
