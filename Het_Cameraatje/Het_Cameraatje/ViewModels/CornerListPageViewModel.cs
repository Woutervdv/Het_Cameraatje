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
        private ICameraatjeDbContext dbContext;
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
                    var p = new NavigationParameters();
                    p.Add("Location", selectedLocation);
                    p.Add("Environment", environment);
                    p.Add("User", user);
                    NavigationService.NavigateAsync("PartnerListPage", p);
                    selectedLocation = null;
                }
            }
        }

        private string environment;
        private User user;
        private NavigationParameters parameters;

        public CornerListPageViewModel(INavigationService navigationService, ICameraatjeDbContext dbContext, ICameraatjeRepository repo):base(navigationService)
        {
            this.dbContext = dbContext;
            this.repo = repo;
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            this.parameters = parameters;
            if (parameters.ContainsKey("Environment"))
            {
                environment = (string)parameters["Environment"];
            }
            if (parameters.ContainsKey("User"))
            {
                user = (User)parameters["User"];
            }
            repo = new CameraatjeRepository(dbContext, user);
            Locations = await repo.GetLocations();
        }
    }
}
