﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Repository
{
    public class WebAppContext : DbContext
    {
        //public WebAppContext (DbContextOptions<WebAppContext> options)
        //    : base(options)
        //{
        //}

        private const string connectionString = "Server=localhost;Port=3306;Database=WebAppDB;User=root;Password=iddo";

        /**
        public WebAppContext()
        {
            Database.EnsureCreated();
        }
        **/

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString));
        }

        /**
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(e => e.Username);
        }
        **/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure primary keys
            modelBuilder.Entity<User>().HasKey(user => user.Username);


            modelBuilder.Entity<Contact>().HasKey(contact => contact.ContactUsername);

            modelBuilder.Entity<Message>().HasKey(message => message.Id);
        }


        public DbSet<User> User { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Message> Message { get; set; }
    }
}
