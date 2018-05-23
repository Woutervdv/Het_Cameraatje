using Het_Cameraatje.Contracts;
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
	public class PartnerListPageViewModel : ViewModelBase
    {
        private ICameraatjeDbContext dbContext;
        private ICameraatjeRepository repo;

        private IList<Kid> partners;
        public IList<Kid> Partners
        {
            get { return partners; }
            set { SetProperty(ref partners, value); }
        }

        private Kid selectedPartner;
        public Kid SelectedPartner
        {
            get { return selectedPartner; }
            set
            {
                if (SetProperty(ref selectedPartner, value) && selectedPartner != null)
                {
                    /* Save photo in db */ 
                    /* Navigate to home */
                }
            }
        }

        public string environment;
        public User user;
        public Kid kid;
        public string pictureUrl;

        public PartnerListPageViewModel(INavigationService navigationService, ICameraatjeDbContext dbContext, ICameraatjeRepository repo):base(navigationService)
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
            if (parameters.ContainsKey("Kid"))
            {
                kid = (Kid)parameters["Kid"];
            }
            if (parameters.ContainsKey("PictureUrl"))
            {
                pictureUrl = (string)parameters["PictureUrl"];
            }
            repo = new CameraatjeRepository(dbContext, user);
            Partners = await repo.GetPartners();
        }
    }
}
