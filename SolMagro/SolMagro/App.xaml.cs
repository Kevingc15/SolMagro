using Prism;
using Prism.Ioc;
using SolMagro.Contracts.Repositories;
using SolMagro.Repositories;
using SolMagro.Services;
using SolMagro.ViewModels;
using SolMagro.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace SolMagro
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<CalendarPage, CalendarPageViewModel>();
            containerRegistry.RegisterForNavigation<JobsPage, JobsPageViewModel>();
            containerRegistry.RegisterForNavigation<Master, MasterViewModel>();



            containerRegistry.Register<IUserRepository, UserRepository>();
            containerRegistry.Register<FileService>();
        }
    }
}
