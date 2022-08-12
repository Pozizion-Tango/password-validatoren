using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_validatoren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while(true)
            {
                Console.WriteLine("Password Must Contain 12-64 characters long. While also containing-\r\n1 Uppercase letter\r\nMust be a mix of numbers, and letters\r\nHave atleast 1 special character\r\n\r\nEnter a password:");
                string password = Console.ReadLine();
                //program will use the USER's input to create the password, while also using it to run through loops to check the Chars


                if (password.Length < 12 || password.Length > 64)//Line of code checking if the password is long enough to procced down the chain
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Password Must Contain 12-64 Characthers");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else//if the password makes passes, it will go up the chain of IF code to pass through more checks
                {
                    Char value = ' ';

                    bool result = password.Contains(value);//Program checks if there is any Empty spaces in the code
                    if (result)//if any empty spaces are detected it will reset.
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Empty Spaces Not Allowed");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else//no empty spaces means the password passed, and will continue 
                    {
                        string specialsigns = "!.,-_?+^~'*/#<>=&%$";
                        for (int i = 0; i < specialsigns.Length; i++)
                        {
                            value = specialsigns[i];
                            result = password.Contains(value);//program checks the password's chars if any of them are similur to the once in the string specialsings, if not password will reset
                            if (result == true)
                            {
                                string numbers = "0123456789";
                                bool numberresult = false;
                                for (i = 0; i < numbers.Length; i++)
                                {
                                    value = numbers[i];
                                    numberresult = password.Contains(value); ;//The program checks if there is any numbers in the code, if not password will reset. using the same method as specialsigns
                                    if (numberresult == true)
                                    {
                                        bool uppercase = false;
                                        for (i = 0; i < password.Length; i++)
                                        {
                                            value = password[i];
                                            uppercase = Char.IsUpper(value);//In here it checks all the Chars for any uppercase letters, if not password will reset
                                            if (uppercase == true)
                                            {
                                                bool lowercase = false;
                                                for (i = 0; i < password.Length; i++)
                                                {
                                                    value = password[i];
                                                    lowercase = Char.IsLower(value);// same as the uppercase, but just checking for lowercase.
                                                    if (lowercase == true)
                                                    {
                                                        bool strengh = true;
                                                        int count = 0;
                                                        for (i = 0; i < password.Length; i++)
                                                        {
                                                            value = password[i];
                                                            string repeat = value + "" + value + value + value;//here it makes a sting with 4 of the same letters, to check the password if there is any similur lines
                                                            string validate = "";
                                                            for (int j = 0; j < 4; j++)
                                                            {
                                                                if (!strengh)//this one is empty, it's a failsafe if the code repeats
                                                                {

                                                                }
                                                                else if (count < password.Length)
                                                                {
                                                                    validate = "" + validate + password[count];//Count will go up ever time J loop repeats. slowly counting up the password to see if any chars match with "repeat"
                                                                    count++;
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();//password have now passed all the code and is strong, since the program did not find any repeating letters and numbers
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine("Password Is Strong");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                    break;
                                                                }
                                                            }
                                                            if (validate == repeat)//code will tell the user their password is weak, since it got match letters 4 time after each other.
                                                            {
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine("Password Is Weak. But acceptable");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                strengh = false;
                                                            }
                                                            count = count - 4;//Count will go down by for each loop, to make sure that validation will go through the password 1 char at a time
                                                            count++;//by counting up once, the starting of which part of the password will be checked, and goes up by 4 each loop.

                                                        }
                                                    }

                                                }
                                                if (!lowercase)//if there is no lower case in the code. It will reset from the start
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Password Must Contain Lowercases");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                        }
                                        if (!uppercase)//if there is no upper case in the code. It will reset from the start
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Password Must Contain Uppercases");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }

                                }
                                if (!numberresult)//if there is no numbers in the code. It will reset from the start
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Password Must Contain Numbers");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            } 
                        }
                        if (!result)//Hmmm, wonder what this could be huh? totally not like the other once. (yes will reset if not special)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Password Must Contain Special Charachters");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Console.WriteLine("Press Any Key ´Continue");
                Console.ReadKey();
            }
            
        }
    }
}
