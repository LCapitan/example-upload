using Xamarin.Forms;

namespace MeemicMobileApp.Views.Onboarding
{
    public partial class MeemicAccountCenterQuestionView : ContentPage
    {
        public MeemicAccountCenterQuestionView()
        {
			if (Application.Current.MainPage is NavigationPage np)
				np.BarBackgroundColor = BackgroundColor;

			InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "");
        }
    }
}
