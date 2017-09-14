﻿using MeemicMobileApp.ViewModels.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp.Views.Onboarding
{
    public partial class MeemicHolderQuestionView : ContentPage
    {
        public MeemicHolderQuestionView()
        {

			NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            this.SetNavigation<MeemicHolderQuestionViewModel>();
        }

    }
}
