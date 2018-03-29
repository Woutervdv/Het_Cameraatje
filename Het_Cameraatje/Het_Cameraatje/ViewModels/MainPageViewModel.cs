using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Het_Cameraatje.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand LoginNavigateCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Start";

            LoginNavigateCommand = new DelegateCommand(() => {
                navigationService.NavigateAsync("TestPage");
            });
        }
    }
}
