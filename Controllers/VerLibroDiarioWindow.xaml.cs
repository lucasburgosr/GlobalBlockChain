using System;
using System.Collections.Generic;
using System.Windows;
using GlobalLabIII.Clases;
using GlobalLabIII.DAO;
using GlobalLabIII.Enums;
using MySql.Data.MySqlClient;
using WpfApp;

namespace GlobalLabIII
{
    public partial class VerLibroDiarioWindow : Window
    {
        private global::Blockchain blockchain;
        
        public VerLibroDiarioWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Llenar el DataGrid con datos de ejemplo (ajustar según la lógica real)
            CargarDatos();
        }
        
        private void CargarDatos()
        {
            // Crear una instancia de la clase Blockchain
            blockchain = new global::Blockchain();

            // Cargar los bloques desde el archivo
            blockchain.CargarBlockchainDesdeArchivo();

            // Obtener la lista de asientos del libro diario
            List<LibroDiario> asientos = ObtenerAsientosDesdeBlockchain();

            // Establecer la lista de asientos como ItemsSource del DataGrid
            dataGridLibroDiario.ItemsSource = asientos;
        }

        private List<LibroDiario> ObtenerAsientosDesdeBlockchain()
        {
            List<LibroDiario> asientos = new List<LibroDiario>();

            foreach (var bloque in blockchain.ObtenerBloques())
            {
                // Supongamos que cada bloque tiene un solo asiento
                var asiento = bloque.Data;

                // Verifica que el asiento no sea null antes de procesarlo
                if (asiento != null)
                {
                    // Crear un LibroDiarioItem a partir del asiento
                    var libroDiarioItem = new LibroDiario
                    {
                        Movimiento = asiento.Movimiento,
                        Fecha = asiento.Fecha,
                        Cuenta = asiento.Cuenta,
                        Monto = asiento.Monto,
                        Debe = (asiento.TipoCuenta == TipoCuenta.ACTIVO || asiento.TipoCuenta == TipoCuenta.RESULTADO_POSITIVO),
                        Haber = (asiento.TipoCuenta == TipoCuenta.PASIVO || asiento.TipoCuenta == TipoCuenta.PATRIMONIO || asiento.TipoCuenta == TipoCuenta.RESULTADO_NEGATIVO)
                    };

                    asientos.Add(libroDiarioItem);
                }
            }
            

            return asientos;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}