using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace sensoriando_webservice.Pages
{

    public class Sensors
    {
        public string id { get; set; }
    }
    public class IndexModel : PageModel
    {
        public Boolean Auth { get; set; }
        public String[] Sensores { get; set; }
        public async Task OnGet()
        {           
            HttpClient client = new HttpClient 
            {
                 //BaseAddress = new Uri("https://api.chucknorris.io/jokes/")
                 BaseAddress = new Uri("https://localhost:5000/") 
            };

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
            {
                return true;
            };

            //var response = await client.GetAsync("random");
            var response = await client.GetAsync("sensors");
            var content = await response.Content.ReadAsStringAsync();

            System.Console.WriteLine(content);
            //Sensors category = JsonConvert.DeserializeObject<Sensors>(content);
            
            string[] sensores = { "a", "b", "c", "d"};

            Auth = false;
            Sensores = sensores;
        }
    }
}
