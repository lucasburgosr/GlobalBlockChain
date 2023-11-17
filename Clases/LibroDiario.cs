using System;

namespace GlobalLabIII.Clases;

public class LibroDiario
{
    public string Movimiento { get; set; }
    public DateTime Fecha { get; set; }
    public string Cuenta { get; set; }
    public double Monto { get; set; }
    public bool Debe { get; set; }
    public bool Haber { get; set; }
}