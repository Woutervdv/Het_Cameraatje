using Prism.Mvvm;
using CleanProject.Classes;
using Prism.Navigation;
using CleanProject.Contracts;
using System.Collections.Generic;
using CleanProject.Models;

namespace CleanProject.ViewModels
{
	public class AlbumPageViewModel : ViewModelBase
	{
        private User user;
        private ICameraatjeDbContext dbContext;
        private ICameraatjeRepository repo;
        public AlbumPageViewModel(INavigationService navigationService, ICameraatjeRepository repo, ICameraatjeDbContext dbContext)
            :base(navigationService)
        {
            this.dbContext = dbContext;
            this.repo = repo;
        }

        private IList<Picture> picture;
        public IList<Picture> Picture
        {
            set { SetProperty(ref picture, value); }
            get { return picture; }
        }



        private Picture selectedPicture;
        public Picture SelectedPicture
        {
            get { return selectedPicture; }
            set
            {
                if (SetProperty(ref selectedPicture, value) && selectedPicture != null)
                {
                    NavigationService.NavigateAsync("DetailsPhotoPage", new NavigationParameters(){
                        {"Picture", selectedPicture }
                    });

                }
            }
        }



        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("User"))
            {
                user = (User)parameters["User"];
            }

            Picture = await repo.GetPicturesAsync(user);
        }
    }
}
