using MultiPurpose.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MultiPurpose.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("DataModel")
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Places> Places { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<FontFamily> FontFamily { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}