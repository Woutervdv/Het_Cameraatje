using Het_Cameraatje.Contracts;
using Het_Cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Het_Cameraatje.Data
{
    public class CameraatjeDbContext: DbContext, ICameraatjeDbContext
    {
        public DbSet<Class> Class { get; set; }
        public DbSet<Kid> Kid { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        private string connectionString;

        public CameraatjeDbContext(IFileHelper fileHelper)
        {
            string databasePath = fileHelper.GetLocalFilePath("TodoSQLite.db3");
            connectionString = string.Format("Filename={0}", databasePath);

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
