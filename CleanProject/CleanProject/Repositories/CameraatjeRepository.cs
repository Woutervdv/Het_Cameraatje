using CleanProject.Contracts;
using CleanProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Repositories
{
    public class CameraatjeRepository : ICameraatjeRepository
    {
        private ICameraatjeDbContext dbContext;

        public CameraatjeRepository(ICameraatjeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            return await dbContext.Class.ToListAsync();
        }

        public async Task<int> SaveClass(Class klas)
        {
            if (klas.ClassID == 0)
            {
                await dbContext.Class.AddAsync(klas);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveKid(Kid kid)
        {
            if (kid.KidID == 0)
            {
                await dbContext.Kid.AddAsync(kid);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveLocation(Location location)
        {
            if (location.LocationID == 0)
            {
                await dbContext.Location.AddAsync(location);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SavePicture(Picture picture)
        {
            if (picture.PictureID == 0)
            {
                await dbContext.Picture.AddAsync(picture);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SavePictures(Pictures pictures)
        {
            if (pictures.PictureCount == 0)
            {
                await dbContext.Pictures.AddAsync(pictures);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveTeacher(Teacher teacher)
        {
            if (teacher.TeacherID == 0)
            {
                await dbContext.Teacher.AddAsync(teacher);
            }

            return await dbContext.SaveChangesAsync();
        }
    }
}
