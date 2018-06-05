using CleanProject.Contracts;
using CleanProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CleanProject.Classes;

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

        public async Task<List<Kid>> GetKids()
        {
            return await dbContext.Kid.ToListAsync();
        }

        public string GetLocationByPicture(Picture picture)
        {
            var location = from loc in dbContext.Location
                           where loc.LocationID == picture.LocationID
                           select loc.LocationName;

            return location.FirstOrDefault();
        }

        public async Task<List<Location>> GetLocations()
        {
            return await dbContext.Location.ToListAsync();
        }

       

        public async Task<List<Picture>> GetPicturesAsync(User fbuser)
        {
            
            var user = fbuser.Auth.User.Email;
            

            var id = from kid in dbContext.Kid
                     where kid.Email == user
                     select kid.KidID;

            int tip = id.FirstOrDefault();
            var images = from image in dbContext.Picture
                         where image.AuthorID == tip
                         select image;

            return await  images.ToListAsync();

        }







        //saving methods
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
