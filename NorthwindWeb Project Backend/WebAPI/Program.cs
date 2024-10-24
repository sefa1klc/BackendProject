// var builder = WebApplication.CreateBuilder(args);
//
// // Startup sınıfını oluştur
// var startup = new WebAPI.Startup(builder.Configuration);
//
// // Servisleri eklemek için Startup sınıfındaki ConfigureServices metodunu çağır
// startup.ConfigureServices(builder.Services);
//
// var app = builder.Build();
//
// // Middleware'i yapılandırmak için Startup sınıfındaki Configure metodunu çağır
// startup.Configure(app, builder.Environment);
//
// app.Run();

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>((builder) =>
            {
                builder.RegisterModule(new AutofacBusinessModel());
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    
}