using System;
using System.Collections.Generic;
//written by Coutaq
namespace LabOne
{
    internal class Task1
    {
        public static void Do()
        {
            int numOfCountries;
            Console.Write("Please enter how much countries: ");
            while (true)
            {
                
                try
                {
                    numOfCountries = int.Parse(Console.ReadLine());
                    if (numOfCountries < 1)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Incorrect input, try again: ");
                }
            }
            List<GeographicalUnit> countries = new List<GeographicalUnit>();
            for (int i = 0; i < numOfCountries; i++)
            {
                Console.WriteLine("Country " + (i + 1) + ":");
                Console.Write("Please enter the country: ");
                string country = Console.ReadLine();
                Console.Write("Please enter the capital: ");
                string capital = Console.ReadLine();
                int population = 0;

                while (true)
                {
                    try
                    {
                        Console.Write("Please enter the population: ");
                        population = int.Parse(Console.ReadLine());
                        if (population < 0)
                        {
                            throw new FormatException();
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Incorrect input, try again: ");
                    }
                }
                string formString = "";
                string upperString = "";
                GeographicalUnit.FormOfGov form;
                while (true)
                {
                    try
                    {
                        Console.Write("Please enter the form of government: ");
                        formString = Console.ReadLine();
                        upperString = (formString.ToUpper()).ToString();
                        if (upperString != "US" && upperString != "F")
                        {
                            throw new FormatException();
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Incorrect input, try again: ");
                    }
                }
                form = (GeographicalUnit.FormOfGov)Enum.Parse(typeof(GeographicalUnit.FormOfGov), upperString);
                countries[i] = new GeographicalUnit(country, capital, population, form);
            }
            
        }

        public static void DisplayTable(List<GeographicalUnit> list)
        {
            String output = "\n--------------------------------------\n";
            for (int i = 0; i < list.Count; i++)
            {
                output += (list[i].getInfoTable());
                output += "\n--------------------------------------\n";

            }
            Console.WriteLine(output);

        }
    }
}