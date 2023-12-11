using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL.IServices;
using MovieNight_InterfacesDAL.IManagers;
using Microsoft.VisualStudio.Services.Profile;

namespace MovieNightOOD
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Login>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IUserDALManager, UserDALManager>();
                    services.AddTransient<IUserManager, UserManager>();
                    services.AddTransient<Login>();
                });
        }
    }
}