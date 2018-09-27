using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
namespace RestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            RunAsync().Wait();
            Console.ReadKey();
        }

        static async Task RunAsync()
        {
            using (var client= new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:34902/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Get operation");
                //get a person
                HttpResponseMessage response = await client.GetAsync("api/person/3");
                if (response.IsSuccessStatusCode)
                {
                    Person p = await response.Content.ReadAsAsync<Person>();
                    Console.WriteLine(p.id);
                    Console.WriteLine(p.name);
                    Console.WriteLine(p.address);
                }


                Console.WriteLine("//Read_all");
                // get all the person
                 response = await client.GetAsync("api/person");
                if (response.IsSuccessStatusCode)
                {
                    List<Person> pl = await response.Content.ReadAsAsync<List<Person>>();
                    foreach(var p in pl)
                    {
                        Console.WriteLine(p.id);
                        Console.WriteLine(p.name);
                        Console.WriteLine(p.address);

                    }

                }

            }
        }
    }
}
