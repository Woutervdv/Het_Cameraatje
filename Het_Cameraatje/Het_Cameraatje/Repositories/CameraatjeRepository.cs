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
        private ICameraatjeDbContext dbContext;
        private FirebaseAuth firebaseAuth;
        private Picture currentimage;
        public async Task<List<Picture>> GetPicturesAsync()
        {
            //get current user
            var user = firebaseAuth.User.Email;
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
    }
}
