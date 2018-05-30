using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace CleanProject.ViewModels
{
	public class LoginPageViewModel : ViewModelBase 
	{ 
        private ImageSource environmentSource;
        public ImageSource EnvironmentSource
        {
            get { return environmentSource; }
            set { SetProperty(ref environmentSource, value); }
        }

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("env"))
            {
                EnvironmentSource = ImageSource.FromResource(string.Format("CleanProject.Images.{0}_icon.png", (string)parameters["env"]));
            }
        } 
    }
}
