namespace OptiSandbox.Web;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureCmsDefaults()
            .ConfigureWebHostDefaults(
                webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    if (webBuilder.GetSetting("environment") == Environments.Development)
                    {
                        webBuilder.UseUrls("https://opti-sandbox.[::]:443");
                    }
                }
            );
    }
}
