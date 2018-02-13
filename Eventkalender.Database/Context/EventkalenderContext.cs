﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventkalender.Database
{
    public class EventkalenderContext : DbContext
    {
        public EventkalenderContext() : base(DatabaseClient.GetSqlServerConnectionString("eventkalender-db.xml"))
        {
            Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Nation> Nation { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Person> Person { get; set; }
    }
}
