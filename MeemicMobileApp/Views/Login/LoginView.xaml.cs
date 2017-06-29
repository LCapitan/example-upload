using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MeemicMobileApp.Views.Login
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
			base.OnAppearing();


        }
    }
}
