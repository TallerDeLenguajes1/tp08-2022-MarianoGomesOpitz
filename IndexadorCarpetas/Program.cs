// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

namespace IndexadorCarpetas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el directorio");
            int verif = 0;
            string path;
            do
            {
                if (verif > 0)
                {
                    Console.WriteLine("\nEl directorio ingresado no existe, ingrese de nuevo");
                }

                path = Console.ReadLine();
                verif++;
            } while (!Directory.Exists(path));

            if (Directory.GetFiles(path).Length > 0)
            {
                List<string> archivos = Directory.GetFiles(path).ToList();

                var escribir = new StreamWriter(File.Open("../index.csv", FileMode.Create));

                int i = 1;
                foreach (var item in archivos)
                {

                    string arreglo = Path.GetFileNameWithoutExtension(item);
                    string ext = Path.GetExtension(item);
                    string insertar = $"{i},{arreglo},{ext}";
                    escribir.WriteLine(insertar);
                    i++;
                }
                Console.WriteLine("\nNombre de archivos insertados en index.csv:");
                escribir.Close();
                
                var leer = new StreamReader(File.Open("../index.csv", FileMode.Open));
                Console.WriteLine(leer.ReadToEnd());
                leer.Close();

            }
            else
            {
                Console.WriteLine("\nNo hay ningún archivo en esa carpeta");
            }
        }
    }
}