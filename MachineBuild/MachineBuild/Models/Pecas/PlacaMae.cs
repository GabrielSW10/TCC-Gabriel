using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachineBuild.Models
{
    public class PlacaMae
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Socket { get; set; }
        public string Barramento { get; set; }
        public string TipoRam { get; set; }
        public double FrequenciaMaxima { get; set; }
        public string Marca { get; set; }
        public double PrecoMedio { get; set; }
        public double ConsumoWatts { get; set; }
        public string Link { get; set; }
    }
}
