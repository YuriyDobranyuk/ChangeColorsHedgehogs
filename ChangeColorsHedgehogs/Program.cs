using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ChangeColorsHedgehogs
{
    public class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:5000/hadgehogsPopulation/";

            List<HadgehogsPopulation> hadgehogsPopulations = new List<HadgehogsPopulation>();
            hadgehogsPopulations.Add(new HadgehogsPopulation(1, new int[] { 10, 11, 12 }, 0));

            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(url);
                listener.Start();
                Console.WriteLine("Server started. Listening for connections...");

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    ProcessRequest(context, hadgehogsPopulations);
                }
            }

        }
        static void ProcessRequest(HttpListenerContext context, List<HadgehogsPopulation> hadgehogsPopulations)
        {
            if (context.Request.HttpMethod == "GET")
            {
                // Handle GET request
               
                string responseString = JsonConvert.SerializeObject(hadgehogsPopulations);
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                context.Response.ContentType = "application/json";
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
            }
            else if (context.Request.HttpMethod == "POST")
            {
                // Handle POST request
                byte[] buffer = new byte[context.Request.ContentLength64];
                context.Request.InputStream.Read(buffer, 0, buffer.Length);
                string requestData = Encoding.UTF8.GetString(buffer);
                HadgehogsDataPopulation newHadgehogsDataPopulation = JsonConvert.DeserializeObject<HadgehogsDataPopulation>(requestData);

                // Save the new user to the database or perform other operations
                var newHadgehogsPopulation = new HadgehogsPopulation(hadgehogsPopulations.Count + 1,
                                                                     newHadgehogsDataPopulation.Population,
                                                                     newHadgehogsDataPopulation.ChangeColor);
                
                hadgehogsPopulations.Add(newHadgehogsPopulation);

                // Send response
                string responseString = $"HadgehogsPopulation created successfully.\n" +
                                        $"{newHadgehogsPopulation.ToString()}";
                buffer = Encoding.UTF8.GetBytes(responseString);

                context.Response.ContentType = "text/plain";
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
            }
            else
            {
                // Invalid request method
                context.Response.StatusCode = 405; // Method Not Allowed
                context.Response.Close();
            }
        }

    }

 
}