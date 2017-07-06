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
			InitializeComponent();

			lblName.Text = name;
        }   
    }
}
