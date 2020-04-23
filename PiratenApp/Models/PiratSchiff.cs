using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Models
{
    public class PiratSchiff
    {
        [BindNever]
        [Key]
        public int PSID { get; set; }


        public int PiratId { get; set; }
        public int SchiffId { get; set; }


        public Pirat Pirat { get; set; }
        public Schiff Schiff { get; set; }
    }
}
