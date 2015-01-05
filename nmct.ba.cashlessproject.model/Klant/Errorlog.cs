using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model.Klant
{
    public class Errorlog : IDataErrorInfo
    {
        #region properties

        private int _registerID;
        public int RegisterID
        {
            get { return _registerID; }
            set { _registerID = value; }
        }

        //unix timestamp
        private int _timeStamp;
        [Required(ErrorMessage = "Timestamp is verplicht.")]
        public int TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        private string _message;
        [Required(ErrorMessage = "Message is verplicht")]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private string _stackTrace;
        [Required(ErrorMessage = "Stacktrace is verplicht")]
        public string StackTrace
        {
            get { return _stackTrace; }
            set { _stackTrace = value; }
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
