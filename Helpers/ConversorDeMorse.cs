using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Helpers
{
    public static class ConversorDeMorse
    {
        static Dictionary<char, string> letras = new Dictionary<char, string>()
        {
            {'a' , ".-"},
            {'b' , "-..."},
            {'c' , "-.-."},
            {'d' , "-.."},
            {'e' , "."},
            {'f' , "..-."},
            {'g' , "--."},
            {'h' , "...."},
            {'i' , ".."},
            {'j' , ".---"},
            {'k' , "-.-"},
            {'l' , ".-.."},
            {'m' , "--"},
            {'n' , "-."},
            {'o' , "---"},
            {'p' , ".--."},
            {'q' , "--.-"},
            {'r' , ".-."},
            {'s' , "..."},
            {'t' , "-"},
            {'u' , "..-"},
            {'v' , "...-"},
            {'w' , ".--"},
            {'x' , "-..-"},
            {'y' , "-.--"},
            {'z' , "--.."},
            {'1' , ".---"},
            {'2' , "..---"},
            {'3' , "...--"},
            {'4' , "....-"},
            {'5' , "....."},
            {'6' , "-...."},
            {'7' , "--..."},
            {'8' , "---.."},
            {'9' , "----."},
            {'0' , "-----"}
        };
        public static string MorseAtexto(string morse)
        {
            var palabras = morse.Split('/');
            var traduccion = "";
            foreach (var palabra in palabras)
            {
                foreach (var letra in palabra.Split(' '))
                {
                    traduccion += letras.FirstOrDefault(x => x.Value.Equals(letra)).Key;
                }
                traduccion += " ";
            }
            return traduccion;
        }

        public static string TextoAMorse(string texto)
        {
            string[] palabras = texto.Split(' ');
            string traduccion = "";

            foreach (string palabra in palabras)
            {
                foreach (char letra in palabra.ToLower())
                {
                    traduccion += letras[letra];
                    traduccion += " ";
                }
                traduccion += "/ ";
            }

            return traduccion;
        }

        public static void ingresarTexto()
        {
            System.Console.WriteLine("Ingrese el texto que desea convertir a morse");
            var texto = Console.ReadLine();
            var destino = Directory.GetCurrentDirectory() + @"\Morse";
            var fecha = DateTime.Now.ToString("dd_MM_yyyy");
            if (!Directory.Exists(destino))
            {
                Directory.CreateDirectory(destino);
            }
            using (
                    var writer = new StreamWriter(
                        new FileStream(
                            destino + $"\\morse_{fecha}.txt",
                            FileMode.Create
                        )
                    )
                )
            {
                writer.WriteLine(TextoAMorse(texto));
            }
        }

        public static void leerTexto(string fecha)
        {
            var destino = Environment.CurrentDirectory + @"\Morse";
            var file = destino + $"\\morse_{fecha}.txt";
            if (File.Exists(file))
            {
                using (
                    var reader = new StreamReader(
                        new FileStream(file,
                        FileMode.Open)
                    )
                )
                {
                    var texto = MorseAtexto(reader.ReadLine());
                    System.Console.WriteLine(texto);
                    using (
                    var writer = new StreamWriter(
                        new FileStream(
                            destino + $"\\texto_{fecha}.txt",
                            FileMode.Create
                            )
                        )
                    )
                    {
                        writer.Write(texto);
                    }
                }
            }
        }
    }
}