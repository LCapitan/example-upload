using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.CustomControls;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.Onboarding;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Shared
{
    public class DevelopmentSandboxViewModel : BaseViewModel
    {
        private NavigationHeaderMode navigationMode;



        /// <summary>
        /// Gets or sets the navigation mode.
        /// </summary>
        public NavigationHeaderMode NavigationMode
        {
            get { return navigationMode; }
            set 
            {
                if(navigationMode != value)
                {
                    navigationMode = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Gets the set navigation mode command.
        /// </summary>
        public ICommand SetNavigationModeCommand { get; private set; }   



        /// <summary>
        /// Gets the display modal command.
        /// </summary>
        public ICommand DisplayModalCommand { get; private set; }




        /// <summary>
        /// Constructor
        /// </summary>
        public DevelopmentSandboxViewModel ()
        {
            SetNavigationModeCommand = new Command<string>(SetNavigationModeCommandExecute);
            DisplayModalCommand = new Command(async () => await DisplayModalCommandExecute());
        }




        private async Task DisplayModalCommandExecute() 
        {
            
        }



        private void SetNavigationModeCommandExecute(string mode)
        {
            if (int.TryParse(mode, out int output) == false)
                return;

            NavigationMode = (NavigationHeaderMode)output;
        }
    }
}
