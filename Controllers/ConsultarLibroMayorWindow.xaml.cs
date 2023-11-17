using System;
using System.Windows;
using GlobalLabIII.Services;
using WpfApp;

namespace GlobalLabIII
{
    public partial class ConsultarLibroMayorWindow : Window
    {
        public ConsultarLibroMayorWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fechaInicio = datePickerInicio.SelectedDate ?? DateTime.MinValue;
            DateTime fechaFin = datePickerFin.SelectedDate ?? DateTime.MaxValue;

            double balance = AsientoService.ConsultarLibroMayor(fechaInicio, fechaFin);
            
            MessageBox.Show($"Consulta realizada desde {fechaInicio.ToShortDateString()} hasta {fechaFin.ToShortDateString()} \nBalance Total: $" + balance, "Consulta Exitosa");
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            // Puedes agregar aquí la lógica para volver a la interfaz principal y cerrar la ventana actual
            MainWindow mainWindow = new MainWindow(); // Reemplaza "MainWindow" con el nombre correcto de tu clase principal
            mainWindow.Show();
            Close(); // Cierra la ventana actual
        }
        private void control_fecha(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Bloquea la entrada de cualquier carácter en el TextBox
            e.Handled = true;
        }

    }
}