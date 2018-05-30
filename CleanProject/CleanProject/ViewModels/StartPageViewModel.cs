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
        public ICommand StartCommand { get; set; }
        private ImageSource logoSource;
        public ImageSource LogoSource
        {
            get { return logoSource; }
            set { SetProperty(ref logoSource, value); }
        }

        private ICameraatjeRepository cameraatjeRepository;
        private Class klas;
        private Kid kid;
        private Location location;
        private Picture picture;
        private Pictures pictures;
        private Teacher teacher;

        public StartPageViewModel(INavigationService navigationService , ICameraatjeRepository cameraatjeRepository) : base (navigationService)
        { 
            this.cameraatjeRepository = cameraatjeRepository;
            MakeDummyData();
            //GetData();

            LogoSource = ImageSource.FromResource("CleanProject.Images.logo.png");
            StartCommand = new DelegateCommand(() => NavigationService.NavigateAsync("SelectEnvironmentPage"));
        }
        private IList<Class> items;
        public IList<Class> Items
        {
            set { SetProperty(ref items, value); }
            get { return items; }
        }


        //public async void GetData()
        //{
        //    Items = await cameraatjeRepository.GetClassesAsync();
        //}

        public async void MakeDummyData()
        {
            klas = new Class();
            
            klas.TeacherID = 0;
            klas.ClassName = "first class";
            klas.ClassPictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwis1eipg6vbAhVDKFAKHeY_C4oQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.libelle.be%2Fvandaag%2Fhond-klas-is-positief-leerlingen%2F&psig=AOvVaw2jP9LpdX2ajSUMre2_OG5T&ust=1527686896864228";
            await cameraatjeRepository.SaveClass(klas);
            klas = new Class();

            klas.TeacherID = 1;
            klas.ClassName = "second class";
            klas.ClassPictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwis1eipg6vbAhVDKFAKHeY_C4oQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.libelle.be%2Fvandaag%2Fhond-klas-is-positief-leerlingen%2F&psig=AOvVaw2jP9LpdX2ajSUMre2_OG5T&ust=1527686896864228";
            await cameraatjeRepository.SaveClass(klas);

            kid = new Kid();
            
            kid.Email = "test@student.be";
            kid.ClassID = 0;
            kid.KidFirstName = "wouter";
            kid.KidLAstName = "vandevorst";
            kid.KidPictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwic_OHQhKvbAhXB_aQKHcbwBmUQjRx6BAgBEAQ&url=https%3A%2F%2Fmadebykind.com%2F&psig=AOvVaw3-Xs2vTz3MQNnGl0uOrOqo&ust=1527687250182931";
            await cameraatjeRepository.SaveKid(kid);

            location = new Location();
            
            location.LocationName = "test locatie";
            location.LocationDescription = "mijn living";
            await cameraatjeRepository.SaveLocation(location);

            picture = new Picture();
            
            picture.PictureUrl = "https://www.google.be/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjcyLiphavbAhWBLVAKHWqQDE4QjRx6BAgBEAQ&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photo%2Fcute-cat-picture_883395.htm&psig=AOvVaw2PEQvtvlBUrDrsnLu0QPib&ust=1527687434907331";
            picture.AuthorID = 0;
            picture.LocationID = 0;
            await cameraatjeRepository.SavePicture(picture);

            pictures = new Pictures();
           
            pictures.PictureID = 0;
            pictures.KidID = 0;
            await cameraatjeRepository.SavePictures(pictures);

            teacher = new Teacher();
            
            teacher.Email = "test@teacher.be";
            teacher.TeacherFirstName = "Rudy";
            teacher.TeacherLastName = "Roox";
            await cameraatjeRepository.SaveTeacher(teacher); 
        }
    }
}
