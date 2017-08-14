using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url  
        private readonly string Baseurl = "http://localhost/WebApi";

        public async Task<ActionResult> Index()
        {
            var empInfo = new List<Employee>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postResponse =
                    await
                        client.PostAsJsonAsync(@"/WebApi/api/employee/Add",
                            new Employee{City = "Chennai", Id = 4, Name = "Vengat"});

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var res = await client.GetAsync(@"/WebApi/api/employee/GetEmployees");

                //Checking the response is successful or not which is sent using HttpClient  
                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var empResponse = res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    empInfo = JsonConvert.DeserializeObject<List<Employee>>(empResponse);
                }

                //returning the employee list to view  
                return View(empInfo);
            }
        }
    }
}