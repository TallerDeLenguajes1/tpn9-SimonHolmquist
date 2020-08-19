using System;
using System.IO;
// CrearArchivoDeConfiguracion tendrá la capacidad de crear archivos
// .dat (con el cual podrá crear el archivo detino.dat)
// ○ LeerConfiguracion leerá el archivo .dat
// ● El sistema deberá listar todos los archivos en el directorio raíz del programa
// (“carpeta_del_proyecto\bin\debug\”) y seleccionará solamente los que sean de
// extensión .mp3 y .txt y los moverá al directorio establecido en el archivo binario
// detino.dat.
// Para esta tarea puede usar la clase:
// System.IO.Path que le permitirán trabajar con rutas de archivos.
// Otra forma de resolverlo es utilizando los métodos aprendidos con la
// clase Directory y combinarlos con los métodos de el objeto string
namespace Helpers
{
    public static class SoporteParaConfiguracion
    {

        const string destino = @"\destino.dat";
        public static void CrearArchivoDeConfiguracion(string ruta)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            using (var writer = new BinaryWriter(File.Open(currentDirectory + destino, FileMode.Create)))
            {
                writer.Write(currentDirectory + ruta);
            }
        }
        public static string LeerConfiguracion()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            string ruta = "";
            if (File.Exists(currentDirectory + destino))
            {
                using (var reader = new BinaryReader(File.Open(currentDirectory + destino, FileMode.Open)))
                {
                    ruta = reader.ReadString();
                }
            }
            return ruta;
        }

    }
}