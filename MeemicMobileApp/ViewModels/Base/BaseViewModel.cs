using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeemicMobileApp.ViewModels.Base
{
    /// <summary>
    /// Base ViewModel that all ViewModels inherit 
    /// </summary>
    public class BaseViewModel : NotifyPropertyChanged
    {
        private INavigation nav;



        /// <summary>
        /// Gets or sets the navigation.
        /// </summary>
        public INavigation Navigation { 
            get {
                return nav;   
            } 
            set
            {
                if(nav != value)
                {
                    nav = value;
                    OnPropertyChanged();
                }
            } 
        }



        /// <summary>
        /// Push the page on top of the navagitation stack
        /// </summary>
        /// <param name="page">The page to display</param>
        protected async Task PushPageAsync(Page page)
        {
            await Navigation.PushAsync(page);
        }



		/// <summary>
		/// Push the page on top of the navagitation stack
		/// </summary>
		/// <param name="page">The page to display</param>
		/// <param name="animate">If set to <c>true</c>, animate.</param>
		protected async Task PushPageAsync(Page page, bool animate)
		{
			await Navigation.PushAsync(page);
		}



		/// <summary>
		/// Pops the top page off of the stack
		/// </summary>
		/// <param name="animate">If set to <c>true</c>, animate.</param>
		/// <returns>A task</returns>
		protected async Task PopPageAsync(bool animate = true)
        {
            await Navigation.PopAsync(animate);

        }



		/// <summary>
		/// Push the modal on top of the modal stack
		/// </summary>
		/// <param name="page">Modal to display</param>
		/// <param name="animate">If set to <c>true</c>, animate.</param>
		/// <returns>A task</returns>
		protected async Task PushModalAsync(Page page, bool animate) 
        {
            await Navigation.PushModalAsync(page, animate);    
        }



		/// <summary>
		/// Pops the top modal off of the modal stack
		/// </summary>
		/// <param name="animate">If set to <c>true</c>, animate.</param>
		/// <returns>A task</returns>
		protected async Task PopModalAsync(bool animate = true)
        {
            await Navigation.PopModalAsync(animate);
        }



        /// <summary>
        /// Displays an Alert on the current page
        /// </summary>
        /// <returns>True is accepted, false is canceled</returns>
        /// <param name="title">Title to display</param>
        /// <param name="message">Message to display</param>
        /// <param name="accept">Accept button title</param>
        /// <param name="cancel">Cancel button title</param>
        protected async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }



		/// <summary>
		/// Displays an Alert on the current page
		/// </summary>
		/// <param name="title">Title to display</param>
		/// <param name="message">Message to display</param>
		/// <param name="cancel">Cancel button title</param>
		protected async Task DisplayAlert(string title, string message, string cancel)
		{
			await Application.Current.MainPage.DisplayAlert(title, message, cancel);
		}



		/// <summary>
		/// Displays a ActionSheet on the current page
		/// </summary>
		/// <returns>String of which button was clicked</returns>
		/// <param name="title">Title of the action sheeet </param>
		/// <param name="cancel">Title of the cancel button, null if you do not wish to display it</param>
		/// <param name="destruction">Title of the destruction button, null if you do not wish to display it</param>
		/// <param name="buttons">Array of additional buttons</param>
		protected async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }



        protected async Task PushModalAsync(Page page)
        {
            await Navigation.PushModalAsync(page);
        }



        protected async Task PopModalAsync(Page page) 
        {
            await Navigation.PopModalAsync();
        }


        /// <summary>
        /// Assign the MainPage of the current application
        /// </summary>
        /// <param name="page">Page to assign</param>
        protected void SetMainPage(Page page)
        {
            Application.Current.MainPage = page;
        }


        protected void MakeCall(string phoneNumber)
        {
            Device.OpenUri(new Uri($"tel: {phoneNumber}"));
        }



    }
}
