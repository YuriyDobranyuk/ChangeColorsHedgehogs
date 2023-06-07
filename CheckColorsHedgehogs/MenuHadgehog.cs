using CheckColorsHedgehogs.Enums;
using System;

namespace CheckColorsHedgehogs
{
    public class MenuHadgehog
    {
        static Enum Colors { get; } = Colors;

        public HadgehogsDataPopulation FormingHadgehogsDataPopulation()
        {
            return new HadgehogsDataPopulation()
            {
                Population = GetPopulation(),
                ChangeColor = GetChangeColor(),
            };
        }

        private int[] GetPopulation()
        {
            var population = new int[3];
            for (var i = 0; i < population.Length; i++)
            {
                population.SetValue(EnterIntPropertyValue($"{Enum.GetName(typeof(NamePopulation), i)} population"), i);
            }
            return population;
        }

        private int EnterIntPropertyValue(string nameParam)
        {
            Console.WriteLine(new string('*', 10));
            Console.WriteLine($"Enter {nameParam}, please:");
            var value = 0;
            if (!(int.TryParse(Console.ReadLine(), out value) || value <= 0)) EnterIntPropertyValue(nameParam);
            return value;
        }

        private int GetChangeColor()
        {
            int color = 0;
            Console.WriteLine(new string('*', 10));
            Console.WriteLine($"For select color hadgehogs for change other color to selected color:");
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"For select {Enum.GetName(typeof(Colors), i).ToString()} color hadgehogs, enter number {i}.");
            }
            if (!(int.TryParse(Console.ReadLine(), out color)) || (color < 0 || color > 2 )) color = GetChangeColor();
            return color;
        }

        public int UserSelectionToSendDataPopulationHadgehog()
        {
            Console.WriteLine(new string('-', 10));
            Console.WriteLine($"For send data population hadgehog, enter number 1.");
            Console.WriteLine($"For stop send data, enter number 0.");
            if (!int.TryParse(Console.ReadLine(), out var number))
                GetUserSelection();
            Console.WriteLine();
            return number;
        }
        public int GetUserSelection()
        {
            Console.WriteLine(new string('-', 10));
            Console.WriteLine($"Enter number, please:");
            if (!int.TryParse(Console.ReadLine(), out var number))
                GetUserSelection();
            Console.WriteLine();
            return number;
        }
    }
}
