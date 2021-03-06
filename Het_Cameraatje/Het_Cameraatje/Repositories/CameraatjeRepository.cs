﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Het_Cameraatje.Contracts;
using Het_Cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using Firebase.Auth;
using Het_Cameraatje.Data;
/*
* this class is created by Wouter Vandevorst on 4/04/2018
*/
namespace Het_Cameraatje.Repositories
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

       
        
        public async Task<List<Picture>> GetPicturesAsync()
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

       
    }
}
