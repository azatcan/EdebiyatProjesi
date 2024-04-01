namespace EDB.BackofficeUI.Utils
{
    public struct DefaultClientEndpoint
    {
        public struct Authentice
        {
            public const string Login = "/api/Account/login";

            public const string Register = "/api/Account/register";
            public const string Logout = "/api/Account/logout";
            public const string GetUserRoles = "/api/Account/getUserRoles";
        }

        public struct Category
        {
            public const string List = "/api/Category/categorylist";
        }
    }
}
