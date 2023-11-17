using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GlobalLabIII.Blockchain;
using GlobalLabIII.Clases;

public class Blockchain
{
    private static List<Bloque> _blocks;

    public Blockchain()
    {
        InicializarBlockchain();
    }

    private void InicializarBlockchain()
    {
        _blocks = new List<Bloque>();
        AgregarBloqueGenesis();
    }

    public void AgregarBloqueGenesis()
    {
        // Crea el bloque génesis con un mensaje y un hash arbitrario
        DateTime timestamp = DateTime.Now;
        string previousHash = "0"; // Hash arbitrario para el bloque génesis
        Bloque genesisBlock = new Bloque(timestamp, "Bloque genesis", previousHash);

        // Agrega el bloque génesis a la cadena
        _blocks.Add(genesisBlock);
    }

    /*public void AgregarBloque(Asiento data)
    {
        Bloque ultimoBloque = ObtenerUltimoBloque();
        int index = _blocks.Count;

        DateTime timestamp = DateTime.Now;
        string previousHash = ultimoBloque.Hash;

        // Crear un bloque con un asiento y otros datos
        Bloque nuevoBloque = new Bloque(timestamp, "Nuevo bloque", previousHash)
        {
            Index = index,
            // Otras propiedades del bloque que puedas necesitar
            Data = data
        };

        _blocks.Add(nuevoBloque);

        // Serializar y persistir la lista de bloques en un archivo .json
        GuardarBlockchainEnArchivo();
    }*/
    
    public void AgregarBloque(Asiento data)
    {
        // Cargar la información existente desde el archivo
        CargarBlockchainDesdeArchivo();

        Bloque ultimoBloque = ObtenerUltimoBloque();
        int index = _blocks.Count;

        DateTime timestamp = DateTime.Now;
        string previousHash = ultimoBloque.Hash;

        // Crear un bloque con un asiento y otros datos
        Bloque nuevoBloque = new Bloque(timestamp, "Nuevo bloque", previousHash)
        {
            Index = index,
            // Otras propiedades del bloque que puedas necesitar
            Data = data
        };

        _blocks.Add(nuevoBloque);

        // Serializar y persistir la lista de bloques en un archivo .json
        GuardarBlockchainEnArchivo();
    }

    public void CargarBlockchainDesdeArchivo()
    {
        string rutaArchivo = "blockchain.json";

        try
        {
            // Leer el JSON desde el archivo
            string jsonBlockchain = File.ReadAllText(rutaArchivo);

            // Deserializar el JSON a una lista de bloques
            _blocks = JsonSerializer.Deserialize<List<Bloque>>(jsonBlockchain);

            Console.WriteLine("Blockchain cargada desde el archivo blockchain.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar la blockchain desde el archivo: {ex.Message}");
        }
    }

    public Bloque ObtenerUltimoBloque()
    {
        if (_blocks.Count > 0)
        {
            return _blocks[_blocks.Count - 1];
        }

        return null;
    }
    
    public List<Bloque> ObtenerBloques()
    {
        return _blocks;
    }

    private static void GuardarBlockchainEnArchivo()
    {
        string rutaArchivo = "blockchain.json";

        try
        {
            // Serializar la lista de bloques a formato JSON
            string jsonBlockchain = JsonSerializer.Serialize(_blocks, new JsonSerializerOptions { WriteIndented = true });

            // Escribir el JSON en un archivo .json
            File.WriteAllText(rutaArchivo, jsonBlockchain);

            Console.WriteLine("Blockchain guardada en el archivo blockchain.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar la blockchain en el archivo: {ex.Message}");
        }
    }
}
