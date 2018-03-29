using Firebase.Auth;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
/*
* the purpose of this page is to sign in an teacher or parent
* Author: Vandevorst Wouter
*/
namespace Het_Cameraatje.ViewModels
{
	public class LoginPageViewModel : ViewModelBase 
	{
        IPageDialogService dialogService;
        
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService )
            : base(navigationService)
        {
            Title = "Aanmelden";

            this.dialogService = dialogService;
            LoginCommand = new DelegateCommand(Login);

        }

        public ICommand LoginCommand { get; private set; }
        private async void Login()
        {
          
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyC0s-FL-aZghQFNfigs5pQG8TvtiiJHG5c"));
                var a = await auth.SignInWithEmailAndPasswordAsync(Email , Password);
                await dialogService.DisplayAlertAsync("aanmelden succesvol","goed bezig", "OK");
            }catch(Exception ex)
            {
                await dialogService.DisplayAlertAsync("exeption has been thrown", ex.Message, "OK");
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }



    }
}
