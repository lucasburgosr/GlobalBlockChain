using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GlobalLabIII.Blockchain;
using GlobalLabIII.Clases;
using GlobalLabIII.DAO;
using GlobalLabIII.Enums;
using MySql.Data.MySqlClient;

namespace GlobalLabIII.Services
{
    public class AsientoService
    {
        public static Asiento CrearAsiento(string cuenta, double monto, string movimiento, DateTime fecha)
        {
            global::Blockchain blockchain = new global::Blockchain();
            // Inicializamos por defecto en Activo
            TipoCuenta tipo = TipoCuenta.ACTIVO;

            if (cuenta == "CAJA" || cuenta == "BANCO C/C")
            {
                tipo = TipoCuenta.ACTIVO;
            }
            else if (cuenta == "ACREEDORES" || cuenta == "PROVEEDORES")
            {
                tipo = TipoCuenta.PASIVO;
            }
            else if (cuenta == "CAPITAL")
            {
                tipo = TipoCuenta.PATRIMONIO;
            }
            else if (cuenta == "INTERESES CEDIDOS" || cuenta == "DESCUENTOS CEDIDOS")
            {
                tipo = TipoCuenta.RESULTADO_NEGATIVO;
            }
            else
            {
                tipo = TipoCuenta.RESULTADO_POSITIVO;
            }

            // Crear y registrar el asiento en la base de datos
            Asiento asiento = new Asiento(cuenta, monto, movimiento, fecha, tipo);

            blockchain.AgregarBloque(asiento);

            return asiento;
        }

        public static double ConsultarLibroMayor(DateTime fechaInicio, DateTime fechaFinal)
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
                }

                // Llamar a un método de DataAccess para obtener los asientos de ese intervalo de fechas
                List<Asiento> asientos = DataAccess.ObtenerAsientosPorFecha(conexion, fechaInicio, fechaFinal);

                double balance = CalcularBalance(asientos);

                return balance;
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

        private static double CalcularBalance(List<Asiento> asientos)
        {
            double balance = 0;
            double DEBE = 0;
            double HABER = 0;

            foreach (var asiento in asientos)
            {
                string movimiento = asiento.Movimiento;
                TipoCuenta tipo = asiento.TipoCuenta;

                if (movimiento == "Egreso")
                {
                    if (tipo == TipoCuenta.PASIVO || tipo == TipoCuenta.PATRIMONIO || tipo == TipoCuenta.RESULTADO_POSITIVO)
                    {
                        HABER += asiento.Monto;
                    }
                    else
                    {
                        HABER -= asiento.Monto;
                    }
                }
                else // SI ES UN INGRESO 
                {
                    if (tipo == TipoCuenta.ACTIVO || tipo == TipoCuenta.RESULTADO_NEGATIVO)
                    {
                        DEBE += asiento.Monto;
                    }
                    else
                    {
                        DEBE -= asiento.Monto;
                    }
                }
            }

            balance = DEBE - HABER;
            return balance;
        }

        

        
    }
}