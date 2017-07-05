using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.Shared;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Login
{
    /// <summary>
    /// Login Assist View Model
    /// </summary>
    public class LoginAssistViewModel : BaseViewModel
    {
        private bool showMeemicInstructions;
        private bool showFoundationInstructions;



        /// <summary>
        /// Should we display the Meemic Account Instructions?
        /// </summary>
        public bool ShowMeemicInstructions 
        {
            get { return showMeemicInstructions; }
            set 
            {
                if(showMeemicInstructions != value)
                {
                    showMeemicInstructions = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Should we display the Foundation Club Account Instructions?
        /// </summary>
        public bool ShowFoundationInstructions 
        {
            get { return showFoundationInstructions; }
            set 
            {
                if(showMeemicInstructions != value)
                {
                    showMeemicInstructions = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Navigate To Web Page Command 
        /// 
        /// This will use the CommandParameter to know which website to navigate to
        /// </summary>
        public ICommand NavigateToWebPageCommand { get; private set; }



        /// <summary>
        /// Constructor
        /// </summary>
        public LoginAssistViewModel()
        {
            NavigateToWebPageCommand = new Command<string>(async (x) => await NavigateToWebPageCommandExecute(x));
        }



        private async Task NavigateToWebPageCommandExecute(string url) 
        {
            await PushPageAsync(new MeemicWebView(url));
        }

    }
}
