using System;
namespace Lesson1_tempConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int intNumToConvert;
            double dblNumToConvert;
            bool stop = false;
            do
            {
                try
                {
                    intNumToConvert = 0;
                    dblNumToConvert = 0;

                    Console.WriteLine("Enter the temp you want converted");
                    var numberToConvert = Console.ReadLine();
                    while (!double.TryParse(numberToConvert, out dblNumToConvert) && !int.TryParse(numberToConvert, out intNumToConvert))
                    {
                        Console.WriteLine("You must enter a valid number, please try again");
                        numberToConvert = Console.ReadLine();
                    }
                    if (intNumToConvert > 0)
                    {
                        convertTemp(intNumToConvert);
                    }
                    else
                    {
                        convertTemp(dblNumToConvert);
                    }
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to enter a number");
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                catch (OverflowException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number you entered is too big");
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error occurred, please try again.");
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                finally
                {
                    Console.WriteLine("Do you want to convert another temp? (Y for yes, any key for no)");
                    char more;
                    while (!char.TryParse(Console.ReadLine(), out more))
                    {
                        Console.WriteLine("Pleaase enter a valid character, try again...");
                    }
                    if (Char.ToLower(more) != 'y')
                        stop = true;
                }
            } while (!stop);
        }

        private static void convertTemp(int intNumToConvert)
        {
            int celsius = 0;
            int fahrenheit = 0;
            try
            {
                celsius = (intNumToConvert - 32) * 5 / 9;
                fahrenheit = (intNumToConvert * 9 / 5) + 32;
            }
            catch (ArithmeticException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was a problem converting the temperature.");
                Console.WriteLine($"Error Message: {e.Message}");
                Console.ResetColor();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unknown error encountered.");
                Console.WriteLine($"Error Message: {e.Message}");
                Console.ResetColor();
            }
            finally
            {
                if (celsius == 0 && fahrenheit == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Warning: Temperature could not be converted.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{intNumToConvert} degrees Celsius = {fahrenheit} degrees Fahrenheit");
                    Console.WriteLine($"{intNumToConvert} degrees Fahrenheit = {celsius} degrees Celsius");
                    Console.ResetColor();
                }
            }

            return;
        }
        private static void convertTemp(double dblNumToConvert)
        {
            double celsius = 0;
            double fahrenheit = 0;

            celsius = (dblNumToConvert - 32) * 5 / 9;
            fahrenheit = (dblNumToConvert * 9 / 5) + 32;

            try
            {
                celsius = Math.Round((dblNumToConvert - 32) * 5 / 9, 3);
                fahrenheit = Math.Round((dblNumToConvert * 9 / 5) + 32, 3);
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("There was a problem converting the temperature.");
                Console.WriteLine($"Error Message: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error encountered.");
                Console.WriteLine($"Error Message: {e.Message}");
            }
            finally
            {
                if (celsius == 0 && fahrenheit == 0)
                {
                    Console.WriteLine("Temperature could not be converted.");
                }
                else
                {
                    Console.WriteLine($"{dblNumToConvert} degrees Celsius = {fahrenheit} degrees Fahrenheit");
                    Console.WriteLine($"{dblNumToConvert} degrees Fahrenheit = {celsius} degrees Celsius");
                }
            }

            return;
        }
    }
}
