using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MeemicMobileApp.Views.Shared
{
    public partial class DevelopmentSandboxView : ContentPage
    {
        public DevelopmentSandboxView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }
    }
}
