using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model.Klant
{
    public class Employee : IDataErrorInfo
    {
        #region properties

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _employeeName;
        [Required(ErrorMessage = "De naam is verplicht")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De naam moet tussen de 3 en 50 karakters bevatten.")]
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        private string _address;
        [Required(ErrorMessage = "Het adres is verplicht")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Het adres moet tussen de 3 en 50 karakters bevatten.")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email;
        [Required(ErrorMessage = "Emailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Het emailadres heeft geen correcte syntax")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _phone;
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [StringLength(20, MinimumLength = 9, ErrorMessage = "Telefoonnummer moet tussen de 9 en 20 karakters bevatten")]
        [RegularExpression(@"^[0-9''-'\s\(\)\-\+]*$", ErrorMessage = "Geen geldig telefoonnummer")]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
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
