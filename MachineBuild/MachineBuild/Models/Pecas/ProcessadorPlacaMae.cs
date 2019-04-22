using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MachineBuild.Models.Pecas
{
    public class ProcessadorPlacaMae
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Processador")]
        [Required]
        public virtual int ProcessadorID { get; set; }
        //public virtual String ProcessadorNome { get; set; }
        public virtual Processador Processador { get; set; }

        [ForeignKey("PlacaMae")]
        [Required]
        public virtual int PlacaMaeID { get; set; }
        //public virtual String PlacaMaeNome { get; set; }
        public virtual PlacaMae PlacaMae { get; set; }
    }
}