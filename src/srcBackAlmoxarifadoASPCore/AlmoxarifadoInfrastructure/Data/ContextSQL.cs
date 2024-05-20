using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data
{
    public  class ContextSQL : DbContext 
    {

        public ContextSQL(DbContextOptions<ContextSQL> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da chave primária para a entidade Grupo
            modelBuilder.Entity<Grupo>().HasKey(g => g.ID_GRU);
            modelBuilder.Entity<NotaFiscal>().HasKey(e => e.ID_NOTA);
            modelBuilder.Entity<ItensNota>().HasKey(e => new {e.ITEM_NUM, e.ID_PRO,e.ID_NOTA, e.ID_SEC});
            modelBuilder.Entity<Requisicao>().HasKey(e => e.ID_REQ);
            modelBuilder.Entity<ItensRequerimento>().HasKey(e => new {e.NUM_ITEM, e.ID_PRO, e.ID_REQ, e.ID_SEC});
        }

        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<NotaFiscal> Nota_Fiscal { get; set; }
        public DbSet<ItensNota> Itens_Nota { get; set; }
        public DbSet<Requisicao> Requisicao { get; set;}
        public DbSet<ItensRequerimento> Itens_Req { get; set; }
    }
}
