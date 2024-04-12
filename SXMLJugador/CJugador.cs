using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;  //El formateador binario toma la información de la memoria bit pot bi y lo guarda.
using System.IO;
using System.Reflection;

namespace SXMLJugador
{
    [Serializable]
    public class CJugador
    {
        private String name;
        private String role;
        private int level;

        public String Name { set { name = value; } get { return name; } }
        public String Role { set { role = value; } get { return role; } }
        public int Level { set { level = value; } get { return level; } }

        //Constructor vacio
        public CJugador() 
        {
            name = "Monarca";
            role = "Asesino";
            level = 15;
        }

        public void MuestraInformacion()
        {
            //Mostramos la informacion necesaria
            Console.WriteLine("Nombre de jugador: {0}", name);
            Console.WriteLine("Rol del jugador: {0}", role);
            Console.WriteLine("Nivel: {0}", level);
            Console.WriteLine("------------------");
        }
    }
}
