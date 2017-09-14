using MeemicMobileApp.ViewModels.MyMeemic.Claims;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic.Claims
{
    public partial class SelectPolicyView : ContentPage
    {
        public SelectPolicyView()
        {
			NavigationPage.SetHasNavigationBar(this, false);

			InitializeComponent();

			this.SetNavigation<SelectPolicyViewModel>();
        }
    }
}
