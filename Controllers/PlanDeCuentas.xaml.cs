using System.Collections.Generic;
using System.Windows;
using GlobalLabIII.Clases;
using GlobalLabIII.Services;
using WpfApp;

namespace GlobalLabIII;

public partial class PlanDeCuentasWindow : Window
{
    public PlanDeCuentasWindow()
    {
        InitializeComponent();
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        Loaded += PlanDeCuentasWindow_Loaded;
    }

    private void PlanDeCuentasWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // Aquí cargarías los datos desde tu base de datos
        List<Cuenta> cuentas = CuentaService.ObtenerCuentas();

        // Establecer la lista de cuentas como origen de datos para el ListBox
        listBoxCuentas.ItemsSource = cuentas;
    }
    
    private void btnVolver_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow(); // Reemplaza "MainWindow" con el nombre correcto de tu clase principal
        mainWindow.Show();
        Close(); // Cierra la ventana actual
    }
}
