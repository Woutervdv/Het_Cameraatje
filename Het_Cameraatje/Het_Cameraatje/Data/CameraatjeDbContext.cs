using System;
using System.Collections.Generic;
using System.Text;
using Het_Cameraatje.Models;
using Het_Cameraatje.Contracts;
using Microsoft.EntityFrameworkCore;

/*
 * db context
 * Author: Wouter Vandevorst
 */

namespace Het_Cameraatje.Data
{
   
    public class CameraatjeDbContext : DbContext , ICameraatjeDbContext
    {
        //tables
        public DbSet<Class> Class { get; set; }
        public DbSet<Kid> Kid { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Pictures> pictures { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        private string connectionString;

        public CameraatjeDbContext( string connectionString)
        {
            this.connectionString = connectionString;

            Database.EnsureCreated(); 
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
