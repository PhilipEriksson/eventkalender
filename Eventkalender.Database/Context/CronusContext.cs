﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventkalender.Database
{
    public class CronusContext : DbContext
    {
        public CronusContext(string xmlPath) : base(DatabaseClient.GetSqlServerConnectionString(xmlPath))
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Employee>().ToTable("CRONUS Sverige AB$Employee");
        }

        public DbSet<Employee> Employee { get; set; }
    }
}