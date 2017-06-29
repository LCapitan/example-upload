using System;
using System.Collections.Generic;
using MeemicMobileApp.Managers.Interfaces;

namespace MeemicMobileApp.Managers
{
    /// <summary>
    /// Login Manager used for development
    /// 
    /// @TODO(sjv): THIS IS FOR DEV ONLY
    /// </summary>
    public class InMemoryLoginManager : ILoginManager
    {
        private readonly Dictionary<string, string> loginDatabase;

        public InMemoryLoginManager()
        {

            loginDatabase = new Dictionary<string, string>
            {
                {"Scott.Vaverchak@gmail.com", "Test1234!"},
                {"Test@test.com", "test"}
            };

        }



        /// <summary>
        /// Log the user in 
        /// </summary>
        /// <returns>True on success, false on failure</returns>
        /// <param name="email">Email of the user</param>
        /// <param name="password">Password of the user</param>
        public bool Login(string email, string password)
        {
            var id = loginDatabase[email];

            if (id == null) return false;

            return password.Equals(id, StringComparison.OrdinalIgnoreCase);
        }



        /// <summary>
        /// Log the user out 
        /// </summary>
        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
