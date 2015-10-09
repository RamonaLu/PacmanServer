using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace RestManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiCaller();
            Console.ReadLine();

        }

        static async Task ApiCaller()
        {
            Console.ReadLine();
            string apiResult = "";
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("http://localhost:64746/");
                client2.DefaultRequestHeaders.Accept.Clear();
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                /*HttpResponseMessage response = await client2.GetAsync("api/PATIENTs");
                if (response.IsSuccessStatusCode)
                {

                    apiResult = await response.Content.ReadAsStringAsync();
                }

                Console.WriteLine(apiResult);*/

                LOCATION loc = new LOCATION();
                loc.coordinates_x = 1;
                loc.coordinates_y = 2;
                loc.id_patient = 1;
                loc.id_carer = 2;

                HttpResponseMessage response;
                response = await client2.PostAsJsonAsync("api/Location",loc);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    // Get the URI of the created resource.
                    Uri patientURL = response.Headers.Location;
                    //apiResult = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(patientURL.ToString());
                    
                }
                else
                {
                    Console.WriteLine("Store Failed");
                    Uri patientURL = response.Headers.Location;
                    apiResult = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(apiResult);
                }

            }
        }
    }
}
