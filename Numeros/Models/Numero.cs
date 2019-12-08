using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Numeros.Models
{
    public class Numero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public int Valor { get; set; }
        public string Ordinal { get; set; }
        public string Cardinal { get; set; }
        public string Romanos { get; set; }

    }
}
