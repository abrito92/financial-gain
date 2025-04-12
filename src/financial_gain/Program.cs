using financial_gain.Application;
using financial_gain.Domain;
using financial_gain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var shareOperation = serviceProvider.GetService<IShareOperations>();

        if (shareOperation == null)
        {
            throw new Exception("Dependency Injection failure");
        }

        string? line;

        //List<List<UserOperation>> allEntry = new List<List<UserOperation>>();
        //List<List<Tax>> taxes = new List<List<Tax>>();

        while ((line = Console.ReadLine()) != null && line != "")
        {
            List<UserOperation> entries = JsonConvert.DeserializeObject<List<UserOperation>>(line);

            Console.WriteLine(JsonConvert.SerializeObject(shareOperation.ShareOperation(entries)));
        }
    }

    /// <summary>
    /// Configure services for dependency Injection
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IShareOperations, ShareOperationService>();
    }
}

