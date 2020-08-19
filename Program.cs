using System;
using System.IO;
using System.Collections.Generic;
using Helpers;

namespace tpn9_SimonHolmquist
{
    class Program
    {
        static void Main(string[] args)
        {
            //PUNTO 1

            // //origen
            // string origen = Environment.CurrentDirectory + @"\bin\Debug";
            // //destino
            // string destino = @"\hello";
            // SoporteParaConfiguracion.CrearArchivoDeConfiguracion(destino);
            // string destinoFinal = SoporteParaConfiguracion.LeerConfiguracion();
            // if (!Directory.Exists(destinoFinal)) Directory.CreateDirectory(destinoFinal);
            // var archivos = Directory.GetFiles(origen);
            // foreach (var archivo in archivos)
            // {
            //     var fileInfo = new FileInfo(archivo);
            //     if (fileInfo.Extension == ".mp3" || fileInfo.Extension == ".txt")
            //     {
            //         try
            //         {
            //             File.Move(archivo, destinoFinal + "\\" + fileInfo.Name);
            //         }
            //         catch
            //         {
            //             System.Console.WriteLine("Hay un archivo con el mismo nombre en el destino");
            //         }
            //     }
            // }

            //PUNTO 2

            ConversorDeMorse.ingresarTexto();
            var fecha = DateTime.Now.ToString("dd_MM_yyyy");
            ConversorDeMorse.leerTexto(fecha);
            Console.ReadKey();
        }
    }
}
