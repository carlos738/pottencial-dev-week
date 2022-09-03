using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C_pottencial_dev_week.src.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C_pottencial_dev_week.src.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){

        }
        public DbSet<Person> Persons{get;set;}
        public DbSet<Contracts> Contratos{get;set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Person>(x =>
            {
               x.HasKey(x => x.Id);
            x.HasMany(x => x.contratos)
            .WithOne()
            .HasForeignKey(x => x.PessoaId);
            });
            builder.Entity<Contracts>(x =>{
                x.HasKey(x => x.Id);
            });
            

            
        }
   }
}