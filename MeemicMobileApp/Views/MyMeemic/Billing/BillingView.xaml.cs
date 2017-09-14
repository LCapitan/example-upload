using MeemicMobileApp.ViewModels.MyMeemic.Billing;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic.Billing
{
    public partial class BillingView : ContentPage
    {
        public BillingView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<BillingViewModel>();
        }
    }
}
