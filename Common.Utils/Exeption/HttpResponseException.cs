using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Exeption
{
    public class HttpResponseException : SystemException
    {
        public int Status { get; set; }
        public object Value { get; set; }
    }
}
