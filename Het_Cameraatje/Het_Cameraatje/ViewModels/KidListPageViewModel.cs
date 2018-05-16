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
        private ICameraatjeDbContext dbcontext;
        private ICameraatjeRepository repo;
        
        private IList<Kid> kids;

        //nav params
        private string environment;
        public User user { get; set; }
        public IList<Kid> Kids
        {
            set { SetProperty(ref kids, value); }
            get { return kids; }
        }
        public KidListPageViewModel(INavigationService navigationService)
          :  base (navigationService)
        {

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
            repo = new CameraatjeRepository(dbcontext, user);
            Kids = await repo.GetKids();
        }
    }
}
