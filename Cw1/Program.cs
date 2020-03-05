using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //int? tmp1 = null;
            //double tmp2 = 2.0;
            //double tmp6 = 6.0;
            //string tmp3 = "Ala ma kota";
            //string tmp5 = "i psa";
            //Console.WriteLine($"{tmp3} {tmp5} {tmp2+tmp6}");
            //bool tmp4 = true;

            //string path = @"C:\Users\s19110\Desktop\Cw1";

            //Console.WriteLine("Hello World!");

            //var tmp7 = 1;

            //var newPerson = new Person { FirstName = "Hubert" };

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            // 2xx - success
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
