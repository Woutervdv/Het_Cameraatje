using CleanProject.Models;
using System.Collections.Generic; 

namespace CleanProject.Classes
{
    public class Photo
    {
        public string Url { get; set; }
        public Location Corner { get; set; }
        public Kid Partner { get; set; }
        public User User { get; }

        public Photo(User user)
        {
            User = user;
        }  
    }
}
