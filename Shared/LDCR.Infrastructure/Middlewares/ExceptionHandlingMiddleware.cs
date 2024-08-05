using Microsoft.AspNetCore.Http;

namespace LDCR.Infrastructure.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
	//private Ilogger

    public async Task Invoke(HttpContext context)
    {
		try
		{
			await _next.Invoke(context);
		}
		//catch(KeyNotFoundException)
		//{

		//}
		//catch(InvalidOperationException)
		//{

		//}
        catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
    }
}
