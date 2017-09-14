using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeemicMobileApp.ViewModels.Base
{
    /// <summary>
    /// Notify property changed implementation
    /// </summary>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Notify when a property has changed
        /// </summary>
        /// <param name="propName">Property name</param>
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            var propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }

    }
}
