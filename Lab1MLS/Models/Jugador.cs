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
        int Id { get; set; }
        [Display(Name = "Nombre")]
        String Name { get; set; }
        [Display(Name = "Apellido")]
        String LastName { get; set; }
        [Display(Name = "Posición")]
        String Position { get; set; }
        [Display(Name = "Salario Base")]
        String SalarioBase { get; set; }
        [Display(Name = "Salario total")]
        String SalarioTotal { get; set; }
        [Display(Name = "Club")]
        String Club { get; set; }
    }

}