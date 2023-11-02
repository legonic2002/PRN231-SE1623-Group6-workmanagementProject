using Microsoft.AspNetCore.Mvc;
using WorkManagement.Helper;

public class AuthorizeMiddleware
{
	private readonly RequestDelegate _next;

	public AuthorizeMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		int? userId = context.Session.GetInt32("AccountKey");

		//check if not logged in and route is not / signin => redirect to signin
		if (userId == null && !Constant.PUBLIC_URL.Contains(context.Request.Path))
		{
			// No active session, redirect to login page
			context.Response.Redirect("/auth/login");
			return;
		}
		// Active session, proceed to next middleware
		if (userId != null &&
			(context.Request.Path.Equals(Constant.LOGIN_URL, StringComparison.OrdinalIgnoreCase) ||
			context.Request.Path.Equals(Constant.REGISTER_URL, StringComparison.OrdinalIgnoreCase)))
		{
			context.Response.Redirect("/home");
			return;
		}
		await _next(context);
	}
}
