using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls.ViewModels
{
    public class ContactMeemicCardViewModel : BaseViewModel
    {
        
        /// <summary>
        /// Gets the call command.
        /// </summary>
        public ICommand CallCommand { get; private set;  }



        /// <summary>
        /// Gets the ask question command.
        /// </summary>
        public ICommand AskQuestionCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.CustomControls.ViewModels.ContactMeemicCardViewModel"/> class.
        /// </summary>
        public ContactMeemicCardViewModel()
        {
            CallCommand = new Command(async () => await CallCommandExecute());
            AskQuestionCommand = new Command(async () => await AskQuestionCommandExecute());
        }



        private async Task CallCommandExecute() 
        {
            var t = await DisplayAlert("Clal me!", "We are going to call", "Ok", "idk");
        }



        private async Task AskQuestionCommandExecute()
        {
            var t = await DisplayAlert("Email me!", "We are going to email", "Ok", "idk");
        }



    }
}
