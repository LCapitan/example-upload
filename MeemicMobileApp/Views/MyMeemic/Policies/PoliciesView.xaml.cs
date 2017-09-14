using System;
using System.Collections.Generic;
using MeemicMobileApp.ViewModels.MyMeemic.Policies;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.MyMeemic.Policies
{
    public partial class PoliciesView : ContentPage
    {
        public PoliciesView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<PoliciesViewModel>();
        }
    }
}
