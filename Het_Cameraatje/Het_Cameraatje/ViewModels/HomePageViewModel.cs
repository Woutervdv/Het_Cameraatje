using Firebase.Auth;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Het_Cameraatje.Repositories;
using Het_Cameraatje.Contracts;
using Plugin.Media;
using Firebase.Storage;
using System.Threading.Tasks;
using Xamarin.Forms;

/*
 * created by Wouter on 25/04/2018
 */
namespace Het_Cameraatje.ViewModels
{

	public class HomePageViewModel : ViewModelBase
    {         
        private string environment;

        public User user { get; set; }
        private bool visible;
        public bool Visible
        {
            get { return visible; }
            set { SetProperty(ref visible, value); }
        }

        private ImageSource source;
        public ImageSource Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }



        public ICommand LogOutCommand { get; private set; }
        public ICommand AlbumCommand { get; private set; }
        public ICommand CameraCommand { get; private set; }
        public ICommand ReturnCommand { get; private set; }

         public  HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Visible = false;
            LogOutCommand = new DelegateCommand(() =>
            {
                NavigationService.NavigateAsync("StartPage");
            });

            AlbumCommand = new DelegateCommand(async () =>
            {
                var p = new NavigationParameters
                {
                    { "Environment", environment },
                    { "User", user }
                };
                await NavigationService.NavigateAsync("GalleryPage", p);
            });

            CameraCommand = new DelegateCommand(async () =>
            {

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await dialogService.DisplayAlertAsync("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                await dialogService.DisplayAlertAsync("File Location", "is opgeslagen ", "OK");

                Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });

                try
                {
                   

                    // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                    var task = new FirebaseStorage(
                        "het-cameraatje.appspot.com",
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(user.Auth.FirebaseToken),
                        })
                        .Child("data")
                        .Child("random")
                        .PutAsync(file.GetStream());

                    // Track progress of the upload
                    //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    // await the task to wait until upload completes and get the download url
                    var downloadUrl = await task;
                    await dialogService.DisplayAlertAsync("Download Url", downloadUrl, "OK");
                    var p = new NavigationParameters
                    {
                        { "Environment", environment },
                        { "User", user },
                        { "PictureUrl", downloadUrl }
                    };
                    await NavigationService.NavigateAsync("KidListPage", p);
                }
                catch (Exception ex)
                {
                    await dialogService.DisplayAlertAsync("Exception was thrown", ex.Message, "OK");
                }

            });

            ReturnCommand = new DelegateCommand(() =>
            {
                NavigationService.GoBackAsync();
            }); 
        }

       




       

        


        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Environment"))
            {
                environment = (string)parameters["Environment"];
            }
            if (parameters.ContainsKey("User"))
            {
                user = (User)parameters["User"];

                Visible = user.School;
            }
        }
    }
}
