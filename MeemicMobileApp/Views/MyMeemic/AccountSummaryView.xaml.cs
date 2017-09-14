﻿using MeemicMobileApp.ViewModels.MyMeemic;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic
{
    public partial class AccountSummaryView : ContentPage
    {

        public AccountSummaryView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<AccountSummaryViewModel>();

        }
    }
}
