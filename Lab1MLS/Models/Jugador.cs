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
    }

}