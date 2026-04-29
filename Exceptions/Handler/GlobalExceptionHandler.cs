using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
  // This class can be used to handle global exceptions in the application.
  // You can implement methods to log exceptions, return custom error responses, etc.
  public async ValueTask<bool> TryHandleAsync(
    HttpContext httpContext,
    Exception exception,
    CancellationToken cancellationToken
  )
  {
    var problemDetails = new ProblemDetails { Instance = httpContext.Request.Path };
    if (exception is BaseException e)
    {
      httpContext.Response.StatusCode = (int)e.StatusCode;
      problemDetails.Title = e.Message;
    }
    else
    {
      problemDetails.Title = exception.Message;
    }

    logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
    problemDetails.Status = httpContext.Response.StatusCode;
    await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    return true;
  }
}
