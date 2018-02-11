using Lab1MLS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public List<Jugador> Jugadores = new List<Jugador>();
    }
}