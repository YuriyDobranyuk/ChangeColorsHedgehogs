using ChangeColorsHedgehogs.Enums;

namespace ChangeColorsHedgehogs
{
    public class HadgehogsPopulation
    {
        public int Id { get; set; }
        public int[] Population { get; set; } = new int[3];
        public int ChangeColor { get; set; }
        public bool ChangeColorSuccessful { get; set; } = false;
        public int Steps { get; set; } = 0;

        public HadgehogsPopulation() { }

        public HadgehogsPopulation(int id, int[] population, int color)
        {
            Id = id;
            Population = population;
            ChangeColor = color;
            Steps = MinStepsToChangeColor();
            ChangeColorSuccessful = (Steps == -1) ? false : true;
        }

        private int MinStepsToChangeColor()
        {
            int steps;
            int indexFirstOtherColor = (ChangeColor + 1) % 3;
            int indexSecoundOtherColor = (ChangeColor + 2) % 3;

            if (Population[indexFirstOtherColor] == Population[indexSecoundOtherColor] && Population[indexFirstOtherColor] == 0)
            {
                steps = 0;
            }
            else
            {
                var modPopulation = new int[3];
                var populationOtherColor = new int[2];

                for (var i = 0; i < Population.Length; i++)
                {
                    modPopulation[i] = Population[i] % 3;
                }

                populationOtherColor = new[] { Population[indexFirstOtherColor], Population[indexSecoundOtherColor] };

                if (modPopulation[indexFirstOtherColor] == modPopulation[indexSecoundOtherColor])
                {
                    steps = populationOtherColor.Max();
                }
                else
                {
                    steps = -1;
                }
            }

            return steps;
        }

        public override string ToString()
        {
            return new string('-', 20) + "\n" +
                   $"Id: {Id},\n" +
                   $"Population: [{Population[0]},{Population[1]},{Population[2]}], \n" +
                   $"ChangeColor: {Enum.GetName(typeof(Colors), ChangeColor).ToString()}, \n" +
                   $"ChangeColorSuccessful: {ChangeColorSuccessful}, \n" +
                   $"Count steps: {Steps}.";
        }
    }
}
