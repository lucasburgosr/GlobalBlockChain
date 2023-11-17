using System;
using System.Collections.Generic;
using GlobalLabIII.Clases;
using GlobalLabIII.DAO;
using MySql.Data.MySqlClient;

namespace GlobalLabIII.Services;

public class CuentaService
{
    public static List<Cuenta> ObtenerCuentas()
    {
        MySqlConnection conexion = null;

        try
        {
            // Abrir la conexión
            conexion = DatabaseConfig.Conectar();

            // Verificar que la conexión esté abierta
            if (conexion == null || conexion.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("No se pudo abrir la conexión.");
                return null;
            }

            // Llamar a un método de DataAccess para obtener las cuentas
            List<Cuenta> cuentas = DataAccess.ObtenerCuentas(conexion);

            return cuentas;
        }
        finally
        {
            // Asegurarse de cerrar la conexión, incluso si hay errores
            if (conexion != null)
            {
                DatabaseConfig.Desconectar(conexion);
            }
        }
    }
}