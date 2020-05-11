using EmotionalIntel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Data
{
    public class EmotionalDB : DbContext
    {
        public EmotionalDB(DbContextOptions<EmotionalDB> options) : base(options) { }

        // adicionar as 'tabelas' à BD
        public DbSet<Perguntas> Perguntas { get; set; }
        public DbSet<Tecnicas> Tecnicas { get; set; }
        public DbSet<Testes> Testes { get; set; }
        public DbSet<TestesRealizados> Testes_Realizados { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }   
        public DbSet<EmotionalIntel.Models.Respostas> Respostas { get; set; }

    }
}
