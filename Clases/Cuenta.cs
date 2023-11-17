using System;
using System.Collections.Generic;
using GlobalLabIII.Enums;
using MySql.Data.MySqlClient;

namespace GlobalLabIII.Clases;

public class Cuenta
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public TipoCuenta TipoCuenta { get; set; }
    
}
