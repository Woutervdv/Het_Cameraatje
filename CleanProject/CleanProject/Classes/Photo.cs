using System.Collections.Generic; 

namespace CleanProject.Classes
{
    public class Photo
    {
        public string Url { get; set; }
        public int LocationId { get; set; }
        public IList<int> KidIdList { get; }
        public int AuthorId { get; set; }

        public Photo()
        {
            
        }

        public void TaggKid(int KidId) => KidIdList.Add(KidId);
    }
}
