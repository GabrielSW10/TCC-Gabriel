using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MachineBuild.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<PcConfig> Configs { get; set; }
        public DbSet<CpuCooler> CpuCoolers { get; set; }
        public DbSet<DiscoRigido> DiscoRigidoes { get; set; }
        public DbSet<Gabinete> Gabinetes { get; set; }
        public DbSet<Memoria> Memorias { get; set; }
        public DbSet<PlacaMae> PlacaMaes { get; set; }
        public DbSet<PlacaVideo> PlacaVideos { get; set; }
        public DbSet<Processador> Processadors { get; set; }
        public DbSet<SistemaOperacional> SistemaOperacionals { get; set; }
        public DbSet<SSD> SSDs { get; set; }
        public DbSet<Fonte> Fontes { get; set; }

        public System.Data.Entity.DbSet<MachineBuild.Models.Pecas.ProcessadorPlacaMae> ProcessadorPlacaMaes { get; set; }
    }
}