using System;
using System.Collections.Generic;
using System.Text;
using Het_Cameraatje.Models;
using Microsoft.EntityFrameworkCore;


namespace Het_Cameraatje.Data
{
   
    public class CameraatjeDbContext : DbContext 
    {

        public DbSet<Class> Class { get; set; }

        private string connectionString;

        public CameraatjeDbContext( string connectionString)
        {
            this.connectionString = connectionString;

            
        }
    }
}
