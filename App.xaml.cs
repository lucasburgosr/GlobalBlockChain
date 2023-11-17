using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using WpfApp;

namespace GlobalLabIII
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Variable que almacena el estado de la conexión a la BD
        private MySqlConnection conexion;
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DatabaseConfig.Desconectar(conexion);
            
            base.OnExit(e);
        }
        
    }
}