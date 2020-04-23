using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Models
{
    public class Pirat
    {
        [Key]
        [BindNever]
        public int PiratId { get; set; }

       
        [BindNever]
        public ICollection<PiratSchiff> PiratSchiff { get; set; } = new HashSet<PiratSchiff>();


        [Required(ErrorMessage = "Bitte den Vornamen angeben")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bitte den Nachnamen angeben")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Das Feld 'Straße' darf nicht leer sein.")]
        public string Street { get; set; }



        [Required(ErrorMessage = "Das Feld 'Hausnummer' darf nicht leer sein.")]
        public string HouseNumber { get; set; }


        [Required(ErrorMessage = "Das Feld 'PLZ' darf nicht leer sein.")]
        public string ZIP { get; set; }


        [Required(ErrorMessage = "Das Feld 'Stadt' darf nicht leer sein.")]
        public string City { get; set; }


        [Required(ErrorMessage = "Das Feld 'Motiv' darf nicht leer sein.")]
        public string Motiv { get; set; } = null;

    }
}
