using System;
using System.Collections.Generic;
using LabOne;

namespace LabFive
{
    public class ConsoleApp
    {
        
        public static void Execute(List<GeographicalUnit> countries)
        {
           
            String prompt = "1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход";
            Console.WriteLine(prompt);
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Execute(countries);
            }
            switch (input)
            {
                case 1:
                    String output = "\n--------------------------------------\n";
                     if (countries.Count==0)
                         output = ("The list is empty!");
                     else
                     {
                         foreach (GeographicalUnit country in countries)
                             output += country.getInfoTable();
                     }
                    Console.WriteLine(output);
                    Execute(countries);
                    break;
                case 2:
                        Console.Write("Please enter the country: ");
                        string name = Console.ReadLine();
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
                    countries.Add(new GeographicalUnit(name, capital, population, form ));
                    Console.WriteLine($"Added {name} to the list.");
                    Execute(countries);
                    break;
                case 3:
                    int entry = 0;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Which entry do you want to remove? ");
                            entry = int.Parse(Console.ReadLine());
                            if (entry > countries.Count || entry < 1)
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
                    countries.RemoveAt(entry+1);
                    Execute(countries);
                    break;
                case 7:
                    return;
            }
        }
    }
}
