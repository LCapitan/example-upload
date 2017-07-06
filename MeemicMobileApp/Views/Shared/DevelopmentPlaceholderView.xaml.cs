using Xamarin.Forms;

namespace MeemicMobileApp.Views.Shared
{
    public partial class DevelopmentPlaceholderView : ContentPage
    {
        public DevelopmentPlaceholderView()
        {
			InitializeComponent();

		}


        public DevelopmentPlaceholderView(string name)
        {
            NavigationPage.SetHasNavigationBar(this, false);

			InitializeComponent();

            lblName.Text = name;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
