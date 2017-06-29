namespace MeemicMobileApp.Managers.Interfaces
{

    /// <summary>
    /// Login Manager Interface
    /// 
    /// This will log users in and out
    /// </summary>
    public interface ILoginManager
    {
        
        /// <summary>
        /// Login the specified email and password.
        /// </summary>
        /// <returns>True on successful login, false on failed</returns>
        /// <param name="email">Email for login</param>
        /// <param name="password">Password for login</param>
        bool Login(string email, string password);



        /// <summary>
        /// Log the user out
        /// </summary>
        void Logout();
        
    }
}
