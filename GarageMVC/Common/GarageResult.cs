using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Common
{
    public class GarageResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public GarageResult(bool result, string message)
        {
            Success = result;
            Message = message;
        }
    }
}