using Firebase.Auth;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Het_Cameraatje.Repositories;
using Het_Cameraatje.Contracts;

/*
 * created by Wouter on 25/04/2018
 */
namespace Het_Cameraatje.ViewModels
{

	public class HomePageViewModel : ViewModelBase
    {
        private IPageDialogService dialogService;
        FirebaseAuthLink auth;
        private string enviroment;

        


        public ICommand LogOutCommand { get; private set; }
        public ICommand AlbumCommand { get; private set; }
        public ICommand CameraCommand { get; private set; }
        public ICommand ReturnCommand { get; private set; }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {

            LogOutCommand = new DelegateCommand(() =>
            {
                NavigationService.NavigateAsync("StartPage");
            });

            AlbumCommand = new DelegateCommand(() =>
            {
                dialogService.DisplayAlertAsync("Album", "word getoond", "ok");
            });

            CameraCommand = new DelegateCommand(() =>
            {
                dialogService.DisplayAlertAsync("Camera", "word getoond", "ok");
            });

            ReturnCommand = new DelegateCommand(() =>
            {
                NavigationService.GoBackAsync();
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
