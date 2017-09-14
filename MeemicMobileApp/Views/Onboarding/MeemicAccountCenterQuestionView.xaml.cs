using MeemicMobileApp.ViewModels.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Onboarding
{
    public partial class MeemicAccountCenterQuestionView : ContentPage
    {
        public MeemicAccountCenterQuestionView()
        {
			NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<MeemicAccountCenterQuestionViewModel>();

        }
    }
}
