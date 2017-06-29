using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.Managers.Interfaces;
using MeemicMobileApp.ViewModels.Base;
using MeemicMobileApp.Views.Home;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Login
{
    /// <summary>
    /// Login view model.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private string email;
        private string password;
        private bool saveEmail;
        private bool keepMeLoggedIn;

		


        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email 
        {
            get { return email; }
            set 
            {
                if(value != email) 
                {
                    email = value;
                    OnPropertyChanged();
                }

            }
        }



        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password 
        {
            get { return password; }
            set 
            {
                if(value != password) 
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Gets or sets if the email should be saved
        /// </summary>
        public bool SaveEmail
        {
            get { return saveEmail; }
            set 
            {
                if(value != saveEmail)
                {
                    saveEmail = value;
                    OnPropertyChanged();
                }
            }
        }



        /// <summary>
        /// Gets or sets if we should keep the user logged in
        /// </summary>
        /// <value><c>true</c> if keep me logged in; otherwise, <c>false</c>.</value>
        public bool KeepMeLoggedIn
        {
            get { return keepMeLoggedIn; }
            set 
            {
                if(value != keepMeLoggedIn)
                {
                    keepMeLoggedIn = value;
                    OnPropertyChanged();
                }

            }
        }



		/// <summary>
		/// Login manager used for loggin in
		/// </summary>
		public ILoginManager LoginManager { get; set; }



        /// <summary>
        /// Login Command
        /// </summary>
        public ICommand LoginCommand { get; private set; }



        /// <summary>
        /// Login Assistance Command
        /// </summary>
        public ICommand LoginAssistCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="T:MeemicMobileApp.ViewModels.Onboarding.LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandExecute(), CanLoginCommandExecute);
            LoginAssistCommand = new Command(LoginAssistCommandExecute);
        }



		private async Task LoginCommandExecute() 
        {
            var wasSuccessful = LoginManager.Login(Email, Password);

            if(wasSuccessful == false)
            {
                await DisplayAlert("Error Logging In", "Invalid Email or Password combination", "OK");
                return;
            }

            SetMainPage(new HomeView());

        }



        private bool CanLoginCommandExecute() 
        {
            // @TODO(sjv): We will be moving this into behaivors and checking if 
            // these are valid

            if (string.IsNullOrWhiteSpace(Email))
                return false;

            if (string.IsNullOrWhiteSpace(Password))
                return false;

            return true;   
        }



        private void LoginAssistCommandExecute()
        {
            
        }

    }
}
