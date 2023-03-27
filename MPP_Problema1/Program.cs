using Microsoft.Extensions.DependencyInjection;
using MPP_Problema1.Model;
using MPP_Problema1.Repository;
using MPP_Problema1.Service;
using Npgsql;
using Serilog;
using SimpleSql;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public static class Program
    {

        private const string LogFileName = "app.log";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            ConnectionManager connectionManager = new ConnectionManager();
            //DatabaseContext context = new DatabaseContext(connectionManager);

            //var r = await context.GetUserAsync(Guid.Parse("370a2faa-9bc6-4743-b878-e6365aeec6d4"));


            //init services and repos here

            //var user = new Model.User(Guid.NewGuid(), "name", "password");

            //var q = Queries.Generic<Model.User>.Create(user, connectionManager.Connection);
            //var q1 = Queries.Generic<Model.User, DbConstants.Tables.Users>.Create(user, connectionManager.Connection);

            //var create = SqlCommandsFor<Model.User>.Create(user, connectionManager.Connection);
            //var getAll = SqlCommandsFor<Model.User>.GetAll(connectionManager.Connection);
            //var update = SqlCommandsFor<Model.User>.Update(user, connectionManager.Connection);
            //var delete = SqlCommandsFor<Model.User>.Delete(user.Id, connectionManager.Connection);
            //var get = SqlCommandsFor<Model.User>.Get(user.Id, connectionManager.Connection);



            //var flight = new Model.Flight(Guid.NewGuid(), "Cluj", "Bucuresti", DateTime.Now, DateTime.Now.AddHours(2));

            //var createFlight = SqlCommandsFor<Model.Flight>.Create(flight, connectionManager.Connection);
            //var getFlights = SqlCommandsFor<Model.Flight>.GetAll(connectionManager.Connection);
            //var updateFlight = SqlCommandsFor<Model.Flight>.Update(flight, connectionManager.Connection);
            //var deleteFlight = SqlCommandsFor<Model.Flight>.Delete(flight.Id, connectionManager.Connection);
            //var getByIdFlight = SqlCommandsFor<Model.Flight>.Get(flight.Id, connectionManager.Connection);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFileName))
                .CreateLogger();

            ConfigureServices(connectionManager.Connection);

            var userRepository = new SimpleSql.Repository<Model.User>(connectionManager.Connection, Log.Logger);

            var flightRepository = new SimpleSql.Repository<Model.Flight>(connectionManager.Connection, Log.Logger);

            var flightClientRepositroy = new SimpleSql.Repository<Model.FlightClient>(connectionManager.Connection, Log.Logger);

            //var users = await userRepository.GetAllAsync();

            //var flight = await flightRepositroy.CreateAsync(new Model.Flight("cluj", "constanta", DateTime.Now, DateTime.Now.AddHours(2), 50));

            //var flightClient = await flightClientRepositroy.CreateAsync(new Model.FlightClient("Dandoti Denisz", "Pandurilor 88", "ddandoti@endava.eu"));


            var userService = new UserService(userRepository);
            var flightService = new FlightService(flightRepository);

            

            Application.Run(new Form1(userService,flightService));



        }

        static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices(NpgsqlConnection connection)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddScoped<ConnectionManager>();
            services.AddScoped<IRepository<Model.User>, Repository<Model.User>>(o => new Repository<Model.User>(connection, Log.Logger));
            services.AddScoped<IRepository<Model.Flight>, Repository<Model.Flight>>(o => new Repository<Model.Flight>(connection, Log.Logger));
            services.AddScoped<IRepository<Model.FlightClient>, Repository<Model.FlightClient>>(o => new Repository<Model.FlightClient>(connection, Log.Logger));
            services.AddScoped<IRepository<Model.FlightTicket>, Repository<Model.FlightTicket>>(o => new Repository<Model.FlightTicket>(connection, Log.Logger));
            services.AddScoped<UserService>();
            services.AddScoped<FlightService>();
            
            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }

    }
}
