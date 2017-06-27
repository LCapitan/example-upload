using MeemicMobileApp.ViewModels.Base;

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
                if(value != websiteUrl)
                {
                    value = websiteUrl;
                    OnPropertyChanged();
                }    
            }
        }
    }
}
