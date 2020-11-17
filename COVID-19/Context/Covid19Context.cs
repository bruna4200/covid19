using covid19.Context;
using covid19.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Context
{
    public class Covid19Context : DbContext
    {
        public Covid19Context()
        {

        }

        public Covid19Context(DbContextOptions<Covid19Context> options) : base(options)
        {
        }

        public virtual DbSet<Paciente> PACIENTES { get; set; }
        public virtual DbSet<Login> LOGINS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                        .AddJsonFile("appsettings.json")
                                        .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Covid19DataBase"));
            }
        }
    }
}
