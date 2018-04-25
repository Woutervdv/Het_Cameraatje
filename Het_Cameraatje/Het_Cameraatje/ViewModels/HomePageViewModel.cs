using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Het_Cameraatje.ViewModels
{
	public class HomePageViewModel : ViewModelBase
    {
        private string enviroment;


        public HomePageViewModel(INavigationService navigationService)
            :base(navigationService)
        {

        }



        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Environment"))
            {
                enviroment = (string)parameters["Environment"];
            }
        }
    }
}
