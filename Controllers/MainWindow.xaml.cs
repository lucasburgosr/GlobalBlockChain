using System.Windows;
using GlobalLabIII;


namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnRegistrarAsiento_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la nueva ventana
            RegistrarAsientoWindow registrarAsientoWindow = new RegistrarAsientoWindow();

            // Mostrar la nueva ventana
            registrarAsientoWindow.Show();

            // Cerrar la ventana actual (MainWindow)
            this.Close();
        }

        private void btnConsultarLibroMayor_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana LibroMayorWindow
            ConsultarLibroMayorWindow libroMayorWindow = new ConsultarLibroMayorWindow();

            // Mostrar la ventana LibroMayorWindow
            libroMayorWindow.Show();

            // Cerrar la ventana actual (MainWindow)
            this.Close();
        }

        private void btnPlanDeCuentas_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana Plan De Cuentas
            PlanDeCuentasWindow planDeCuentasWindow = new PlanDeCuentasWindow();

            // Mostrar la ventana LibroMayorWindow
            planDeCuentasWindow.Show();

            // Cerrar la ventana actual (MainWindow)
            this.Close();
        }
        
        private void btnVerLibroDiario_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana Plan De Cuentas
            PlanDeCuentasWindow planDeCuentasWindow = new PlanDeCuentasWindow();

            // Mostrar la ventana LibroMayorWindow
            planDeCuentasWindow.Show();

            // Cerrar la ventana actual (MainWindow)
            this.Close();
        }
    }
}