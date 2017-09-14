using System;
using System.Collections.Generic;
using MeemicMobileApp.ViewModels.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Onboarding
{
    public partial class LearnMoreView : ContentPage
    {
        public LearnMoreView()
        {
			NavigationPage.SetHasNavigationBar(this, false);

			InitializeComponent();

            this.SetNavigation<LearnMoreViewModel>();
        }
    }
}
