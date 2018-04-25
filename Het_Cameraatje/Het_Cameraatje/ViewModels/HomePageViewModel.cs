using Firebase.Auth;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Het_Cameraatje.ViewModels
{

	public class HomePageViewModel : ViewModelBase
    {
        FirebaseAuthLink auth;
        private string enviroment;

        public ICommand LogOutCommand { get; private set; }
        public ICommand AlbumCommand { get; private set; }
        public ICommand CameraCommand { get; private set; }

        public HomePageViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            LogOutCommand = new DelegateCommand(() =>
            {
                NavigationService.NavigateAsync("StartPage");
            });


        }




       

        


        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Environment"))
            {
                enviroment = (string)parameters["Environment"];
            }
            if (parameters.ContainsKey("Auth"))
            {
                auth = (FirebaseAuthLink)parameters["Auth"];
            }
        }
    }
}
