using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.DataProviders;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.Login;
using MeemicMobileApp.Views.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Onboarding
{
    /// <summary>
    /// Foundation club member question view model.
    /// </summary>
    public class FoundationClubMemberQuestionViewModel : BaseViewModel
    {
        private bool meemicHolder = false;
        private IApplicationSettingsDataProvider appSettings;



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
        public IApplicationSettingsDataProvider AppSettings 
        {
            get
            {
                return appSettings;
            }
            set 
            {
                if(value != null)
                {
                    // @NOTE(sjv): Below is needed since the VM ctor is run before props are set
                    appSettings = value;

					var mh = AppSettings.GetBool("MeemicHolder");

					// We dont have a value, we should make the reselect it?
					if (mh.HasValue == false)
						PopPageAsync(true);

					meemicHolder = mh.Value;
                }

            }
        }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.ViewModels.Onboarding.FoundationClubMemberQuestionViewModel"/> class.
        /// </summary>
        public FoundationClubMemberQuestionViewModel()
        {
            YesCommand = new Command(async () => await ExecuteYesCommand());
            NoCommand = new Command(async () => await ExecuteNoCommand());

        }



        private async Task ExecuteYesCommand() 
        {
            AppSettings.Set("FoundationClub", true);
            await SelectPage(meemicHolder, true);
        }



        private async Task ExecuteNoCommand() 
        {
            AppSettings.Set("FoundationClub", false);
            await SelectPage(meemicHolder, false);
        }



        private async Task SelectPage(bool mh, bool foundationClub)
        {
            if (mh) 
            {
				await PushPageAsync(new MeemicAccountCenterQuestionView(), true);
            } 
            else if (foundationClub) 
            {
                var lv = new LoginView();
                SetMainPage(lv);
            } 
            else 
            {
                await PushPageAsync(new LearnMoreView(), true);
            }
        }


    }
}
