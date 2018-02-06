using ExceptionHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            * By default, when an Exception is thrown, it will "bubble up" through the call stack until
            * it reaches the main method and then will cause the program to exit and print a stacktrace
            * to the standard output 
            * 
            * By using try/catch blocks, you can stop the Exception from exiting the method and provide
            * code to handle it. 
            */
            Console.WriteLine("The following cities: ");
            string[] cities = new string[] { "Cleveland", "Columbus", "Cincinatti" };
            try
            {
                Console.WriteLine(cities[0]);
                Console.WriteLine(cities[1]);
                Console.WriteLine(cities[2]);
                Console.WriteLine(cities[3]);  // This statement will throw an IndexOutOfRangeException
                Console.WriteLine("are all in Ohio."); // This line won't execute because the previous statement throws an Exception
            }
            catch (IndexOutOfRangeException e)
            {
                // Flow of control resumes here after the Exception is thrown
                Console.WriteLine("XXX   Uh-oh, something went wrong...   XXX");
            }

            Console.WriteLine();


            /* 
            * try/catch blocks will also catch Exceptions that are 
            * thrown from method calls further down the stack 
            */
            try
            {
                Console.WriteLine("Hey, watch this!");
                DoSomethingDangerous();  // throws an ArrayIndexOutOfBoundsException
                Console.WriteLine("I told you nothing would go wrong!");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Guess I was wrong...");
            }





            /* 
            * catch statements can take advantage of polymorphism. The catch block will 
            * handle any Exception that matches the declared Exception type, including 
            * subclasses of the declared type
            */
            try
            {
                Console.WriteLine("The standard work week is 40 hours.");
                Console.WriteLine("How many hours did you work this week? >>> ");

                int hoursWorked = GetIntegerFromUser();

                int overtimeHours = hoursWorked - 40;
                Console.WriteLine("You worked " + overtimeHours + " hours of overtime.");



                //int hoursWorked = int.Parse(Console.ReadLine());
                //int hoursWorked;
                //bool validInput = int.TryParse(Console.ReadLine(), out int hoursWorked);

                //if (validInput)
                //{
                //    int overtimeHours = hoursWorked - 40;
                //    Console.WriteLine("You worked " + overtimeHours + " hours of overtime.");
                //}
                //else
                //{
                //    Console.WriteLine("I couldn't parse what you just said.");
                //}

            }
            catch (Exception e)
            {   // If a FormatException is thrown by int.Parse(...) 
                // it will be caught here since FormatException "is-a" Exception
                Console.WriteLine("You did it wrong...");
            }

            /*
             * It's not a best practice to catch Exception though because that is a catch all.
             * Better practice is to prevent the root cause or handle the specific type of exception
             * that you know may occur (e.g. FileNotFound, Server Unavailable)
             */

            Console.WriteLine();


            /* 
            * We can throw our own Exceptions in response to exceptional cases 
		    * see the source code of calculateHotelRoomCharges for an example 
            */
            int nights = -3;
            int numberOfGuests = 2;
            try
            {
                double amountOwed = CalculateHotelRoomCharges(nights, numberOfGuests);
                Console.WriteLine("Total owed for " + numberOfGuests + " guests for " + nights + " nights is $" + amountOwed);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(numberOfGuests + " guests for " + nights + " nights just doesn't make sense.");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();


            try
            {

                /*
                * We can also create our own Exceptions to use if the System provided
                * exceptions don't give us what we need.  
                *
                * The "finally" block means that if an exception is caught or not, the code 
                * in the finally block should run last.          
                */
                try
                {
                    double finalBalance = Withdraw(6000.00);
                    Console.WriteLine("The final balance is " + finalBalance);
                }
                catch (OverdraftException ex)
                {
                    Console.WriteLine("An overdraft exception was caught");
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally
                {
                    Console.WriteLine("Thank you for banking with Fly By Night Banking");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("SOMETHING REALLY WENT WRONG");
            }


            Console.WriteLine("----- Thank you for banking with Fly By Night Banking");

            //finally
            //{
            //    Console.WriteLine("Thank you for banking with Fly By Night Banking");
            //}

        }

        private static int GetIntegerFromUser()
        {
            bool validInput = false;
            int hoursWorked;
            int numberOfAttempts = 0;
            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("TRY AGAIN!");
                }

                validInput = int.TryParse(Console.ReadLine(), out hoursWorked);
                numberOfAttempts++;
            }
            while (!validInput);
            return hoursWorked;
        }








        private static double Withdraw(double amount)
        {
            const double StartingBalance = 5000.00;

            double finalBalance = StartingBalance - amount;

            if (finalBalance < 0)
            {
                throw new OverdraftException("You cannot overdraft this account");
            }

            return finalBalance;
        }


        /*         	    
        * 	    
        */
        private static double CalculateHotelRoomCharges(int nights, int numberOfGuests)
        {
            const double ExtraGuestCharge = 20;
            const double RoomRate = 85;

            /* The throw statements below demonstrate how to throw a new Exception. */
            if (nights < 1)
            {
                throw new ArgumentOutOfRangeException("nights", nights, "Minimum number of nights is 1");
            }
            if (numberOfGuests < 1)
            {
                throw new ArgumentOutOfRangeException("numberOfGuests", numberOfGuests, "Minimum number of guests is 1");
            }

            int numberOfExtraGuests = 0;
            if (numberOfGuests > 4)
            {
                numberOfExtraGuests = numberOfGuests - 4;
            }

            double dailyRate = RoomRate + (ExtraGuestCharge * numberOfExtraGuests);
            return dailyRate * nights;
        }


        private static void DoSomethingDangerous()
        {
            int[] numbers = new int[5];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = i;  // this line will throw an Exception once i reaches 5
            }
            Console.WriteLine("Look, no Exceptions!");  // This line will not execute because an Exception will be thrown inside the for loop
        }

    }
}
