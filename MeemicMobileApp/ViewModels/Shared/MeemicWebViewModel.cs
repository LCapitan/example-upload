using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Shared
{
    /// <summary>
    /// Meemic Web ViewModel
    /// 
    /// This is a wrapper around the base WebView with some customizations
    /// </summary>
    public class MeemicWebViewModel : BaseViewModel
    {

        private string websiteUrl;



        /// <summary>
        /// The current URL for the website
        /// </summary>
        /// <value>The website URL.</value>
        public string WebsiteURL
        {
            get
            {
                return websiteUrl;
            }
            set
            {
                if (value != websiteUrl)
                {
                    websiteUrl = value;
                    OnPropertyChanged("WebsiteURL");
                }
            }
        }



        /// <summary>
        /// Navigation Back Command
        /// </summary>
        public ICommand NavigationBackCommand { get; private set; }



        /// <summary>
        /// Constructor
        /// </summary>
        public MeemicWebViewModel()
        {
            NavigationBackCommand = new Command(async () => await NavigationBackCommandExecute());
        }



        private async Task NavigationBackCommandExecute()
        {
            await PopPageAsync();
        }
    }
}
