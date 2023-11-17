using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            
            // Determinamos que tipo de cuenta es en base a la cuenta
            TipoCuenta tipo = DeterminarTipoCuenta(cuenta);
            
            // Determinamos si corresponde al DEBE o al HABER en base del movimiento
            // True == DEBE - False == HABER
            bool debe_haber = debeOHaber(movimiento);
            
            // Crear y registrar el asiento en la base de datos
            Asiento asiento = new Asiento(cuenta, monto, movimiento, fecha, tipo, debe_haber);

            blockchain.AgregarBloque(asiento);

            return asiento;
        }
        
        public static List<LibroDiario> ObtenerAsientosDesdeBlockchain()
        {
            List<LibroDiario> asientos = new List<LibroDiario>();
            
            global::Blockchain blockchain = new global::Blockchain();

            foreach (var bloque in blockchain.ObtenerBloques())
            {
                // Supongamos que cada bloque tiene un solo asiento
                var asiento = bloque.Data;

                // Verifica que el asiento no sea null antes de procesarlo
                if (asiento != null)
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

                    asientos.Add(libroDiarioItem);
                }
            }
            
            asientos = asientos.OrderBy(asiento => asiento.Fecha).ToList();

            return asientos;
        }

        public static double ConsultarLibroMayor(DateTime fechaInicio, DateTime fechaFinal)
        {
            // Obtener la lista de asientos, puedes ajustar esta lógica según tu implementación
            var asientos = ObtenerAsientosDesdeBlockchain();

            // Filtrar los asientos dentro del rango de fechas especificado
            var asientosEnRango = asientos.Where(asiento => asiento.Fecha >= fechaInicio && asiento.Fecha <= fechaFinal);

            // Calcular el balance sumando los montos de los asientos
            double balance = asientosEnRango.Sum(asiento => asiento.Monto);

            return balance;
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

        public static TipoCuenta DeterminarTipoCuenta(string cuenta)
        {
            //Por defecto en Resultado Positivo
            TipoCuenta tipo = TipoCuenta.RESULTADO_POSITIVO;
            
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
                return tipo;
            }
            
            return tipo;
        }

        public static bool debeOHaber(string movimiento)
        {
            if (movimiento == "ACREDITAR")
            {
                return false;
            }else {
                return true;
            }   
        }
    }

}