using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GlobalLabIII.Blockchain
{
    public class Bloque
    {
        public int Numero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Datos { get; set; }
        public string HashAnterior { get; set; }
        public string HashActual { get; set; }

        public Bloque(int numero, DateTime fechaCreacion, string datos, string hashAnterior)
        {
            Numero = numero;
            FechaCreacion = fechaCreacion;
            Datos = datos;
            HashAnterior = hashAnterior;
            CalcularHash();
        }

        public void CalcularHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Concatenar los datos del bloque
                string datosConcatenados = $"{Numero}-{FechaCreacion}-{Datos}-{HashAnterior}";

                // Convertir la cadena concatenada a un arreglo de bytes
                byte[] datosBytes = Encoding.UTF8.GetBytes(datosConcatenados);

                // Calcular el hash utilizando SHA-256
                byte[] hashBytes = sha256.ComputeHash(datosBytes);

                // Convertir el resultado a una cadena hexadecimal
                StringBuilder hashBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hashBuilder.Append(hashBytes[i].ToString("x2"));
                }

                HashActual = hashBuilder.ToString();
            }
        }

        public string CifrarDatos(string clave)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = new byte[16]; // Puedes considerar utilizar un IV aleatorio para mayor seguridad

                // Cifrar los datos
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Escribir los datos cifrados en el flujo de cifrado
                            swEncrypt.Write($"{Numero}-{FechaCreacion}-{Datos}-{HashAnterior}");
                        }
                    }

                    // Obtener los bytes cifrados
                    byte[] datosCifrados = msEncrypt.ToArray();

                    // Convertir los bytes cifrados a una cadena hexadecimal
                    return BitConverter.ToString(datosCifrados).Replace("-", "");
                }
            }
        }

        public string DescifrarDatos(string clave, string datosCifrados)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = new byte[16]; // Puedes generar un IV único o utilizar un esquema de generación seguro

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(datosCifrados)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
