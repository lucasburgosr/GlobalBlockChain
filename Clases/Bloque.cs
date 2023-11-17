using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using GlobalLabIII.Clases;

namespace GlobalLabIII.Blockchain
{
    using System;

    public class Bloque
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Mensaje { get; set; }
        public Asiento Data { get; set; }

        // Otros campos que puedas necesitar
        

        public Bloque(DateTime timestamp, string mensaje, string previousHash)
        {
            Index = 0; // O el índice que desees para el bloque génesis
            Timestamp = timestamp;
            Mensaje = mensaje;
            PreviousHash = previousHash;
            Hash = CalcularHash();
            Data = Data;
        }
        

        public string CalcularHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Concatenar datos del bloque en una cadena
                string dataString = $"{Index}{Timestamp}{PreviousHash}{Data}";

                // Convertir la cadena en bytes
                byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);

                // Calcular el hash utilizando SHA256
                byte[] hashBytes = sha256.ComputeHash(dataBytes);

                // Convertir el hash a una cadena hexadecimal
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}

