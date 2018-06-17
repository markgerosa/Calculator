using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
  class Program
  {
        public static readonly string[] allowedOptions = { "0", "1", "2", "3", "4" };
        public static readonly string[] allowedArgs = { "interactive", "sum", "subtract", "multiply", "divide" };
        static void Main(string[] args)
        {
            try
            {
                resultOperationContainer opContainer = new resultOperationContainer();
                if (!allowedArgs.Contains(args[0], StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine("INVALID ARGUMENT");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
                if (args[0] == "interactive")
                {
                    
                    String option = String.Empty;
                    option = getOption();
                    if (option.Equals("0"))
                    {
                        exitApplication(0);
                    }
                    do
                    {
                        if (allowedOptions.Contains(option, StringComparer.OrdinalIgnoreCase))
                        {
                            string[] arguments = getArguments();
                            opContainer = calculateOperation(option, arguments);
                            if (opContainer.success)
                            {
                                Console.WriteLine("Result: " + opContainer.result);
                            }
                            else
                            {
                                Console.WriteLine(opContainer.errorMessage);
                                Console.WriteLine(opContainer.exception.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid option");
                        }
                        Console.ReadLine();
                        option = getOption();
                    } while (!option.Equals("0"));

                    exitApplication(0);
                }
                else
                {
                    //var readAllText = System.IO.File.ReadAllText(args[1]); // The second parameter should be the file of the input numbers
                    //var strings = readAllText.Split({ "\r\n", "\r", "\n" }.ToCharArray());

                    string[] strings = System.IO.File.ReadAllLines(args[1]);

                    //var firstArgument = strings[0];

                    //var secondArgoument = strings[1];

                    opContainer = calculateOperation(args[0], strings);

                    if (opContainer.success)
                    {
                        Console.WriteLine("Result: " + opContainer.result);
                    }
                    else
                    {
                        Console.WriteLine(opContainer.errorMessage);
                        Console.WriteLine(opContainer.exception.Message);
                    }

                    //Console.WriteLine("Result: " + (int.Parse(firstArgument) + int.Parse(secondArgoument)));
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You must specify an argument");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            #if DEBUG
                Console.WriteLine(exc.StackTrace);
                Console.WriteLine(exc.InnerException);
            #endif
            }
            finally
            {
                Console.ReadLine();
            }
            }

        static resultOperationContainer calculateOperation(string option, string[] arguments) {

            resultOperationContainer calcOperation = new resultOperationContainer();

            try {
                calculator mathOp = new calculator();
                switch (option)
                {
                    case "1":
                    case "sum":
                        {
                            calcOperation = mathOp.mathOperation(arguments[0], arguments[1], "1");
                        }; break;
                    case "2" :
                    case "subtract":
                        {
                            calcOperation = mathOp.mathOperation(arguments[0], arguments[1], "2");
                        }; break;
                    case "3":
                    case "multiply":
                        {
                            calcOperation = mathOp.mathOperation(arguments[0], arguments[1], "3");
                        }; break;
                    case "4":
                    case "divide": 
                        {
                            calcOperation = mathOp.mathOperation(arguments[0], arguments[1], "4");
                        }; break;
                    case "0":
                        {
                            exitApplication(0);
                        }; break;
                    default:
                        {
                            calcOperation.errorMessage = "Invalid option";
                            calcOperation.success = false;
                        }
                        break;

                }
            }
            catch (Exception exc) {
                calcOperation.exception = exc;
                calcOperation.success = false;
            }
            return calcOperation;

        }

        static void exitApplication(int resultCode) {
            Console.WriteLine("Goodbye");
            Console.ReadLine();
            Environment.Exit(resultCode);
        }

        static String getOption() {
            Console.Clear();
            Console.WriteLine("################################");
            Console.WriteLine("Please select an option");
            Console.WriteLine("[1] - Sum");
            Console.WriteLine("[2] - Subtract");
            Console.WriteLine("[3] - Multiply");
            Console.WriteLine("[4] - Divide");
            Console.WriteLine("[0] - Exit");
            return Console.ReadLine();
        }

        static string[] getArguments()
        {
            Console.WriteLine("First argument: ");
            var firstArgument = Console.ReadLine();

            Console.WriteLine("Second Argument: ");
            var secondArgoument = Console.ReadLine();

            return new string[] { firstArgument, secondArgoument };
            
        }
  }
}

