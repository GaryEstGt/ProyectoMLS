using Lab1MLS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ListaBiblioteca;

namespace Lab1MLS
{
    public class Data
    {
        private static Data Instance;
        public static Data instance
        {

            get
            {
                if (Instance == null)
                {
                    Instance = new Data();
                }
                return Instance;
            }
            set { Instance = value; }
        }
        public LinkedList<Jugador> Jugadores = new LinkedList<Jugador>();
        ListaDoblementeEnlazada<Jugador> JugadoresLA = new ListaDoblementeEnlazada<Jugador>();
        public int contador = 1;
        public int contador2 = 1;
        public int Ultimonumero = 0;
    }
}