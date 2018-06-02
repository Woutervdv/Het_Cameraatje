using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace CleanProject.ViewModels
{
	public class SelectEnvironmentPageViewModel : ViewModelBase
	{
        private ImageSource homeSource;
        public ImageSource HomeSource
        {
            get { return homeSource; }
            set { SetProperty(ref homeSource, value); }
        }

        private ImageSource schoolSource;
        public ImageSource SchoolSource
        {
            get { return schoolSource; }
            set { SetProperty(ref schoolSource, value); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand SchoolCommand { get; set; }

        public ImageSource SchoolSource1 { get => schoolSource; set => schoolSource = value; }

        public SelectEnvironmentPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            HomeSource = ImageSource.FromResource("CleanProject.Images.home_icon.png");
            SchoolSource = ImageSource.FromResource("CleanProject.Images.school_icon.png");

            HomeCommand = new DelegateCommand(() => navigate("home"));
            SchoolCommand = new DelegateCommand(() => navigate("school"));
        }

        private void navigate(string env)
        {
            NavigationService.NavigateAsync("LoginPage", new NavigationParameters
            {
                {"env", env }
            });
        }
    }
}
