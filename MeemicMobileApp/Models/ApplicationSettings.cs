using System;
using Realms;

namespace MeemicMobileApp.Models
{
    /// <summary>
    /// Application settings 
    /// 
    /// RealmObject used for Storage of bits of information
    /// </summary>
    public class ApplicationSettings : RealmObject
    {
        /// <summary>
        /// Key of the KVP
        /// </summary>
        public string Key { get; set; }


        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}
