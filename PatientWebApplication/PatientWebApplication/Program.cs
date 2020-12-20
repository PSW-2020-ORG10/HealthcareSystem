using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PatientWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

      /*  public static List<Feedback> Feedback = new List<Feedback>()
        {
            new Feedback(1, "First message", true, true, new PatientUser(1, "Pera", "Peric", "1", "12/09/2020", "123", "1", "allergie", "city", false, "email", "password", false, new List<string>()), 1),
            new Feedback(2, "Second message", false, false, new PatientUser(2, "Mika", "Mikic", "2", "12/09/2020", "123", "2", "allergie", "city", false, "email", "password", false, new List<string>()), 2),
            new Feedback(3, "Third message", true, false, new PatientUser(3, "Ana", "Peric", "3", "12/09/2020", "123", "3", "allergie", "city", false, "email", "password", false, new List<string>()), 3)

        };*/

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
