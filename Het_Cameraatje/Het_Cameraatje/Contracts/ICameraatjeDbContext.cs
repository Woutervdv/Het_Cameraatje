using Het_Cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Het_Cameraatje.Contracts
{
    public interface ICameraatjeDbContext
    {
        DbSet<Class> Class { get; set; }
        DbSet<Kid> Kid { get; set; }
        DbSet<Location> Location { get; set; }
        DbSet<Picture> Picture { get; set; }
        DbSet<Pictures> Pictures { get; set; }
        DbSet<Teacher> Teacher { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
