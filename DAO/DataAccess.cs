using System;
using System.Collections.Generic;
using GlobalLabIII.Clases;
using GlobalLabIII.Enums;
using MySql.Data.MySqlClient;

namespace GlobalLabIII.DAO;

public class DataAccess
{
    public static List<Cuenta> ObtenerCuentas(MySqlConnection conexion)
    {
        List<Cuenta> cuentas = new List<Cuenta>();

        // Aquí debes escribir la consulta SQL para obtener las cuentas
        string consulta = "SELECT Id, Nombre, Tipo_de_cuenta FROM Cuentas";

        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
        {
            using (MySqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cuenta cuenta = new Cuenta
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        TipoCuenta = (TipoCuenta)Enum.Parse(typeof(TipoCuenta), Convert.ToString(reader["Tipo_de_cuenta"]))
                    };

                    cuentas.Add(cuenta);
                }
            }
        }

        return cuentas;
    }

    public static Asiento registrarAsiento(MySqlConnection conexion, Asiento asiento)
    {
        string consulta = "INSERT INTO Asiento (fecha, cuenta, movimiento, monto, tipoCuenta) VALUES (@fecha, @cuenta, @movimiento, @monto, @tipoCuenta)";
        
        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
        {
            comando.Parameters.AddWithValue("@fecha", asiento.Fecha);
            comando.Parameters.AddWithValue("@cuenta", asiento.Cuenta);
            comando.Parameters.AddWithValue("@movimiento", asiento.Movimiento);
            comando.Parameters.AddWithValue("@monto", asiento.Monto);
            comando.Parameters.AddWithValue("@tipoCuenta", asiento.TipoCuenta.ToString());
            
            comando.ExecuteNonQuery();
        }

        return asiento;

    }
    
    public static List<Asiento> ObtenerAsientosPorFecha(MySqlConnection conexion, DateTime fechaInicio, DateTime fechaFin)
    {
        List<Asiento> asientos = new List<Asiento>();

        string consulta = "SELECT id, movimiento, monto, tipoCuenta FROM Asiento WHERE fecha BETWEEN @FechaInicio AND @FechaFin";

        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
        {
            comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            comando.Parameters.AddWithValue("@FechaFin", fechaFin);

            using (MySqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Asiento asiento = new Asiento
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Movimiento = Convert.ToString(reader["movimiento"]),
                        Monto = Convert.ToDouble(reader["monto"]),
                        TipoCuenta = Enum.Parse<TipoCuenta>(Convert.ToString(reader["tipoCuenta"]))
                    };

                    asientos.Add(asiento);
                }
            }
        }

        return asientos;
    }
}
