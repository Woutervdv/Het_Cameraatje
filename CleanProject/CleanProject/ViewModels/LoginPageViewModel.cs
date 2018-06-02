using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms; 
using Firebase.Auth;
using Prism.Services;  

namespace CleanProject.ViewModels
{
	public class LoginPageViewModel : ViewModelBase 
	{
        private IPageDialogService dialogService;

        private string env;

        private ImageSource environmentSource;
        public ImageSource EnvironmentSource
        {
            get { return environmentSource; }
            set { SetProperty(ref environmentSource, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string pass;
        public string Pass
        {
            get { return pass; }
            set { SetProperty(ref pass, value); }
        }

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            this.dialogService = dialogService;

            env = string.Empty;

            LoginCommand = new DelegateCommand(firebaseLogin);
        }

        private async void firebaseLogin()
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyC0s-FL-aZghQFNfigs5pQG8TvtiiJHG5c"));
                var a = await auth.SignInWithEmailAndPasswordAsync(Email.Trim(), Pass.Trim());

                await dialogService.DisplayAlertAsync("aanmelden succesvol", env, "OK"); 

                await NavigationService.NavigateAsync("HomePage", new NavigationParameters
                {
                    {"User", new Classes.User(a, env) }
                });
            }
            catch (Exception)
            {
                await dialogService.DisplayAlertAsync("Aanmeldfout", "Ongeldige logingegevens", "OK");
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("env"))
            {
                env = (string)parameters["env"];
                EnvironmentSource = ImageSource.FromResource(string.Format("CleanProject.Images.{0}_icon.png", (string)parameters["env"]));
            }
        } 
    }
}
