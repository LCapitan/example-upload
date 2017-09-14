using System;
using System.Collections.Generic;
using MeemicMobileApp.ViewModels.Login;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Login
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
			
            InitializeComponent();

            this.SetNavigation<LoginViewModel>();
        }


    }
}
