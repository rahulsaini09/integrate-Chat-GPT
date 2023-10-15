using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    public class Error
    {
        public class APIException
        {
            public ErrorDetails error { get; set; }
        }
        public class ErrorDetails
        {
            public string message { get; set; }
            public string type { get; set; }
            public string param { get; set; }
            public string code { get; set; }
        }

    }
}
