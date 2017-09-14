using MeemicMobileApp.ViewModels.Home;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Home
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<HomeViewModel>();
        }
    }
}
