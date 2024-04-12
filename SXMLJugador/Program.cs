using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SXMLJugador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            String valor = "";

            Console.WriteLine("1) Crear y serializar jugador, 2) Leer jugador");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            if (opcion == 1)
            {
                //Creamos el objeto CJugador
                string name = "";
                string role = "";
                int level = 0;

                Console.WriteLine("Escribe el nombre del jugador:");
                name = Console.ReadLine();

                Console.WriteLine("Escribe el rol del jugador: ");
                role = Console.ReadLine();

                Console.WriteLine("Escribe el nivel del jugador:");
                valor = Console.ReadLine();
                level = Convert.ToInt32(valor);

                CJugador miJugador = new CJugador();
                miJugador.Name = name;
                miJugador.Role = role;
                miJugador.Level = level;

                Console.WriteLine("Jugador a serializar");
                miJugador.MuestraInformacion();

                //Empezamos la serializacion
                Console.WriteLine("---SERIALIZAMOS---");

                //Sellecionamos el formateador
                XmlSerializer formateador = new XmlSerializer(typeof(CJugador));

                //Se crea el stream
                Stream miStream = new FileStream("Jugador.jug", FileMode.Create, FileAccess.Write, FileShare.None);

                //Serializamos
                formateador.Serialize(miStream, miJugador);

                //Cerramos el stream
                miStream.Close();
            }

            if (opcion == 2)
            {
                //Deserealizamos el objeto
                Console.WriteLine("---DESEREALIZANDO---");

                //Seleccionamos el formateador
                XmlSerializer formateador = new XmlSerializer(typeof(CJugador));

                //Creamos el Stream
                Stream miStream = new FileStream("Jugador.jug", FileMode.Open, FileAccess.Read, FileShare.None);

                //Deserializamos
                CJugador miJugador = (CJugador)formateador.Deserialize(miStream);

                //Cerramos el stream
                miStream.Close();

                //Usamos el objeto
                Console.WriteLine("El auto deserializado es: ");
                miJugador.MuestraInformacion();
            }
        }
    }
}
