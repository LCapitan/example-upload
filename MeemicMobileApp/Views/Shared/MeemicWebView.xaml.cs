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
        public MeemicWebView(string url)
        {
            InitializeComponent();

            var vm = BindingContext as MeemicWebViewModel;

            if (vm == null)
                throw new NullReferenceException(nameof(BindingContext));

            vm.WebsiteURL = url;
        }
    }
}
