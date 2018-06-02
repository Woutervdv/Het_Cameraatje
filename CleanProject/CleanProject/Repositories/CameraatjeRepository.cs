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

        private List<Picture> photos = new List<Picture>();
        private List<Kid> child = new List<Kid>();

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

        public async Task<List<Location>> GetLocations()
        {
            List<Location> places = new List<Location>();

            var locationList = from locations in dbContext.Location
                               select locations;
            await Task.Run<List<Location>>(() =>
            {
                foreach (var location in locationList)
                {
                    places.Add(location);
                }
                return places;
            });
            return null;
        }

        public Task<List<Kid>> GetPartners()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Picture>> GetPicturesAsync(User fbuser)
        {
            //get current user
            var user = "test@student.be";
            //get Kid that is linked to this account
            var ID = from kid in dbContext.Kid
                     where kid.Email == user
                     select kid.KidID;


            //ga tabel met pictures af en seleteer degene met zelfde KidId al gebruiker
            var photoList = from photo in dbContext.Pictures
                            where photo.KidID == Convert.ToInt32(ID)
                            select photo.PictureID;

            //ga van elke picture met opgehaald picture id hetr object opghalen en steek in een lijst
            foreach (var photo in photoList)
            {
                var image = from images in dbContext.Picture
                            where images.PictureID == photo
                            select images;


                photos.Add((Picture)image);

            }


            await Task.Run<List<Picture>>(() =>
            {
                //maak lijst van geselecteerde foto's en return
                return photos;
            }


             );
            //als er iets fout loopt
            return null;
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
