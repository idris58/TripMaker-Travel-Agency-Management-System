namespace TripMaker
{
    public static class Session
    {
        public static string LoggedInUsername { get; set; } = null;
        public static bool IsAdmin { get; set; } = false;

        public static bool IsLoggedIn => !string.IsNullOrEmpty(LoggedInUsername);

        public static void Logout()
        {
            LoggedInUsername = null;
            IsAdmin = false;
        }
    }
}
