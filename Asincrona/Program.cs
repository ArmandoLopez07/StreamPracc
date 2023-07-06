using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Asincrona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream(150);
            List<Persona> per = new List<Persona>();

            LeerDatos(ref per);


            /*
             /-----------------------------buscar en stream-------------------/
            ms.Seek(0, SeekOrigin.Begin); // permite buscar un sitio en el memory stream (inicial, valor referencia)

            ms.Seek(5, SeekOrigin.Current); // nuestra posicion se utiliza como referencia

            ms.Seek(5, SeekOrigin.End); // el final se usa como referencia8

            /-----------------------leer stream--------------------/

            byte[] buffer = new byte[capacidad]; // sera el lugar donde se guarda la informacion del stream

            ms.Read(buffer, 0, capacidad); // lee el stream recibe cual leer, inicio y final 
            /------------------------escribir stream-------------------------------------/
            Console.WriteLine("Introduce una cadena");
            string miInfo = Console.ReadLine();
            byte[] buffer = new byte [capacidad];

            ms.Write(ASCIIEncoding.ASCII.GetBytes(miInfo), 0, miInfo.Length); //escribimos en el stream usando ascii
            ms.Seek(0, SeekOrigin.Begin);//nos posicionamos
            ms.Read(buffer,0, miInfo.Length);//leemos todo el stream

            Console.WriteLine(ASCIIEncoding.ASCII.GetString(buffer));//escribimos el stream en ascii

            ms.Close(); */

            /*FileStream fsescribe = new FileStream("archivoprueba.txt", FileMode.Create); // instanciamos filestream para realizar archivos modos podibles para filename(append,create,createnew,open,openorcreate,truncate)
            string cadena = "Cadena de ejemplo";

            fsescribe.Write(ASCIIEncoding.ASCII.GetBytes( cadena), 0, cadena.Length);

            byte[] ba = new byte[200];

            FileStream fs = new FileStream("archivoprueba.txt", FileMode.Open);

            fs.Read(ba, 0, (int)ba.Length);

            Console.WriteLine(ASCIIEncoding.ASCII.GetString(ba));
            Console.ReadKey();

            fs.Close();*/




        }
        public static void LeerDatos(ref List<Persona> per)
        {
            bool FlagPersona = false;
            

            while (FlagPersona == false )
            {
                Console.WriteLine("Presiona S para agregar un registro o N para salir");
                if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    Persona persona = new Persona();

                    Console.WriteLine("Escribe El nombre");
                    persona.nombre = Console.ReadLine();
                    Console.WriteLine("Escribe la edad");
                    persona.edad = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Escribe su localidad");
                    persona.localidad = Console.ReadLine();

                    per.Add(persona);

                    
                }
                else if(Console.ReadKey().Key == ConsoleKey.N) 
                {
                    EscribirArchivo(ref per);
                    FlagPersona = true;
                    foreach (var a in per)
                    {
                        var nombre = a.nombre;
                        var eda = a.edad;
                        var local = a.localidad;

                        string cadena = $"{nombre} | {eda} | {local} ;";

                        Console.WriteLine(cadena);
                    }
                }
            }
        }
        public static void EscribirArchivo(ref List<Persona> per)
        {
            Console.WriteLine("Escribe el nombre de tu archivo");
            var archivo = Console.ReadLine();
            FileStream fs = new FileStream($"{archivo}.txt", FileMode.Create);
            foreach (var a in per)
            {
                var nombre = a.nombre;
                var eda = a.edad;
                var local = a.localidad;

                string cadena = $"{nombre} | {eda} | {local} ;";

                fs.Write(ASCIIEncoding.ASCII.GetBytes(cadena), 0 , cadena.Length);
            }
        }
    }
}
