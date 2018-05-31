using Prism;
using Prism.Ioc;
using CleanProject.ViewModels;
using CleanProject.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using CleanProject.Contracts;
using CleanProject.Data;
using CleanProject.Repositories;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CleanProject
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/StartPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<StartPage>();
            containerRegistry.Register<ICameraatjeDbContext, CameraatjeDbContext>();
            containerRegistry.Register<ICameraatjeRepository, CameraatjeRepository>();
            containerRegistry.RegisterForNavigation<SelectEnvironmentPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<KidListPage>();
            containerRegistry.RegisterForNavigation<CornerListPage>();
        }
    }
}
