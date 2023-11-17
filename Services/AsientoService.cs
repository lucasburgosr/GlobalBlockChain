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
        private const string RutaArchivoBlockchain = "blockchain.txt";

        public static void CrearBlockchain()
        {
            // Crear un bloque génesis
            var bloqueGenesis = new Bloque(0, DateTime.Now, "Bloque Génesis", string.Empty);

            // Guardar el bloque génesis en el archivo
            GuardarBloqueEnArchivo(bloqueGenesis);
        }

        public static Asiento CrearAsiento(string cuenta, double monto, string movimiento, DateTime fecha)
        {
            // Obtener el último bloque en la cadena
            var ultimoBloque = ObtenerUltimoBloque();

            // Crear un nuevo bloque con los datos del asiento
            var nuevoBloque = new Bloque(ultimoBloque.Numero + 1, DateTime.Now, $"{cuenta}-{monto}-{movimiento}-{fecha}", ultimoBloque.HashActual);

            // Guardar el nuevo bloque en el archivo
            GuardarBloqueEnArchivo(nuevoBloque);

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

                // Llamar a un método de DataAccess para registrar el asiento
                DataAccess.registrarAsiento(conexion, asiento);
            }
            finally
            {
                // Asegurarse de cerrar la conexión, incluso si hay errores
                if (conexion != null)
                {
                    DatabaseConfig.Desconectar(conexion);
                }
            }

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

        private static Bloque ObtenerUltimoBloque()
        {
            // Leer el archivo y obtener el último bloque
            var lineas = File.ReadAllLines(RutaArchivoBlockchain);

            if (lineas.Length > 0)
            {
                var ultimaLinea = lineas[lineas.Length - 1];
                var partes = ultimaLinea.Split('|');
                return new Bloque(
                    int.Parse(partes[0]),
                    DateTime.Parse(partes[1]),
                    partes[2],
                    partes[3]
                );
            }
            else
            {
                // Si no hay bloques, crear la cadena de bloques con el bloque génesis
                CrearBlockchain();
                return new Bloque(0, DateTime.Now, "Bloque Génesis", string.Empty);
            }
        }

        private static void GuardarBloqueEnArchivo(Bloque bloque)
        {
            // Crear el formato de cadena para el bloque
            var cadenaBloque = $"{bloque.Numero}|{bloque.FechaCreacion}|{bloque.Datos}|{bloque.HashAnterior}|{bloque.HashActual}";

            // Agregar la cadena del bloque al archivo
            File.AppendAllLines(RutaArchivoBlockchain, new[] { cadenaBloque }, Encoding.UTF8);
        }
    }
}