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
        private User user;
        private string environment;

        private string email; 
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public ICommand LoginCommand { get; private set; } 
        public ICommand BackCommand { get; private set; }

        private string imageSource;
        public string ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService )
            : base(navigationService)
        {
            Title = "Aanmelden";
            Email = string.Empty;

            this.dialogService = dialogService;
            LoginCommand = new DelegateCommand(firebaseLogin);

            BackCommand = new DelegateCommand(() =>
            {
                NavigationService.GoBackAsync();
            });
        }  

        private async void firebaseLogin()
        {
            if (AccountType(email) != -1)
            {
                try
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyC0s-FL-aZghQFNfigs5pQG8TvtiiJHG5c"));
                    var a = await auth.SignInWithEmailAndPasswordAsync(Email.Trim(), Password.Trim());
                    
                    await dialogService.DisplayAlertAsync("aanmelden succesvol", environment, "OK");
                    if (environment == "School")
                        user = new User(a, false);
                    else
                        user = new User(a, true);
                    
                    var p = new NavigationParameters();
                    p.Add("Environment", environment);
                    p.Add("User", user);
                    await NavigationService.NavigateAsync("HomePage", p);
                }
                catch (Exception)
                {
                    await dialogService.DisplayAlertAsync("Aanmeldfout", "Ongeldige logingegevens", "OK");
                }
            }
            else
            {
                await dialogService.DisplayAlertAsync("Aanmeldfout", "Ongeldig Emailadres", "OK");
            }
        }

        private int AccountType(string emailToCheck)
        {
            if (emailToCheck == "")
            {
                return -1;
            }
            char[] deviders = { '@', '.' };
            string[] splitted = emailToCheck.Split(deviders);
            if (!emailToCheck.Contains("@") && !emailToCheck.Contains("."))
            {
                return -1;
            }
            switch (splitted[splitted.Length-2])
            {
                case "student":
                    return 1;
                case "teacher":
                    return 2;
                default:
                    return 0;
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Environment"))
            {
                environment = (string)parameters["Environment"];

                if (environment == "Home")
                {
                    ImageSource = "baseline_home_black_48.png";
                }
                else ImageSource = "baseline_school_black_48.png";
            } 
        } 
    }
}
