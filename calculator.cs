using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class calculator
    {
        public resultOperationContainer mathOperation(String firstOperator, String secondOperator, string operationType) {
            resultOperationContainer container = new resultOperationContainer();
            try
            {
                double firstNumber = 0;
                double secondNumber = 0;

                if ((double.TryParse(firstOperator, out firstNumber)) && (double.TryParse(secondOperator, out secondNumber)))
                {
                    switch (operationType)
                    {
                        case "1": {
                                container.result = firstNumber + secondNumber;
                                container.success = true;
                            }; break;
                        case "2": {
                                container.result = firstNumber - secondNumber;
                                container.success = true;
                            }; break;
                        case "3": {
                                container.result = firstNumber * secondNumber;
                                container.success = true;
                            }; break;
                        case "4": {
                                if (secondNumber == 0) throw new DivideByZeroException(); 
                                container.result = firstNumber / secondNumber;
                                container.success = true;
                            }break;
                    }
                    
                }
                else
                    throw new FormatException("One or all the arguments are not in the correct format");
                
            }
            catch (Exception exc)
            {
                container.exception = exc;
                container.success = false;
            }
            return container;

        }
    }
}
