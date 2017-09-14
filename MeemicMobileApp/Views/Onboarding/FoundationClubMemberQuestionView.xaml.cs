using MeemicMobileApp.ViewModels.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Onboarding
{
    public partial class FoundationClubMemberQuestionView : ContentPage
    {
        public FoundationClubMemberQuestionView()
        {
			NavigationPage.SetHasNavigationBar(this, false);

			InitializeComponent();

            this.SetNavigation<FoundationClubMemberQuestionViewModel>();
        }

    }
}
