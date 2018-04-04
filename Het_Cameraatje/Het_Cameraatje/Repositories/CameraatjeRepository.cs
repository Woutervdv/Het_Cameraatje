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
        private ICameraatjeDbContext dbContext;
        private FirebaseAuth firebaseAuth;
        public async Task<List<Pictures>> GetPicturesAsync()
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
                            select photo;


            //maak lijst van geselecteerde foto's en return
            return await photoList.ToListAsync();
        }
    }
}
