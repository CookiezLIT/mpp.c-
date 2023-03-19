using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MPP_Problema1.Model;
using MPP_Problema1.Repository;
using MPP_Problema1.Service;
using Npgsql;
using System;
using System.Windows.Forms;

namespace MPP_Problema1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //init services and repos here
            ConnectionManager conn = new ConnectionManager();
            UserRepository userRepository = new UserRepository(conn);
            UserService userService = new UserService(userRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(userService));

            
            


        }

       
    }
}
