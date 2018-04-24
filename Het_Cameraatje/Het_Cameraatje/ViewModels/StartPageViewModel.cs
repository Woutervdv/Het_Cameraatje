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

        public ICommand LoginNavigateCommand { get; set; } 

        public StartPageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Start";

            int state = 0;
            /* 
             * int state
             *  case 0: Default
             *  case 1: Home 
             *      kid login
             *  case 2: School 
             *      teacher login
             */

            this.navigationService = navigationService;

            LoginNavigateCommand = new DelegateCommand(() =>
            {
                //if (sender == btnHome) state = 1; 
                //else if (sender == btnSchool) state = 1;
                var p = new NavigationParameters();
                p.Add("state", state);
                navigationService.NavigateAsync("LoginPage", p);
            }); 
        }
	}
}
