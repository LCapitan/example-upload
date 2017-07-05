using System;
using MeemicMobileApp.ViewModels.Shared;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Shared
{
    /// <summary>
    /// Meemic web view code behind
    /// </summary>
    public partial class MeemicWebView : ContentPage
    {
        
        /// <summary>
        /// This is here to satisfy the XAML previewer - this could be removed in release
        /// </summary>
        public MeemicWebView()
        {
			InitializeComponent();
		}



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">The URL to navigate to</param>
        public MeemicWebView(string url)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            var vm = BindingContext as MeemicWebViewModel;

            if (vm == null)
                throw new NullReferenceException(nameof(BindingContext));

            vm.WebsiteURL = url;
        }

    }
}
