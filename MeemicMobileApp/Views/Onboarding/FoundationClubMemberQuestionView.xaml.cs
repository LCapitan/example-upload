using Xamarin.Forms;

namespace MeemicMobileApp.Views.Onboarding
{
    public partial class FoundationClubMemberQuestionView : ContentPage
    {
        public FoundationClubMemberQuestionView()
        {
			if (Application.Current.MainPage is NavigationPage np)
				np.BarBackgroundColor = BackgroundColor;

            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "");
        }

    }
}
