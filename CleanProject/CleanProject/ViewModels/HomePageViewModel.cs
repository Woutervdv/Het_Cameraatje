using Prism.Navigation;
using CleanProject.Classes;

namespace CleanProject.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{ 
        User user;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("user"))
            {
                user = (User)parameters["user"];
            } 
        }
    }
}
