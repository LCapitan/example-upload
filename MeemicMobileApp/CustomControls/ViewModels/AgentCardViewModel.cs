using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls.ViewModels
{
    public class AgentCardViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the call command.
        /// </summary>
        public ICommand CallCommand { get; private set; }



        /// <summary>
        /// Gets the email command.
        /// </summary>
        public ICommand EmailCommand { get; private set; }



        /// <summary>
        /// Gets the website command.
        /// </summary>
        public ICommand WebsiteCommand { get; private set; }



        /// <summary>
        /// Gets the map command.
        /// </summary>
        public ICommand MapCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:MeemicMobileApp.CustomControls.ViewModels.AgentCardViewModel"/> class.
        /// </summary>
        public AgentCardViewModel()
        {
            CallCommand = new Command(async () => await CallCommandExecute());
            EmailCommand = new Command(async () => await EmailCommandExecute());
            WebsiteCommand = new Command(async () => await WebsiteCommandExecute());
            MapCommand = new Command(async () => await MapCommandExecute());
        }



        private async Task CallCommandExecute()
        {
            await DisplayAlert("Call","Call","Call","Call");
        }



        private async Task EmailCommandExecute() 
        {
            await DisplayAlert("Email", "Email", "Email", "Email");
        }



        private async Task WebsiteCommandExecute() 
        {
            await DisplayAlert("Website", "Website", "Website", "Website");
        }



        private async Task MapCommandExecute() 
        {
            await DisplayAlert("Map", "Map", "Map", "Map");
        }

    }
}
