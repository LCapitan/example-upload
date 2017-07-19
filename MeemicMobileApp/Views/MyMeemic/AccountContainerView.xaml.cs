using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic
{
    public partial class AccountContainerView : TabbedPage
    {
        public AccountContainerView()
        {
            // @NOTE(sjv): We shouldn't need the below
            // NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }
    }
}
