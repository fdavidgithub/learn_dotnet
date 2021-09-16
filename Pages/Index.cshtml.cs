using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace sensoriando_webservice.Pages
{

    public class IndexModel : PageModel
    {
        public Boolean Auth { get; set; }
        public String[] Sensores { get; set; }
        public void OnGet()
        {
            string[] sensores = { "a", "b", "c", "d"};

            Auth = false;
            Sensores = sensores;
        }
    }
}
