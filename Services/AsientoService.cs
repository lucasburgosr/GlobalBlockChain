using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        

        public static double ConsultarLibroMayor(DateTime fechaInicio, DateTime fechaFinal, List<LibroDiario> asientos)
        {
            // Filtrar los asientos dentro del rango de fechas especificado
            asientos = asientos
                .Where(asiento => asiento.Fecha.Date >= fechaInicio.Date && asiento.Fecha.Date <= fechaFinal.Date)
                .ToList();
            

            // Calcular el balance sumando los montos de los asientos
            double balance = CalcularBalance(asientos);

            return balance;
        }


        private static double CalcularBalance(List<LibroDiario> asientos)
        {
            double DEBE = 0;
            double HABER = 0;

            foreach (var asiento in asientos)
            {
                if (asiento.Operacion == "Debe") //True corresponde al DEBE
                {
                    DEBE += asiento.Monto;
                }
                else //False corresponde al HABER
                {
                    HABER += asiento.Monto; 
                }
            }

            return DEBE - HABER;
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