using System;
using System.Collections.Generic;
using MeemicMobileApp.ViewModels.MyMeemic.Claims;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic.Claims
{
    public partial class ClaimsView : ContentPage
    {
        public ClaimsView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<ClaimsViewModel>();
        }
    }
}
