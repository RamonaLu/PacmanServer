using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PacmanREST.Models;
namespace PacmanREST.Logic
{
    class checkFence
    {
        private pacmanAndroidNew_dbEntities db = new pacmanAndroidNew_dbEntities();
        public decimal patientx { get; set; }
        public decimal patienty { get; set; }

        public decimal fencex { get; set; }
        public decimal fencey { get; set; }

        public string careDeviceId { get; set; }

        public string patientName { get; set; }

        public decimal radius { get; set; }
        public string apiResult = "";

        public checkFence(decimal px, decimal py, decimal fx, decimal fy, decimal r)
        {
            this.patientx = px;
            this.patienty = py;
            this.fencex = fx;
            this.fencey = fy;
            this.radius = r;
        }

        public checkFence()
        {
            // TODO: Complete member initialization
        }

        public void distanceCheck()
        {
            double xsquare = (double)((patientx - fencex) * (patientx - fencex));
            double ysquare = (double)((patienty - fencey) * (patienty - fencey));
            double dist = Math.Sqrt((xsquare + ysquare));
            double r = (double)radius;
            apiResult = "distance: " + dist;
            if (dist > r)
            {
                alarm();
            }
            
        }

        public async Task alarm()
        {

            using (var client2 = new HttpClient())
            {
                /*
                 client2.BaseAddress = new Uri("https://api.pushbots.com/push/all");
                 client2.DefaultRequestHeaders.Accept.Clear();
                 client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 client2.DefaultRequestHeaders.Add("x-pushbots-appid", "55eb927f177959b3338b4567");
                 client2.DefaultRequestHeaders.Add("x-pushbots-secret", "50dd3c9198d1766e74a5964db3613e10");
                 PushbotsAll allPush = new PushbotsAll();
                 allPush.platform = 1;
                 allPush.schedule = "2015-09-08T01:20:00";
                 Console.WriteLine("before repsonse");
                 HttpResponseMessage response = await client2.PostAsJsonAsync("", allPush);
                 Console.WriteLine("after response");
                 apiResult = "post response";
                 if (response.IsSuccessStatusCode)
                 {
                     apiResult = "in OK";
                     //Uri patientURL = response.Headers.Location;
                 }
                 else
                 {
                     apiResult = "in ERROR " + await response.Content.ReadAsStringAsync();
                 }               
             */
                

                
                string token=careDeviceId;
                client2.BaseAddress = new Uri("https://api.pushbots.com/push/one");
                client2.DefaultRequestHeaders.Accept.Clear();
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client2.DefaultRequestHeaders.Add("x-pushbots-appid", "55eb927f177959b3338b4567");
                client2.DefaultRequestHeaders.Add("x-pushbots-secret", "50dd3c9198d1766e74a5964db3613e10");
                PushbotsOne onePush = new PushbotsOne();
                onePush.platform = 1;
                // onePush.schedule = "2015-09-08T01:20:00";
                onePush.token = token;
                onePush.msg = patientName + "is now out of fence ";
                Console.WriteLine("before repsonse");
                HttpResponseMessage response = await client2.PostAsJsonAsync("", onePush);
                Console.WriteLine("after response");
                apiResult = "post response";
                if (response.IsSuccessStatusCode)
                {
                    apiResult = "in OK";
                    //Uri patientURL = response.Headers.Location;
                }
                else
                {
                    apiResult = "in ERROR " + await response.Content.ReadAsStringAsync();
                }
            }

        }
    }
}
