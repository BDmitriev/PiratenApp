using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Models
{
    public class Schiff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int SchiffId { get; set; }

        [BindNever]
        public ICollection<PiratSchiff> PiratSchiff { get; set; } = new HashSet<PiratSchiff>();


        [Required(ErrorMessage = "Bitte den Schiffsnamen angeben")]
        public string SchiffName{ get; set; }
    }
}
