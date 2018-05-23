using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Het_Cameraatje.Models;
/*
 * this class is created by Wouter Vandevorst on 4/04/2018
 */
namespace Het_Cameraatje.Contracts
{
    public interface ICameraatjeRepository
    {
        
        Task<List<Picture>> GetPicturesAsync();
        Task<List<Kid>> GetKids();
        Task<List<Location>> GetLocations();
        Task<List<Kid>> GetPartners();
    }
}
