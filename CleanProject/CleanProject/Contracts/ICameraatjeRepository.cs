using CleanProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Contracts
{
    public interface ICameraatjeRepository
    {

        //to save data
        Task<int> SaveClass(Class klas);
        Task<int> SaveKid(Kid kid);
        Task<int> SaveLocation(Location location);
        Task<int> SavePicture(Picture picture);
        Task<int> SavePictures(Pictures pictures);
        Task<int> SaveTeacher(Teacher teacher);
        Task<List<Class>> GetClassesAsync();
    }
}
