using CleanProject.Classes;
using CleanProject.Contracts;
using CleanProject.Models;
using CleanProject.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanProject.ViewModels
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
                    var p = new NavigationParameters
                    {
                        { "Kid", selectedKid },
                        { "Environment", environment },
                        { "User", user },
                        { "PictureUrl", pictureUrl }
                    };
                    NavigationService.NavigateAsync("CornerListPage", p);
                    selectedKid = null;
                }
            }
        }

        private string environment;
        private string pictureUrl;
        public User user { get; set; }

        public KidListPageViewModel(INavigationService navigationService, ICameraatjeRepository repo, ICameraatjeDbContext dbContext)
          : base(navigationService)
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

            
            Kids = await repo.GetKids();
        }
    }
}