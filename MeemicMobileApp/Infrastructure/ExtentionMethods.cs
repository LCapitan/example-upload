using MeemicMobileApp.ViewModels.Base;
using Xamarin.Forms;

public static class ExtentionMethods
{
    /// <summary>
    /// Sets the navigation on the ViewModel
    /// </summary>
    /// <param name="cp">ContentPage</param>
    /// <typeparam name="TViewModel">ViewModel</typeparam>
    public static void SetNavigation<TViewModel>(this ContentPage cp) where TViewModel : BaseViewModel 
    {
        if (cp.BindingContext is TViewModel viewModel) viewModel.Navigation = cp.Navigation;
    }
}
