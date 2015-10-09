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
                client2.BaseAddress = new Uri("http://pacmandementiaaid.azurewebsites.net/");
                client2.DefaultRequestHeaders.Accept.Clear();
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                /*HttpResponseMessage response = await client2.GetAsync("api/PATIENTs");
                if (response.IsSuccessStatusCode)
                {

                    apiResult = await response.Content.ReadAsStringAsync();
                }

                Console.WriteLine(apiResult);*/

                /*LOCATION loc = new LOCATION();
                loc.coordinates_x = 1;
                loc.coordinates_y = 2;
                loc.id_patient = 1;
                loc.id_carer = 2;*/

                FENCE fence = new FENCE();
                fence.id_carer = 1;
                fence.id_patient = 1;
                fence.id_location = 1;
                fence.radius = 2.0m;
                fence.description = "fromManualTest";

                HttpResponseMessage response;
                response = await client2.PostAsJsonAsync("api/Fence",fence);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    // Get the URI of the created resource.
                    apiResult = await response.Content.ReadAsStringAsync();
                    Uri resultURL = response.Headers.Location;
                    String resultString = resultURL.ToString();
                    Console.WriteLine(resultString);
                    int slashPosition = resultString.LastIndexOf("/");
                    Console.WriteLine("slash pos: " + slashPosition);
                    string ID = resultString.Substring(slashPosition+1);
                    Console.WriteLine("ID: " + ID);  
                }
                else
                {
                    Console.WriteLine("Store Failed");
                    Uri patientURL = response.Headers.Location;
                    apiResult = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("result: "+apiResult);
                }

            }
        }
    }
}
