using CCL.Security.Identity;

namespace CCL
{
    public static class SecurityContext
    {
        private static User _user = null;

        // Отримати поточного користувача
        public static User GetUser()
        {
            return _user;
        }

        // Встановити поточного користувача
        public static void SetUser(User user)
        {
            _user = user;
        }
    }
}
