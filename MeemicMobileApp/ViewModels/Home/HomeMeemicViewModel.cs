using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.MyMeemic;
using MeemicMobileApp.Views.Shared;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Home
{
    /// <summary>
    /// Home Meemic ViewModel
    /// 
    /// Contains all the commands that deal with Meemic Policy
    /// on the HomeView
    /// </summary>
    public class HomeMeemicViewModel : BaseViewModel
    {
        
		/// <summary>
		/// My Policies Command
		/// </summary>
		public ICommand MyPoliciesCommand { get; private set; }



		/// <summary>
		/// Billing Command
		/// </summary>
		public ICommand BillingCommand { get; private set; }



		/// <summary>
		/// Claims Command
		/// </summary>
		public ICommand ClaimsCommand { get; private set; }



		/// <summary>
		/// Auto ID Cards Command
		/// </summary>
		public ICommand AutoIDCardsCommand { get; private set; }



		/// <summary>
		/// Roadside & Accident Assistance Command
		/// </summary>
		public ICommand RoadsideAccidentAssistanceCommand { get; private set; }



		/// <summary>
		/// Meemic 24/7 Contact Command
		/// </summary>
		public ICommand MeemicContactCommand { get; private set; }



		/// <summary>
		/// Agent Info Command
		/// </summary>
		public ICommand AgentInfoCommand { get; private set; }



        /// <summary>
        /// About The Meemic Story Command
        /// </summary>
        public ICommand AboutTheMeemicStoryCommand { get; private set; }



        /// <summary>
        /// Constructor
        /// </summary>
        public HomeMeemicViewModel()
        {
            MyPoliciesCommand = new Command(MyPoliciesCommandExecute);
            BillingCommand = new Command(async () => await BillingCommandExecute());
            ClaimsCommand = new Command(async () => await ClaimsCommandExecute());
            AutoIDCardsCommand = new Command(async () => await AutoIDCardsCommandExecute());
            RoadsideAccidentAssistanceCommand = new Command(async () => await RoadsideAccidentAssistanceCommandExecute());
            MeemicContactCommand = new Command(async () => await MeemicContactCommandExecute());
            AgentInfoCommand = new Command(async () => await AgentInfoCommandExecute());
            AboutTheMeemicStoryCommand = new Command(async () => await AboutTheMeemicStoryCommandExecute());
        }



        private void MyPoliciesCommandExecute() 
        {
            SetMainPage(new AccountContainerView());
        }



        private async Task BillingCommandExecute() 
        { 
            await PushPageAsync(new DevelopmentPlaceholderView("Billing"));
        }



        private async Task ClaimsCommandExecute() 
        { 
            await PushPageAsync(new DevelopmentPlaceholderView("Claims"));
        }
		


        private async Task AutoIDCardsCommandExecute() 
        { 
            await PushPageAsync(new DevelopmentPlaceholderView("Auto ID Cards"));
        }



		private async Task RoadsideAccidentAssistanceCommandExecute() 
        { 
            await PushPageAsync(new DevelopmentPlaceholderView("Roadside & Accident"));
        }
		


        private async Task MeemicContactCommandExecute() 
        { 
            await PushPageAsync(new DevelopmentPlaceholderView("Meemic Contact"));
        }



		private async Task AgentInfoCommandExecute() 
        { 
            await PushPageAsync(new DevelopmentPlaceholderView("Agent Info"));
        }



        private async Task AboutTheMeemicStoryCommandExecute() 
        {
            await PushPageAsync(new DevelopmentPlaceholderView("About Meemic"));
        }
	}
}
