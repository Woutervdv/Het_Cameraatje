using CleanProject.Contracts;
using CleanProject.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanProject.ViewModels
{
	public class DetailsPhotoPageViewModel : ViewModelBase
	{
        private ICameraatjeDbContext dbContext;
        private ICameraatjeRepository repo;
        private Picture pic;
        public Picture Pic
        {
            set { SetProperty(ref pic, value); }
            get { return pic; }
        }

        public DetailsPhotoPageViewModel(INavigationService navigationService, ICameraatjeRepository repo, ICameraatjeDbContext dbContext)
            :base(navigationService)
        {
            this.dbContext = dbContext;
            this.repo = repo;

        }



        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Picture"))
            {
                Pic = (Picture)parameters["Picture"];
            }

           
        }









    }


   
}
