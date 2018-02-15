using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1MLS.Models
{ 
    public class Jugador
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public String Name { get; set; }

        [Display(Name = "Apellido")]
        public String LastName { get; set; }

        [Display(Name = "Posición")]
        public String Position { get; set; }

        [Display(Name = "Salario Base")]
        public String SalarioBase { get; set; }

        [Display(Name = "Salario total")]
        public String SalarioTotal { get; set; }
        
        [Display(Name = "Club")]
        public String Club { get; set; }

        public static Comparison<Jugador> CompareByName = delegate (Jugador j1, Jugador j2)
        {
            return j1.Name.CompareTo(j2.Name);
        };

        public static Comparison<Jugador> CompareByNLastame = delegate (Jugador j1, Jugador j2)
        {
            return j1.LastName.CompareTo(j2.LastName);
        };

        public static Comparison<Jugador> CompareByPosition = delegate (Jugador j1, Jugador j2)
        {
            return j1.Position.CompareTo(j2.Position);
        };

        public static Comparison<Jugador> CompareBySalario = delegate (Jugador j1, Jugador j2)
        {
            return j1.SalarioBase.CompareTo(j2.SalarioBase);
        };

        public static Comparison<Jugador> CompareByClub = delegate (Jugador j1, Jugador j2)
        {
            return j1.Club.CompareTo(j2.Club);
        };
    }

}