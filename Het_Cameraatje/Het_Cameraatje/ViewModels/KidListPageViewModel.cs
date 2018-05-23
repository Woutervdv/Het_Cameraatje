using Het_Cameraatje.Contracts;
using Het_Cameraatje.Models;
using Het_Cameraatje.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Het_Cameraatje.ViewModels
{
	public class KidListPageViewModel : ViewModelBase
	{
        private ICameraatjeDbContext dbContext;
        private ICameraatjeRepository repo;
        
        private IList<Kid> kids;
        public IList<Kid> Kids
        {
            set { SetProperty(ref kids, value); }
            get { return kids; }
        }

        private Kid selectedKid;
        public Kid SelectedKid
        {
            get { return selectedKid; }
            set
            {
                if (SetProperty(ref selectedKid, value) && selectedKid != null)
                {
                    var p = new NavigationParameters();
                    p.Add("Kid", selectedKid);
                    p.Add("Environment", environment);
                    p.Add("User", user);
                    p.Add("PictureUrl", pictureUrl);
                    NavigationService.NavigateAsync("CornerListPage", p);
                    selectedKid = null;
                }
            }
        }

        private string environment;
        private string pictureUrl;
        public User user { get; set; }

        public KidListPageViewModel(INavigationService navigationService, ICameraatjeDbContext dbContext, ICameraatjeRepository repo)
          :  base (navigationService)
        {
            this.dbContext = dbContext;
            this.repo = repo;
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

            repo = new CameraatjeRepository(dbContext, user);
            Kids = await repo.GetKids();
        }
    }
}
