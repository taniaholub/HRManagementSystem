using CCL.Security.Identity;
using System;

namespace CCL.Security
{
    public static class SecurityContext
    {
        private static User _user = null;

        // Отримати поточного користувача
        public static User GetUser()
        {
            if (_user == null)
            {
                throw new NullReferenceException("No user is set in the SecurityContext.");
            }
            return _user;
        }


        // Встановити поточного користувача
        public static void SetUser(User user)
        {
            _user = user;
        }
    }
}
