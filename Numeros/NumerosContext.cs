using Microsoft.EntityFrameworkCore;
using Numeros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;

namespace Numeros
{
    public class NumerosContext : DbContext
    {
        public NumerosContext(DbContextOptions options) : base(options) { }
        public DbSet<Numero> Numeros { get; set; }

        private Dictionary<int, Guid> identificadores = new Dictionary<int, Guid>
        {
            { 1,new Guid("49296A4F-208D-4F19-9C6F-0E298094CAF0") },
            { 2,new Guid("A80E0C02-7D44-4F04-A110-CA2E9424E97C") },
            { 3,new Guid("CE560E95-6239-4206-A618-895A7E460BAC") },
            { 4,new Guid("EE9573C0-BBA1-4299-A02C-AD021D7493D2") },
            { 5,new Guid("3E199BA4-C386-41C9-A92C-2E7CE46CC760") },
            { 6,new Guid("2508E33C-04EF-4FDD-BE35-8DF57C03F622") },
            { 7,new Guid("94717C4E-DCA4-4262-94B6-5E57706E83FB") }
        };

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var lstNumeros = new List<Numero>();
            for (int i = 1; i <= 5; i++)
            {
                lstNumeros.Add(new Numero { Id =identificadores[i], Valor = i, Cardinal = i.ToWords(), Ordinal = i.ToOrdinalWords(), Romanos = i.ToRoman() });
            }

            modelBuilder.Entity<Numero>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Numero>().HasData(lstNumeros);
        }
    }
}
