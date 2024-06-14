namespace Saal.API
{
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Main args.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Host builder property.
        /// </summary>
        /// <param name="args">Main args.</param>
        /// <returns>Host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
