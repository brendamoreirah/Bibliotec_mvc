using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace Bibliotec.Contexts
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base
        (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //colocar as informacoes do  banco

            // as configuracaoes existem?
            if (!optionsBuilder.IsConfigured)
            {
                //string de conexao do banco de dados
                //Initial Catalog => nome do banco0 de dados
                //Data Source => nome do servidor do banco de dados
                //User Id e Password => Informacoes de acesso ao servidor do banco de dados
                //Alunos
                //User Id  =sa;;
                //PasswordHasher = 123;
                //Integrated Security=true;
                optionsBuilder.UseSqlServer(@"Data Source=NOTE31-S28\SQLEXPRESS;
              Initial Catalog = Bibliotec_mvc;
               User Id=sa; 
              Password=abc123;
               Integrated Security=true;
                TrustServerCertificate = true");

            }



        }

        public DbSet<Categoria> Categoria { get; set; }


        public DbSet<Curso> Curso { get; set; }

        public DbSet<Livro> Livro { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<LivroCategoria> LivroCategoria { get; set; }

        public DbSet<LivroReserva> LivroReserva { get; set; }





    }
}