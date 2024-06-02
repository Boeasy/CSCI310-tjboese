using System;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
            int birth_year; //no more than 123 years old
            int birth_month; // 1 - 12
            int birth_day; // 1-31
            DateTime today = DateTime.Today;
            string zodiac_output;
            string chinese_zodiac;

            while (true)
            { 
                Console.WriteLine("Enter in your birth year");
                temp_input = Console.ReadLine();
                if (int.TryParse(temp_input, out birth_year))
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

                if (int.TryParse(temp_input, out birth_month))
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

                if (int.TryParse(temp_input, out birth_day))
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

            DateTime birthday = new DateTime(birth_year, birth_month, birth_day);
            
            if (birthday.Day == today.Day & birthday.Month == today.Month)
            {
                Console.WriteLine("Happy Cake Day!");
            }

            chinese_zodiac = ChineseAstrologicalSign(birthday);
            zodiac_output = WesternAstrologicalSign(birthday);
            
            Console.WriteLine($"Your Zodiac Sign is: {zodiac_output}");
            Console.WriteLine($"Your Chinese Zodiac Sign is: {chinese_zodiac}");

            try
            {
                getHoroscope(zodiac_output).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
            


        }

        static bool IsReasonableAge(DateTime birthday) //left in incase changing input to full data object, otherwise not needed as each day/month/year is checked individually.
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;

            if (birthday > today.AddYears(-age)) //from chatgpt... lower age by 1 if birthday hasn't passed yet
            {
                age--;
            }

            return age >= 0 & age <= 123; 
        }

        static string WesternAstrologicalSign(DateTime birthday)
        {
            //Define a tuple array for start and end dates of each Zodiac sign... (from chatgpt)
            var zodiacSigns = new (string sign, DateTime Begin, DateTime End)[]
            {
                ("Capricorn", new DateTime(birthday.Year, 12, 22), new DateTime(birthday.Year, 1, 19)),
                ("Aquarius", new DateTime(birthday.Year, 1, 20), new DateTime(birthday.Year, 2, 18)),
                ("Pisces", new DateTime(birthday.Year, 2, 19), new DateTime(birthday.Year, 3, 20)),
                ("Aries", new DateTime(birthday.Year, 3, 21), new DateTime(birthday.Year, 4, 19)),
                ("Taurus", new DateTime(birthday.Year, 4, 20), new DateTime(birthday.Year, 5, 20)),
                ("Gemini", new DateTime(birthday.Year, 5, 21), new DateTime(birthday.Year, 6, 20)),
                ("Cancer", new DateTime(birthday.Year, 6, 21), new DateTime(birthday.Year, 7, 20)),
                ("Leo", new DateTime(birthday.Year, 7, 23), new DateTime(birthday.Year, 8, 22)),
                ("Virgo", new DateTime(birthday.Year, 8, 23), new DateTime(birthday.Year, 9, 22)),
                ("Libra", new DateTime(birthday.Year, 9, 23), new DateTime(birthday.Year, 10, 22)),
                ("Scorpio", new DateTime(birthday.Year, 10, 23), new DateTime(birthday.Year, 11, 21)),
                ("Sagittarius", new DateTime(birthday.Year, 11, 22), new DateTime(birthday.Year, 12, 21)),
            };

            foreach (var temp in zodiacSigns)
            {
                if ((temp.sign == "Capricorn" & (birthday >= temp.Begin || birthday <= temp.End)) ||
                    (birthday >= temp.Begin & birthday <= temp.End))
                {
                    return temp.sign;
                }
            }

            return "None found";
        }
        
        static string ChineseAstrologicalSign(DateTime birthday)
        {
            int year = birthday.Year;
            string[] chineseZodiac = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"};
            string[] heavenlyStems = {"Jia", "Yi", "Bing", "Ding", "Wu", "Ji", "Geng", "Xin", "Ren", "Gui" };
            int zodiac_index = (year - 4) % 12; //12-year cycle, starts with rat in 1924 (wikipedia)
            int stem_index = (year - 4) % 10;

            return $"{chineseZodiac[zodiac_index]} {heavenlyStems[stem_index]}";
        }

static async Task getHoroscope(string sign) //using ohmanda.com api to get horoscope based on input
{
    sign = sign.ToLower(); //will change this based on sign

    try
    {
        string apiURL = $"https://ohmanda.com/api/horoscope/{sign}/";

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(apiURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
    }
    
}