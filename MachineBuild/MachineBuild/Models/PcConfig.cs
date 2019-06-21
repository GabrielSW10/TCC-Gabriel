using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MachineBuild.Models
{
    public class PcConfig
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        [ForeignKey("Processador")]
        [Required]
        public virtual int ProcessadorID { get; set; }
        public virtual Processador Processador { get; set; }

        [ForeignKey("PlacaMae")]
        [Required]
        public virtual int PlacaMaeID { get; set; }
        public virtual PlacaMae PlacaMae { get; set; }

        [ForeignKey("PlacaVideo")]
        public virtual int PlacaVideoID { get; set; }
        public virtual PlacaVideo PlacaVideo { get; set; }

        [ForeignKey("Memoria")]
        [Required]
        public virtual int MemoriaID { get; set; }
        public virtual Memoria Memoria { get; set; }

        [ForeignKey("SSD")]
        public virtual int SSDID { get; set; }
        public virtual SSD SSD { get; set; }

        [ForeignKey("DiscoRigido")]
        [Required]
        public virtual int DiscoRigidoID { get; set; }
        public virtual DiscoRigido DiscoRigido { get; set; }

        [ForeignKey("Gabinete")]
        [Required]
        public virtual int GabineteID { get; set; }
        public virtual Gabinete Gabinete { get; set; }

        [ForeignKey("CpuCooler")]
        public virtual int CpuCoolerID { get; set; }
        public virtual CpuCooler CpuCooler { get; set; }

        [ForeignKey("SistemaOperacional")]
        public virtual int SistemaOperacionalID { get; set; }
        public virtual SistemaOperacional SistemaOperacional { get; set; }

        [ForeignKey("Fonte")]
        [Required]
        public virtual int FonteID { get; set; }
        public virtual Fonte Fonte { get; set; }

        public string tipo { get; set; }

        public double precoMedioFinal { get; set; }
    }
}