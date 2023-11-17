using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GlobalLabIII.Clases;
using GlobalLabIII.DAO;
using GlobalLabIII.Services;
using WpfApp;

namespace GlobalLabIII
{
    public partial class RegistrarAsientoWindow : Window
    {
        public RegistrarAsientoWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Crear una lista de cuentas
            List<Cuenta> cuentas = CuentaService.ObtenerCuentas();

            // Asignar la lista como ItemsSource del ComboBox
            cmbCuenta.ItemsSource = cuentas;
            // Indicar la propiedad del objeto que se mostrará en el ComboBox
            cmbCuenta.DisplayMemberPath = "Nombre";
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos del formulario
            DateTime fecha = datePickerFecha.SelectedDate ?? DateTime.Now;
            string cuenta = ((Cuenta)cmbCuenta.SelectedItem).Nombre;
            string movimiento = ((ComboBoxItem)cmbMovimiento.SelectedItem).Content.ToString();
            double monto = double.Parse(textBoxMonto.Text);

            string cifrado = "";
            AsientoService.CrearAsiento(cuenta, monto, movimiento, fecha,cifrado);


            AsientoService.CrearAsiento(cuenta, monto, movimiento, fecha,cifrado);


            MessageBox.Show("Registro completado exitosamente", "Registrar Asiento");
        }


        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Puedes agregar aquí la lógica para validar la entrada en el TextBox de Monto
            e.Handled = !char.IsDigit(e.Text, 0);
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