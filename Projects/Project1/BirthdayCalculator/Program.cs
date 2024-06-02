using System;

namespace BirthdayCalculator
{
    /*
     * Ask User for their birthday
     * calculate their age
     * make sure age is 'possible'
     * output age to console
     * if birthday, output a nice message
     * compute astrological sign according to western and chinese astrology systems
     * output computed signs to console, optionally output additional information based on sign.
     */
    public class BirthdayCalculator
    {
        static void Main(string[] args)
        {
            string temp_input;
            int32 birth_year; //no more than 123 years old
            int32 birth_month; // 1 - 12
            int32 birth_day; // 1-31

            while (true)
            { 
                Console.WriteLine("Enter in your birth year");
                temp_input = Console.ReadLine();
                if (int32.TryParse(temp_input, out birth_year))
                {
                    if (birth_year > 1900)
                    {
                        Console.WriteLine($"You entered year: {birth_year}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You are too old, try again");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input, enter a valid integer for a year");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter your birth month (1-12)");
                temp_input = Console.ReadLine();

                if (int32.TryParse(temp_input, out birth_month))
                {
                    Console.WriteLine($"You have entered: {birth_month}");
                    if (birth_month >= 1 & birth_month <= 12)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, enter a valid integer month between 1 and 12");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input, enter a valid integer month between 1 and 12");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter your birth day (1-31)");
                temp_input = Console.ReadLine();

                if (int32.TryParse(temp_input, out birth_day))
                {
                    Console.WriteLine($"You have entered: {birth_day}");
                    if (birth_month == 1 || birth_month == 3 || birth_month == 5 || birth_month == 7 || birth_month == 8 || birth_month == 10 || birth_month == 12) 
                    {
                        if (birth_day >= 1 & birth_day <= 31)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, enter a valid integer day between 1 and 31");
                        }
                    }
                    else if (birth_month == 2)
                    {
                        if (birth_day >= 1 & birth_day <= 28)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, enter a valid integer day between 1 and 28");
                        }
                    }
                    else if (birth_month == 4 || birth_month == 6 || birth_month == 9 || birth_month == 11)
                    {
                        if (birth_day >= 1 & birth_day <= 30)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, enter a valid integer day between 1 and 30");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Input, enter a valid integer day between 1 and 31");
                }
            }
            
            
            
        }
    }
}