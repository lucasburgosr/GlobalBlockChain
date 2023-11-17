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
        public void CifrarDatos(string clave)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = new byte[16]; // Vector de inicialización (IV) predeterminado

                // Crear un cifrador para realizar la transformación de entrada
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Convertir la cadena de datos a bytes
                byte[] datosBytes = Encoding.UTF8.GetBytes(Datos);

                // Cifrar los datos
                byte[] datosCifrados = encryptor.TransformFinalBlock(datosBytes, 0, datosBytes.Length);

                // Actualizar la propiedad Datos con los datos cifrados en formato Base64
                Datos = Convert.ToBase64String(datosCifrados);
                // Guardar los datos cifrados en el archivo
                GuardarEnArchivo("datos_cifrados.txt", Convert.ToBase64String(datosCifrados));
                
                // Actualizar la propiedad Datos con los datos cifrados en formato Base64
                Datos = Convert.ToBase64String(datosCifrados);
            }
        }

        public void DescifrarDatos(string clave)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = new byte[16]; // Vector de inicialización (IV) predeterminado

                // Crear un descifrador para realizar la transformación de entrada
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Convertir la cadena de datos cifrados a bytes
                byte[] datosCifrados = Convert.FromBase64String(Datos);

                // Descifrar los datos
                byte[] datosDescifrados = decryptor.TransformFinalBlock(datosCifrados, 0, datosCifrados.Length);

                // Actualizar la propiedad Datos con los datos descifrados
                Datos = Encoding.UTF8.GetString(datosDescifrados);
                
                // Guardar los datos descifrados en el archivo
                GuardarEnArchivo("datos_descifrados.txt", Encoding.UTF8.GetString(datosDescifrados));

                // Actualizar la propiedad Datos con los datos descifrados
                Datos = Encoding.UTF8.GetString(datosDescifrados);
            }
        }
        
        private void GuardarEnArchivo(string nombreArchivo, string contenido)
        {
            // Guardar la cadena en el archivo
            File.WriteAllText(nombreArchivo, contenido, Encoding.UTF8);
        }
    }
}