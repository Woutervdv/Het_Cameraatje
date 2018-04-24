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

            int state;
            /* 
             * int state
             *  case 0: Home 
             *      teacher login
             *  case 1: School 
             *      kid login
             */

            this.navigationService = navigationService;

            LoginNavigateCommand = new DelegateCommand(() =>
            {
                state = 0;
                string test = LoginNavigateCommand.ToString();
                navigationService.NavigateAsync("LoginPage");
            }); 
        }
	}
}
