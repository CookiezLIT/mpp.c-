using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MPP_Problema1.Model;
using MPP_Problema1.Repository;
using MPP_Problema1.Service;
using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ConnectionManager connectionManager = new ConnectionManager();
            //DatabaseContext context = new DatabaseContext(connectionManager);

            //var r = await context.GetUserAsync(Guid.Parse("370a2faa-9bc6-4743-b878-e6365aeec6d4"));


            //init services and repos here
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigureServices();

            Application.Run(new Form1());

        }

        static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<ConnectionManager>();
            services.AddScoped<DatabaseContext>();
            services.AddScoped<UserService>();
            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }

    }
}
