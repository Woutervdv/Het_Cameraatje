using Het_Cameraatje.Contracts;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Het_Cameraatje.ViewModels
{

	public class StartPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public ICommand HomeCommand { get; set; } 
        public ICommand SchoolCommand { get; set; } 

        public StartPageViewModel(INavigationService navigationService, IFileHelper fileHelper , ICameraatjeRepository cameraatjeRepository ): base(navigationService)
        {
            
            Title = "Start";
             
            this.navigationService = navigationService;

            HomeCommand = new DelegateCommand(() =>
            { 
                var p = new NavigationParameters();
                p.Add("Environment", "Home");
                NavigationService.NavigateAsync("LoginPage", p);
            });

            SchoolCommand = new DelegateCommand(() =>
            { 
                var p = new NavigationParameters();
                p.Add("Environment", "School");
                NavigationService.NavigateAsync("LoginPage", p);
            }); 
        }
	}
}
