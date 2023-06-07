using CheckColorsHedgehogs.Enums;
using System;

namespace CheckColorsHedgehogs
{
    public class HadgehogsPopulation
    {
        public int Id { get; set; }
        public int[] Population { get; set; }
        public int ChangeColor { get; set; }
        public bool ChangeColorSuccessful { get; set; }
        public int Steps { get; set; } = 0;

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
