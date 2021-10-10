using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Exceptions
{
    public class BllValidationException : Exception
    {
        public BllValidationException(string errorMessage): base(errorMessage)
        {
        }
    }
}
