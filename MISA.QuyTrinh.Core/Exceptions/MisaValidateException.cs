using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Exceptions
{
    public class MisaValidateException : Exception
    {
        #region Declaration

        // message
        public string? ValidateErrorMsg { get; set; }

        // list mesage
        public IDictionary Errors { get; set; }


        #endregion

        #region Constructor

        public MisaValidateException(string errorMsg)
        {
            ValidateErrorMsg = errorMsg;
        }

        // constructor
        public MisaValidateException(List<string> errorMsg)
        {
            Errors = new Dictionary<string, object>();
            Errors.Add("errors", errorMsg);
        }


        #endregion

        #region Methods

        // override 
        public override string Message => this.ValidateErrorMsg;
        public override IDictionary Data => Errors;


        #endregion

    }
}
