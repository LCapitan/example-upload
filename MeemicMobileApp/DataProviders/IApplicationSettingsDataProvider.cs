using System;
using System.Threading.Tasks;

namespace MeemicMobileApp.DataProviders
{
    /// <summary>
    /// Interface for Application settings data provider
    /// </summary>
    public interface IApplicationSettingsDataProvider
    {
        
        /// <summary>
        /// Gets the value of the key - if none exists, null will be returned 
        /// </summary>
        /// <returns>The value stored in the database or null is none was located</returns>
        /// <param name="key">Key.</param>
        bool? GetBool(string key);



        /// <summary>
        /// Set the specified key and value.
        /// </summary>
        /// <returns>The set.</returns>
        /// <param name="key">The key </param>
        /// <param name="value">If set to <c>true</c> value.</param>
        Task Set(string key, bool value);

    }
}
