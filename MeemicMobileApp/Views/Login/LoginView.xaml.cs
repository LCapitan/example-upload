using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MeemicMobileApp.Views.Login
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
        }

        protected override void OnAppearing()
        {
			base.OnAppearing();


        }
    }
}
