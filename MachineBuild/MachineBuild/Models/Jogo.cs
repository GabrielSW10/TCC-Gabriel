using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MachineBuild.Models
{
    public class Jogo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Desenvolvedora { get; set; }
        public byte[] ImageByte { get; set; }
        public string PlacaVideoNota { get; set; }
        public string ProcessadorNota { get; set; }

        [ForeignKey("PcConfig")]
        public virtual int? PcConfigID { get; set; }
        public virtual PcConfig PcConfig { get; set; }

        [ForeignKey("RecomendadaConfig")]
        public virtual int? RecomendadaConfigID { get; set; }
        public virtual PcConfig RecomendadaConfig { get; set; }

        public string configRecomendada { get; set; }
    }
}