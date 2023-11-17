using System;
using System.Collections.Generic;
using System.Windows;
using GlobalLabIII.Clases;
using GlobalLabIII.DAO;
using MySql.Data.MySqlClient;
using WpfApp;

namespace GlobalLabIII
{
    public partial class VerLibroDiarioWindow : Window
    {
        public VerLibroDiarioWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Llenar el DataGrid con datos de ejemplo (ajustar según la lógica real)
            CargarDatosAsientos();
        }

        private void CargarDatosAsientos()
        {
            // Aquí debes tener la lógica para obtener los asientos desde la base de datos
            // Estos son datos de ejemplo, debes reemplazarlos con tu lógica real
            List<Asiento> asientos = ObtenerAsientos();

            // Asignar la lista de asientos al DataGrid
            dataGridLibroDiario.ItemsSource = asientos;
        }

        private List<Asiento> ObtenerAsientos()
        {
            List<Asiento> asientos = new List<Asiento>
            {
                // Agregar más asientos según tu lógica
            };

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