using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Base
{
    /// <summary>
    /// Base ViewModel that all ViewModels inherit 
    /// </summary>
    public class BaseViewModel : NotifyPropertyChanged
    {

        /// <summary>
        /// Push the page on top of the navagitation stack
        /// </summary>
        /// <param name="page">The page to display</param>
        /// <param name="animate">If set to <c>true</c>, animate.</param>
        /// <returns>A task</returns>
        protected async Task PushPageAsync(Page page, bool animate = true)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page, animate);
        }



		/// <summary>
		/// Pops the top page off of the stack
		/// </summary>
		/// <param name="animate">If set to <c>true</c>, animate.</param>
		/// <returns>A task</returns>
		protected async Task PopPageAsync(bool animate = true)
        {
            await Application.Current.MainPage.Navigation.PopAsync(animate);

        }



		/// <summary>
		/// Push the modal on top of the modal stack
		/// </summary>
		/// <param name="page">Modal to display</param>
		/// <param name="animate">If set to <c>true</c>, animate.</param>
		/// <returns>A task</returns>
		protected async Task PushModalAsync(Page page, bool animate = true) 
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page, animate);    
        }



		/// <summary>
		/// Pops the top modal off of the modal stack
		/// </summary>
		/// <param name="animate">If set to <c>true</c>, animate.</param>
		/// <returns>A task</returns>
		protected async Task PopModalAsync(bool animate = true)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync(animate);
        }

    }
}
