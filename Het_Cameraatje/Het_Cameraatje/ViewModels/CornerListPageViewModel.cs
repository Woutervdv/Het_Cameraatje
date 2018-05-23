using Het_Cameraatje.Contracts;
using Het_Cameraatje.Data;
using Het_Cameraatje.Models;
using Het_Cameraatje.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Het_Cameraatje.ViewModels
{
	public class CornerListPageViewModel : ViewModelBase
    {
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
                if (SetProperty(ref selectedLocation, value) && selectedLocation != null)
                {
                    var p = new NavigationParameters
                    {
                        { "Location", selectedLocation },
                        { "Environment", environment },
                        { "User", user },
                        { "PictureUrl", pictureUrl }
                    };
                    NavigationService.NavigateAsync("PartnerListPage", p);
                    selectedLocation = null;
                }
            }
        }

        private string environment;
        private User user;
        private string pictureUrl;

        public CornerListPageViewModel(INavigationService navigationService,  ICameraatjeRepository repo, ICameraatjeDbContext dbContext):base(navigationService)
        {
            
            this.repo = repo;
            this.dbContext = dbContext;
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Environment"))
            {
                environment = (string)parameters["Environment"];
            }
            if (parameters.ContainsKey("User"))
            {
                user = (User)parameters["User"];
            }
            if (parameters.ContainsKey("PictureUrl"))
            {
                pictureUrl = (string)parameters["PictureUrl"];
            }
            repo = new CameraatjeRepository(dbContext);
            Locations = await repo.GetLocations();
        }
    }
}
