using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.Shared;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Home
{
    /// <summary>
    /// Home Foundation ViewModel
    /// 
    /// Contains the commands for the button on the home screen that
    /// deal with Foundation Club
    /// </summary>
    public class HomeFoundationViewModel : BaseViewModel
    {
        
        /// <summary>
        /// My Grant Applications Command 
        /// </summary>
        public ICommand MyGrantApplicationsCommand { get; private set; }



        /// <summary>
        /// Apply For A Grant Command
        /// </summary>
        public ICommand ApplyForAGrantCommand { get; private set; }



        /// <summary>
        /// Workshops and Events Command
        /// </summary>
        public ICommand WorkshopsAndEventsCommand { get; private set; }



        /// <summary>
        /// Discounts and Benefits Command
        /// </summary>
        public ICommand DiscountsAndBenefitsCommand { get; private set; }



        /// <summary>
        /// Contact Foundation Club Command 
        /// </summary>
        public ICommand ContactFoundationClubCommand { get; private set; }



        /// <summary>
        /// About Foundation Club Command
        /// </summary>
        public ICommand AboutFoundationClubCommand { get; private set; }



        /// <summary>
        /// Constructor
        /// </summary>
        public HomeFoundationViewModel()
        {
			MyGrantApplicationsCommand = new Command(async () => await MyGrantApplicationsCommandExecute());
            ApplyForAGrantCommand = new Command(async () => await ApplyForAGrantCommandExecute());
            WorkshopsAndEventsCommand = new Command(async () => await WorkshopsAndEventsCommandExecute());
            DiscountsAndBenefitsCommand = new Command(async () => await DiscountsAndBenefitsCommandExecute());
            ContactFoundationClubCommand = new Command(async () => await ContactFoundationClubCommandExecute());
            AboutFoundationClubCommand = new Command(async () => await AboutFoundationClubCommandExecute());
        }



        private async Task MyGrantApplicationsCommandExecute() 
        {
            await PushPageAsync(new DevelopmentPlaceholderView("My Grant Applications"));
        }



        private async Task ApplyForAGrantCommandExecute()
        {
            await PushPageAsync(new DevelopmentPlaceholderView("Apply For a Grant"));
        }



        private async Task WorkshopsAndEventsCommandExecute() 
        {
            await PushPageAsync(new DevelopmentPlaceholderView("Worksshops & Events"));
        }



        private async Task DiscountsAndBenefitsCommandExecute() 
        {
            await PushPageAsync(new DevelopmentPlaceholderView("Discounts & Benefits"));
        }



        private async Task ContactFoundationClubCommandExecute() 
        {
            await PushPageAsync(new DevelopmentPlaceholderView("Contact Foundation Club"));
        }



        private async Task AboutFoundationClubCommandExecute() 
        {
            await PushPageAsync(new DevelopmentPlaceholderView("About Foundation Club"));
        }

    }
}
