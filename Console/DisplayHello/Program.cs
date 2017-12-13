using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;



namespace DisplayHello
{

    /* http://localhost:43982/examapis/    */

    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    class Program
    {
        HttpClient client = new HttpClient();



        static void Main(string[] args)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:43982/examapi/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (args.Length > 0)  //id is passed as parameter from command line
                    {
                        var responseTask = client.GetAsync(String.Format("persons/{0}", args[0]));

                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<Person>();
                            readTask.Wait();
                            var person = readTask.Result;
                            Console.WriteLine("Hello " + person.FirstName);
                        }
                    }
                    else
                    {
                        var responseTask = client.GetAsync("persons");
                        responseTask.Wait();
                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<Person[]>();
                            readTask.Wait();
                            var persons = readTask.Result;

                            foreach (var person in persons)
                            {
                                Console.WriteLine("Hello " + person.FirstName);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           }
    }
}
