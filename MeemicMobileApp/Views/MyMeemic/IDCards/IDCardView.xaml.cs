using MeemicMobileApp.ViewModels.MyMeemic.IDCards;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic.IDCards
{
    public partial class IDCardView : ContentPage
    {
        
        public IDCardView()
        {
            MessagingCenter.Send(this, "forceLandscape");
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<IDCardViewModel>();
        }

    }
}
