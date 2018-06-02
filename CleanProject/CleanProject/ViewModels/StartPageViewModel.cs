using CleanProject.Contracts;
using CleanProject.Events;
using CleanProject.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Picture picture;
        private Pictures pictures;
        private Teacher teacher;

        private ImageSource logoSource;
        public ImageSource LogoSource
        {
            get { return logoSource; }
            set { SetProperty(ref logoSource, value); }
        }

        public ICommand StartCommand { get; set; }

        public StartPageViewModel(INavigationService navigationService , ICameraatjeRepository cameraatjeRepository) : base (navigationService)
        { 
            this.cameraatjeRepository = cameraatjeRepository;

            // MakeDummyData(); 

            LogoSource = ImageSource.FromResource("CleanProject.Images.logo.png");

            StartCommand = new DelegateCommand(() => NavigationService.NavigateAsync("SelectEnvironmentPage"));
        } 

        public async void MakeDummyData()
        {
            klas = new Class
            {
                TeacherID = 0,
                ClassName = "first class",
                ClassPictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwis1eipg6vbAhVDKFAKHeY_C4oQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.libelle.be%2Fvandaag%2Fhond-klas-is-positief-leerlingen%2F&psig=AOvVaw2jP9LpdX2ajSUMre2_OG5T&ust=1527686896864228"
            };
            await cameraatjeRepository.SaveClass(klas);

            klas = new Class
            {
                TeacherID = 1,
                ClassName = "second class",
                ClassPictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwis1eipg6vbAhVDKFAKHeY_C4oQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.libelle.be%2Fvandaag%2Fhond-klas-is-positief-leerlingen%2F&psig=AOvVaw2jP9LpdX2ajSUMre2_OG5T&ust=1527686896864228"
            };
            await cameraatjeRepository.SaveClass(klas);

            kid = new Kid
            {
                Email = "test@student.be",
                ClassID = 0,
                KidFirstName = "wouter",
                KidLAstName = "vandevorst",
                KidPictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwic_OHQhKvbAhXB_aQKHcbwBmUQjRx6BAgBEAQ&url=https%3A%2F%2Fmadebykind.com%2F&psig=AOvVaw3-Xs2vTz3MQNnGl0uOrOqo&ust=1527687250182931"
            };
            await cameraatjeRepository.SaveKid(kid);

            location = new Location
            {
                LocationName = "test locatie",
                LocationDescription = "mijn living"
            };
            await cameraatjeRepository.SaveLocation(location);

            picture = new Picture
            {
                PictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjcyLiphavbAhWBLVAKHWqQDE4QjRx6BAgBEAQ&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photo%2Fcute-cat-picture_883395.htm&psig=AOvVaw2PEQvtvlBUrDrsnLu0QPib&ust=1527687434907331",
                AuthorID = 0,
                LocationID = 0
            };
            await cameraatjeRepository.SavePicture(picture);

            pictures = new Pictures
            {
                PictureID = 0,
                KidID = 0
            };
            await cameraatjeRepository.SavePictures(pictures);

            teacher = new Teacher
            {
                Email = "test@teacher.be",
                TeacherFirstName = "Rudy",
                TeacherLastName = "Roox"
            };
            await cameraatjeRepository.SaveTeacher(teacher); 
        }
    }
}
