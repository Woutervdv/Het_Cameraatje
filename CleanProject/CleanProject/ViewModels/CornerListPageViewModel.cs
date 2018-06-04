using CleanProject.Classes;
using CleanProject.Contracts;
using CleanProject.Models; 
using Prism.Navigation; 
using System.Collections.Generic; 

namespace CleanProject.ViewModels
{
    public class CornerListPageViewModel : ViewModelBase
    {
        private Photo photo;

        ICameraatjeDbContext dbContext;
        private ICameraatjeRepository repo;
        private Pictures pictures;
        private Picture picture;

        private IList<Location> locations;
        public IList<Location> Locations
        {
            get { return locations; }
            set { SetProperty(ref locations, value); }
        }

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                
                
                if (SetProperty(ref selectedLocation, value) && selectedLocation != null)
                {
                    photo.Corner = selectedLocation;

                    selectedLocation = null;
                    CreatePictureObjects();


                    NavigationService.NavigateAsync("HomePage", new NavigationParameters
                    {
                        {"User" , photo.User }
                    });
                }
            }
        }
        public async void CreatePictureObjects()
        {
            picture = new Picture
            {
                PictureUrl = photo.Url,
                AuthorID = photo.Partner.KidID,
                LocationID = photo.Corner.LocationID
            };
            await repo.SavePicture(picture);

            pictures = new Pictures
            {
                PictureID = picture.PictureID,
                KidID = photo.Partner.KidID
            };

            await repo.SavePictures(pictures);
        }
        public CornerListPageViewModel(INavigationService navigationService, ICameraatjeRepository repo, ICameraatjeDbContext dbContext) : base(navigationService)
        { 
            this.repo = repo;
            this.dbContext = dbContext;
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Photo"))
            {
                photo = (Photo)parameters["Photo"];
            }
            
            Locations = await repo.GetLocations();
        }
    }
}