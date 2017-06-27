using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.DataProviders;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Onboarding
{
    public class MeemicHolderQuestionViewModel : BaseViewModel
    {
        
        /// <summary>
        /// Command for the Yes button
        /// </summary>
        public ICommand YesCommand { get; private set; }



        /// <summary>
        /// Command for the No Button
        /// </summary>
        public ICommand NoCommand { get; private set; }



        /// <summary>
        /// Gets or sets the app settings.
        /// </summary>
        /// <value>The app settings.</value>
        public IApplicationSettingsDataProvider AppSettings { get; set; }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.ViewModels.Onboarding.MeemicHolderQuestionViewModel"/> class.
        /// </summary>
        public MeemicHolderQuestionViewModel()
        {
            YesCommand = new Command(async () => await ExecuteYesButton());
            NoCommand = new Command(async () => await ExecuteNoCommand());

        }


        private async Task ExecuteYesButton() 
        {
            await AppSettings.Set("MeemicHolder", true);
            await PushPageAsync(new MeemicMobileApp.Views.Onboarding.FoundationClubMemberQuestionView());
        }



        private async Task ExecuteNoCommand() 
        {
            await AppSettings.Set("MeemicHolder", false);
            await PushPageAsync(new MeemicMobileApp.Views.Onboarding.FoundationClubMemberQuestionView());
        }


    }
}
