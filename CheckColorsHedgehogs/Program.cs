using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace CheckColorsHedgehogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:5000/hadgehogsPopulation/";

            var menuHadgehog = new MenuHadgehog();

            // Send GET request
            using (WebClient client = new WebClient())
            {
                string responseString = client.DownloadString(url);

                var hadgehogsPopulations = JsonConvert.DeserializeObject<List<HadgehogsPopulation>>(responseString);
                Console.WriteLine("HadgehogsPopulation received from server:");
                foreach (var population in hadgehogsPopulations)
                {
                    Console.WriteLine(population.ToString());
                }
            }

            // Send POST request
            using (WebClient client = new WebClient())
            {
                int selection;
                do
                {
                    HadgehogsDataPopulation newHadgehogsDataPopulation = menuHadgehog.FormingHadgehogsDataPopulation();

                    string requestData = JsonConvert.SerializeObject(newHadgehogsDataPopulation);
                    client.Headers.Add("Content-Type", "application/json");
                    string responseString = client.UploadString(url, "POST", requestData);
                    Console.WriteLine(new string('-', 20) + "\n" + "Server response: " + responseString);

                    selection = menuHadgehog.UserSelectionToSendDataPopulationHadgehog();

                    //Console.WriteLine($"Work with requestData:");
                    //Console.WriteLine(requestData[0].Id);
                } while (selection > 0) ;

                
                Console.ReadLine();
            }
        }
    }

   
}
