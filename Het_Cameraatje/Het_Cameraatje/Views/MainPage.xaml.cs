using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Het_Cameraatje.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

        public async void Aanmelden_Clicked(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new LoginPage());
        }
	}
}