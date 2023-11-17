using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace GlobalLabIII;

//Clase de configuración de la BD
public class DatabaseConfig
{
    //Modificar este string según la base de datos y las credenciales de usuario
    public static string cadenaConexion = "Server=localhost;Database=lab3global;User ID=root;Password=root;";

    public static MySqlConnection Conectar()
    {
        MySqlConnection conexion = new MySqlConnection(cadenaConexion);

        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar a MySQL: {ex.Message}");
            return null;
        }
    }

    public static void Desconectar(MySqlConnection conexion)
    {
        try
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al desconectar de MySQL: {ex.Message}");
        }
    }
    
    public static MySqlConnection ObtenerConexion()
    {
        return new MySqlConnection(cadenaConexion);
    }
}