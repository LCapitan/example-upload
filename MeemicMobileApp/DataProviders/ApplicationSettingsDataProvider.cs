using System;
using System.Linq;
using MeemicMobileApp.Models;
using Realms;

namespace MeemicMobileApp.DataProviders
{
    /// <summary>
    /// Handles storing and retrieving items from the ApplicationSettings in the current Realm
    /// </summary>
    public class ApplicationSettingsDataProvider : IApplicationSettingsDataProvider
    {

        private readonly Realm realm;



        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MeemicMobileApp.DataProviders.ApplicationSettingsDataProvider"/> class.
        /// </summary>
        public ApplicationSettingsDataProvider()
        {
            realm = Realm.GetInstance();
        }



		/// <summary>
		/// Gets the value of the key - if none exists, null will be returned 
		/// </summary>
		/// <returns>The value stored in the database or null is none was located</returns>
		/// <param name="key">Key.</param>
		public bool? GetBool(string key)
        {
            var appSett = realm.All<ApplicationSettings>().FirstOrDefault(a => a.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

            if (appSett == null)
                return null;

            if(bool.TryParse(appSett.Value, out bool val))
                return val;

            return null;
        }



		/// <summary>
		/// Set the specified key and value.
		/// </summary>
		/// <param name="key">The key </param>
		/// <param name="value">If set to <c>true</c> value.</param>
		public void Set(string key, bool value)
        {
            var record = realm.All<ApplicationSettings>().FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
            var transaction = realm.BeginWrite();

			if (record == null)
				record = new ApplicationSettings { Key = key };

			record.Value = value.ToString();
            realm.Add(record, true);

            transaction.Commit();
        }

    }
}
