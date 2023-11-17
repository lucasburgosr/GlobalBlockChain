using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GlobalLabIII.Clases;
using GlobalLabIII.Services;
using WpfApp;

namespace GlobalLabIII
{
    public partial class ConsultarLibroMayorWindow : Window
    {
        private global::Blockchain blockchain;
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
            
            List<LibroDiario> asientos = CargarDatos();

            double balance = AsientoService.ConsultarLibroMayor(fechaInicio, fechaFin, asientos);
            
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
        
        private List<LibroDiario> CargarDatos()
        {
            // Crear una instancia de la clase Blockchain
            blockchain = new global::Blockchain();

            // Cargar los bloques desde el archivo
            blockchain.CargarBlockchainDesdeArchivo();

            // Obtener la lista de asientos del libro diario
            List<LibroDiario> asientos = ObtenerAsientosDesdeBlockchain();

            return asientos;


        }
        
        private List<LibroDiario> ObtenerAsientosDesdeBlockchain()
        {
            List<LibroDiario> asientos = new List<LibroDiario>();

            foreach (var bloque in blockchain.ObtenerBloques())
            {
                // Supongamos que cada bloque tiene un solo asiento
                var asiento = bloque.Data;

                // Verifica que el asiento no sea null y que tenga datos antes de procesarlo
                if (asiento != null && !string.IsNullOrEmpty(asiento.Movimiento) &&
                    !string.IsNullOrEmpty(asiento.Cuenta))
                {
                    // Determina si es Debe o Haber
                    string operacion = asiento.DebeHaber ? "Debe" : "Haber";

                    // Crear un LibroDiarioItem a partir del asiento
                    var libroDiarioItem = new LibroDiario
                    {
                        Movimiento = asiento.Movimiento,
                        Fecha = asiento.Fecha,
                        Cuenta = asiento.Cuenta,
                        Monto = asiento.Monto,
                        Operacion = operacion
                    };
                    // Verifica que el asiento no sea null antes de procesarlo
                    if (asiento != null)
                    {
                        asientos.Add(libroDiarioItem);
                    }
                }
            }

            asientos = asientos.OrderBy(asiento => asiento.Fecha).ToList();
            return asientos;
        }

    }
}