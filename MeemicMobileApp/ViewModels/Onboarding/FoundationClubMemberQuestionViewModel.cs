using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.DataProviders;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Onboarding
{
    /// <summary>
    /// Foundation club member question view model.
    /// </summary>
    public class FoundationClubMemberQuestionViewModel : BaseViewModel
    {
        private bool meemicHolder = false;


        /// <summary>
        /// Command for the Yes Button
        /// </summary>
        public ICommand YesCommand { get; private set; }



        /// <summary>
        /// COmmand for the No Button
        /// </summary>
        public ICommand NoCommand { get; private set; }



        /// <summary>
        /// Application Settings stored in Relam
        /// </summary>
        public IApplicationSettingsDataProvider AppSettings { get; set; }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.ViewModels.Onboarding.FoundationClubMemberQuestionViewModel"/> class.
        /// </summary>
        public FoundationClubMemberQuestionViewModel()
        {
            YesCommand = new Command(async () => await ExecuteYesCommand());
            NoCommand = new Command(async () => await ExecuteNoCommand());

            var mh = AppSettings.GetBool("MeemicHolder");

            // We dont have a value, we should make the reselect it?
            if (mh.HasValue == false)
                PopPageAsync(true);

            meemicHolder = mh.Value;
        }



        private async Task ExecuteYesCommand() 
        {
            var page = SelectPage(meemicHolder, true);

            await PushPageAsync(page, true);
        }



        private async Task ExecuteNoCommand() 
        {
            var page = SelectPage(meemicHolder, false);

            await PushPageAsync(page, true);
        }


        private Page SelectPage(bool meemicHolder, bool foundationClub)
        {
            if (!meemicHolder && !foundationClub)
            {
                return new LearnMoreView();
            }
        }


    }
}
