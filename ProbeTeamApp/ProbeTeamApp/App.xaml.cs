using ProbeTeam.App.Application;
using ProbeTeam.App.Domain.Services;
using ProbeTeam.App.Infra.DataAccess.Repositories.Players;
using ProbeTeamApp.Views.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbeTeamApp
{
    public partial class App : Application
    {
        public static IAppService AppService { get; set; }
        public static PlayerLocalService Service { get; set; }


        public App()
        {
            InitializeComponent();
            AppService = new CoachMobileAppService();
            Service = new PlayerLocalService(new SQLitePlayersRepository(Device.RuntimePlatform));
            MainPage = new NavigationPage(new SignInPage());     
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
