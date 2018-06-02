using Prism.Navigation;
using CleanProject.Classes;
using System.Windows.Input;
using Prism.Commands;
using Plugin.Media;
using Prism.Services;
using Xamarin.Forms;
using Firebase.Storage;
using System.Threading.Tasks;
using System;

namespace CleanProject.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{ 
        private User user;
        private Photo photo;
        private string enviroment;
        private DateTime Now;
        private ImageSource source;
        public ImageSource Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        } 

        public ICommand LogOutCommand { get; private set; }
        public ICommand AlbumCommand { get; private set; }
        public ICommand CameraCommand { get; private set; } 

        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            LogOutCommand = new DelegateCommand(() => NavigationService.NavigateAsync("StartPage"));

            CameraCommand = new DelegateCommand(async () =>
            {
                Now = DateTime.Now;

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

                photo = new Photo();

                try
                {
                    // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                    var task = new FirebaseStorage(
                        "het-cameraatje.appspot.com",
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(user.Auth.FirebaseToken),
                        })
                        .Child("photos")
                        .Child(Convert.ToString(Now))
                        .PutAsync(file.GetStream());

                    // Track progress of the upload
                    //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    // await the task to wait until upload completes and get the download url
                    var downloadUrl = await task;


                    await dialogService.DisplayAlertAsync("Download Url", downloadUrl, "OK");

                    photo.Url = downloadUrl;
                }
                catch (Exception ex)
                {
                    await dialogService.DisplayAlertAsync("Exception was thrown", ex.Message, "OK");
                }
            });
        }
         
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("user"))
            {
                user = (User)parameters["user"];
            } 
        }
    }
}
