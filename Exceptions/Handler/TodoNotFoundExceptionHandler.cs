using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class TodoNotFoundExceptionHandler(ILogger<TodoNotFoundExceptionHandler> logger)
  : IExceptionHandler
{
  // This class can be used to handle global exceptions in the application.
  // You can implement methods to log exceptions, return custom error responses, etc.
  public async ValueTask<bool> TryHandleAsync(
    HttpContext httpContext,
    Exception exception,
    CancellationToken cancellationToken
  )
  {
    if (exception is not TodoNotFoundException e)
    {
      return false;
    }

    var problemDetails = new ProblemDetails
    {
      Instance = httpContext.Request.Path,
      Title = e.Message,
    };
    httpContext.Response.StatusCode = (int)e.StatusCode;
    logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
    problemDetails.Status = httpContext.Response.StatusCode;
    await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    return true;
  }
}
