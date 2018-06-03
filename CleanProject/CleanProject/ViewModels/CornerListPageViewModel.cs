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
                photo.Corner = selectedLocation;

                selectedLocation = null;

                if (SetProperty(ref selectedLocation, value) && selectedLocation != null)
                { 
                    NavigationService.NavigateAsync("PartnerListPage", new NavigationParameters() {
                        {"Photo", photo }
                    });
                }
            }
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