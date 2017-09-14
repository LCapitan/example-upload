using MeemicMobileApp.ViewModels.MyMeemic.IDCards;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic.IDCards
{
    public partial class IDCardListView : ContentPage
    {
        public IDCardListView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<IDCardListViewModel>();
        }
    }
}