using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*
IFN501 Programming Fundamental semester 1 2019
Deliverable 1
Name: Chaoran Li
Student ID: n10298827
Date: 04/04/2019
*/

namespace Deliverable1
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalCustomer = 0;
            while (true) // outer while loop to record number of customers
            {
                WriteLine("Please press 'N' for new customer or press 'Q' to quit...");
                string response = ReadLine();
                if (response == "N" || response == "n")
                {
                    int itemCount = 0;
                    double totalPrice = 0;
                    while (true)
                    {
                        /* input name of items
                         * if input C or c to continue
                         * check if name have been obeyed by requirments
                         */
                        WriteLine("Please enter the name of item or press 'C' to continue...");
                        string nameString = ReadLine();
                        if (nameString == "C" || nameString == "c")
                        {
                            break;
                        }
                        else
                        {
                            if (nameString == null || nameString.Length <= 0 || nameString.Length >= 8)
                            {
                                WriteLine("Invalid name, please try enter the name again...");
                            }
                            else
                            {
                                while (true) // inner while loop
                                {
                                    /* input price 
                                     * make sure cashier input only contains numbers
                                     */
                                    WriteLine("Please enter the price of item...");
                                    bool priceCheck = double.TryParse(ReadLine(), out double price);
                                    if (priceCheck == false || price <= 0)
                                    {
                                        WriteLine("Invalid price, please try again...");
                                    }
                                    else
                                    {
                                        totalPrice += price;
                                        itemCount++;
                                        break;
                                    }
                                }

                            }
                        }
                        

                    }

                    // Discount calculation
                    if (totalPrice > 300)
                    {
                        totalPrice = totalPrice - totalPrice * 0.025;
                        WriteLine("2.5% discount applied...");
                    }
                    else if (totalPrice >= 100 && totalPrice <= 300)
                    {
                        totalPrice = totalPrice - totalPrice * 0.015;
                        WriteLine("1.5% discount applied...");
                    }
                    else
                    {
                        WriteLine("No discount given...");
                    }

                    // Check card
                    while (true)
                    {
                        WriteLine("Please enter your four digits card number one by one...");
                        WriteLine("Please enter your first card number...");
                        string firstNumber = ReadLine();
                        WriteLine("Please enter your second card number...");
                        string secondNumber = ReadLine();
                        WriteLine("Please enter your third card number...");
                        string thirdNumber = ReadLine();
                        WriteLine("Please enter your last card number...");
                        string lastNumber = ReadLine();
                        string cardNumber = firstNumber + secondNumber + thirdNumber + lastNumber;
                        string firstThreeDigits = firstNumber + secondNumber + thirdNumber;
                        int threedDigits = Convert.ToInt32(firstThreeDigits);

                        bool cardNumberCheck = int.TryParse(cardNumber, out int fourDigits);
                        if (cardNumberCheck == false || cardNumber.Length != 4 || threedDigits % 7 != Convert.ToInt32(lastNumber))
                        {
                            WriteLine("Invalid card number, please try again...");
                        }
                        else
                        {
                            WriteLine("Your payment has been accepted...");
                            totalCustomer++;
                            break;
                        }

                    }

                    Clear();
                    Write("Total price is ");
                    Write("{0:C2}", totalPrice);
                    WriteLine("\n" + "Purchased " + itemCount + " items");
                    ReadKey();
                }
                else if (response == "Q" || response == "q")
                {
                    break;
                }
                else
                {
                    WriteLine("Invalid input, please enter again...");
                } 
            }
        }// end of main method
    }// end of class
}// end of namespace
