using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.Login;
using MeemicMobileApp.Views.Shared;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Onboarding
{
    public class MeemicAccountCenterQuestionViewModel : BaseViewModel
    {
        
        /// <summary>
        /// Not Registered Command
        /// </summary>
        public ICommand NotRegisteredCommand { get; private set; }



        /// <summary>
        /// Registered Command
        /// </summary>
        public ICommand RegisteredCommand { get; private set; }



        /// <summary>
        /// Not Sure Command
        /// </summary>
        public ICommand NotSureCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.ViewModels.Onboarding.MeemicAccountCenterQuestionViewModel"/> class.
        /// </summary>
        public MeemicAccountCenterQuestionViewModel()
        {
            
            NotRegisteredCommand = new Command(async () => await NotRegisteredCommandExecute());
            RegisteredCommand = new Command(async () => await RegisteredCommandExectute());
            NotSureCommand = new Command(async () => await NotSureCommandExecute());

        }



        private async Task NotRegisteredCommandExecute() 
        {
            await PushPageAsync(new MeemicWebView("https://www.google.com"));
        }



        private async Task RegisteredCommandExectute() 
        {
            var lv = new LoginView();
            await PushPageAsync(lv, true);
        }



        private async Task NotSureCommandExecute() 
        {
            var res = await DisplayAlert(
                "Not sure? That's OK", 
                "Let's try logging in with your email address and password. If it doesn't work, we have log in assistance on the log in screen for you.",
                "OK", 
                "Cancel"
            );

            if (res == false)
                return;

            var lv = new LoginView();
            await PushPageAsync(lv, true);
        }


    }
}
