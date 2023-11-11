using MessagePack.Resolvers;

namespace WorkManagement.Helper
{
	public static class Constant
	{
		public static List<string> PUBLIC_URL = new List<string>
		{
			"/api/Apply/apply-job",
			"/api/Accounts",
            "/api/Accounts/login",
			"/auth/login",
			"/api/auth/register",
			"/auth/register",
			"/home",
			"/"
		};
		public static string LOGIN_URL = "/auth/login";
		public static string REGISTER_URL = "/auth/register";
	}
}
