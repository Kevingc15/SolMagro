using System;
using System.Collections.Generic;
using System.Text;

namespace SolMagro.Models.Response
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
    }

    public class ResponseBase
    {
        public bool Success { get; set; }
    }
}
