using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class resultOperationContainer
    {
        public double result { get; set; }
        public bool success { get; set; }
        public Exception exception { get; set; }
        public string errorMessage { get; set; }
        public string customMessage { get; set; }
    }
}
