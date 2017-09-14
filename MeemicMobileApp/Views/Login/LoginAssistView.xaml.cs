using MeemicMobileApp.ViewModels.Login;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Login
{
    public partial class LoginAssistView : ContentPage
    {
        public LoginAssistView()
        {
            InitializeComponent();

            this.SetNavigation<LoginAssistViewModel>();
        }
    }
}
