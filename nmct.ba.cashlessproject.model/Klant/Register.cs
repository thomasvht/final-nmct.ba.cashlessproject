using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model.Klant
{
    public class Register : IDataErrorInfo
    {
        #region properties

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _registerName;
        [Required(ErrorMessage = "Kassanaam is verplicht.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Kassanaam moet tussen de 5 en 30 karakters lang zijn.")]
        public string RegisterName
        {
            get { return _registerName; }
            set { _registerName = value; }
        }

        private string _device;
        [Required(ErrorMessage = "Toestel is verplicht.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Toestel moet tussen de 5 en 30 karakters lang zijn.")]
        public string Device
        {
            get { return _device; }
            set { _device = value; }
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
