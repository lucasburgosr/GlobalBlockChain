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
                        TipoCuenta = (TipoCuenta)Enum.Parse(typeof(TipoCuenta), Convert.ToString(reader["Tipo_de_cuenta"])),
                        TipoCuentaString = Convert.ToString(reader["Tipo_de_Cuenta"])
                    };

                    cuentas.Add(cuenta);
                }
            }
        }

        return cuentas;
    }
}
