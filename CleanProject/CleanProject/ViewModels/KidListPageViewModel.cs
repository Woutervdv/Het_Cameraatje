using CleanProject.Classes;
using CleanProject.Contracts;
using CleanProject.Models; 
using Prism.Navigation; 
using System.Collections.Generic; 

namespace CleanProject.ViewModels
{
    public class KidListPageViewModel : ViewModelBase
    {
        private Photo photo;

        private ICameraatjeDbContext dbContext;
        private ICameraatjeRepository repo;

        private IList<Kid> kids;
        public IList<Kid> Kids
        {
            set { SetProperty(ref kids, value); }
            get { return kids; }
        }

        private Kid selectedKid;
        public Kid SelectedKid
        {
            get { return selectedKid; }
            set
            {
                if (SetProperty(ref selectedKid, value) && selectedKid != null)
                {
                    photo.Partner= selectedKid;

                    selectedKid = null;

                    NavigationService.NavigateAsync("CornerListPage", new NavigationParameters(){
                        {"Photo", photo }
                    });
                }
            }
        }  

        public KidListPageViewModel(INavigationService navigationService, ICameraatjeRepository repo, ICameraatjeDbContext dbContext)
          : base(navigationService)
        {
            this.dbContext = dbContext;
            this.repo = repo;
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Photo"))
            {
                photo = (Photo)parameters["Photo"];
            }
             
            Kids = await repo.GetKids();
        }
    }
}