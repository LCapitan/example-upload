using MeemicMobileApp.Views.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp
{
    public partial class App : Application
    {
        private bool hasCompletedOnboarding = false;

        public App()
        {
            InitializeComponent();

            if (hasCompletedOnboarding)
                MainPage = new MeemicMobileAppPage();
            else
            {
                var np = new NavigationPage(new MeemicHolderQuestionView());

                MainPage = np;      
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
