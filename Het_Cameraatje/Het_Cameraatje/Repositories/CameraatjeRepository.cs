using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Het_Cameraatje.Contracts;
using Het_Cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using Firebase.Auth;
/*
 * this class is created by Wouter Vandevorst on 4/04/2018
 */
namespace Het_Cameraatje.Repositories
{
    
    public class CameraatjeRepository : ICameraatjeRepository
    {
        private List<Picture> photos = new List<Picture>();
        private List<Kid> child = new List<Kid>();
        private ICameraatjeDbContext dbContext;
        private User firebaseAuth;

        public CameraatjeRepository( ICameraatjeDbContext dbContext, User firebaseAuth)
        {
            this.dbContext = dbContext;
            this.firebaseAuth = firebaseAuth;
        }

        

        public async Task<List<Picture>> GetPicturesAsync()
        {
            //get current user
            var user = firebaseAuth.Auth.User.Email;
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

        public async Task<List<Kid>> GetKids()
        {
            var kids = from children in dbContext.Kid
                       select children;

            await Task.Run<List<Kid>>(() =>
            {
                foreach (var kid in kids)
                {
                    child.Add(kid);
                }
                return child;
            });

            //als er iets fout loopt
            return null;
        }

    }
}
