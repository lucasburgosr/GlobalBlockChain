using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using GlobalLabIII.Enums;

namespace GlobalLabIII.Clases;

public class Asiento
{
    public int Id { get; set; }

    public string Cuenta { get; set; }

    public double Monto { get; set; }

    public string Movimiento { get; set; }
    
    public DateTime Fecha { get; set; }
    
    public TipoCuenta TipoCuenta { get; set; }

    public Asiento()
    {
    }

    public Asiento(string cuenta, double monto, string movimiento, DateTime fecha, TipoCuenta tipoCuenta)
    {
        Cuenta = cuenta;
        Monto = monto;
        Movimiento = movimiento;
        Fecha = fecha;
        TipoCuenta = tipoCuenta;
    }
    

}
