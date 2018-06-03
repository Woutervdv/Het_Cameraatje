using CleanProject.Contracts; 
using CleanProject.Models;
using Prism.Commands; 
using Prism.Navigation; 
using System.Collections.Generic; 
using System.Windows.Input;
using Xamarin.Forms;

namespace CleanProject.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private ICameraatjeRepository cameraatjeRepository;

        private Class klas;
        private Kid kid;
        private Location location; 
        private Teacher teacher;

        public ICommand StartCommand { get; set; }

        private ImageSource logoSource;
        public ImageSource LogoSource
        {
            get { return logoSource; }
            set { SetProperty(ref logoSource, value); }
        }
         
        public StartPageViewModel(INavigationService navigationService , ICameraatjeRepository cameraatjeRepository) : base (navigationService)
        { 
            this.cameraatjeRepository = cameraatjeRepository;
             
            MakeDummyData(); 

            LogoSource = ImageSource.FromResource("CleanProject.Images.logo.png");
            StartCommand = new DelegateCommand(() => NavigationService.NavigateAsync("SelectEnvironmentPage"));
        }
        private IList<Class> items;
        public IList<Class> Items
        {
            set { SetProperty(ref items, value); }
            get { return items; }
        }

        public async void MakeDummyData()
        {
            location = new Location
            {
                LocationName = "Locatie 1",
                LocationDescription = "Bureau"
            };
            await cameraatjeRepository.SaveLocation(location);

            teacher = new Teacher
            {
                TeacherFirstName = "Rudi",
                TeacherLastName="Roox",
                Email = "rudi.roox@ucll.be",
            }; 
            await cameraatjeRepository.SaveTeacher(teacher);

            klas = new Class
            {
                TeacherID = 0,
                ClassName = "ICT",
                ClassPictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwis1eipg6vbAhVDKFAKHeY_C4oQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.libelle.be%2Fvandaag%2Fhond-klas-is-positief-leerlingen%2F&psig=AOvVaw2jP9LpdX2ajSUMre2_OG5T&ust=1527686896864228"
            };
            await cameraatjeRepository.SaveClass(klas);

            kid = new Kid
            {
                Email = "yoeri.optroodt@student.ucll.be",
                ClassID = 0,
                KidFirstName = "Yoeri",
                KidLAstName = "op't Roodt",
                KidPictureUrl = "https://firebasestorage.googleapis.com/v0/b/het-cameraatje.appspot.com/o/Users%2F34429366_1578561365607033_865084856697094144_n.jpg?alt=media&token=bd2aada8-9c2f-42de-b27d-1166ec78383f"
            };
            await cameraatjeRepository.SaveKid(kid);

            kid = new Kid
            {
                Email = "wouter.vandevorst@student.ucll.be",
                ClassID = 0,
                KidFirstName = "Wouter",
                KidLAstName = "Vandevorst",
                KidPictureUrl = "https://firebasestorage.googleapis.com/v0/b/het-cameraatje.appspot.com/o/Users%2F18222532_401780166861055_8994941497264339741_n.jpg?alt=media&token=5bb88c27-962e-4821-a343-f645ef7890fa"
            };
            await cameraatjeRepository.SaveKid(kid);
        }
    }
}
