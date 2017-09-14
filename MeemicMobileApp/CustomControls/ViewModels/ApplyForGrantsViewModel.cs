using System.Threading.Tasks;
using System.Windows.Input;
using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

namespace MeemicMobileApp.CustomControls.ViewModels
{
    public class ApplyForGrantsViewModel : BaseViewModel
    {
        
        /// <summary>
        /// Gets the join today command.
        /// </summary>
        public ICommand JoinTodayCommand { get; private set; }



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.CustomControls.ViewModels.ApplyForGrantsViewModel"/> class.
        /// </summary>
        public ApplyForGrantsViewModel()
        {
            JoinTodayCommand = new Command(async () => await JoinTodayCommandExecute());
        }



        private async Task JoinTodayCommandExecute()
        {
            await DisplayAlert("Need info", "What do we do here?", "Okay", "Cancel");
        }

    }
}
