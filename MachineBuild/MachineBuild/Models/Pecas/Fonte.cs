using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachineBuild.Models
{
    public class Fonte
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public double PrecoMedio { get; set; }
        public double Watts { get; set; }
        public string Link { get; set; }

    }
}