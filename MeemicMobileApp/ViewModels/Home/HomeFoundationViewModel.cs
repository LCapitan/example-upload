using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;

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
    }
}
