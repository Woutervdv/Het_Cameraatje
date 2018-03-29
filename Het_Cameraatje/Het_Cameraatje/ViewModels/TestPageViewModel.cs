using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Het_Cameraatje.ViewModels
{
	public class TestPageViewModel : ViewModelBase
    {
        public string PictureUrl { get; set; }

        public TestPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PictureUrl = "https://www.outbrain.com/techblog/wp-content/uploads/2017/05/road-sign-361513_960_720.jpg";
        }
	}
}
