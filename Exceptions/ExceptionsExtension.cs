public static class ExceptionExtension
{
  public static void AddExceptionHandlers(this IServiceCollection services)
  {
    services.AddExceptionHandler<TodoNotFoundExceptionHandler>();
    services.AddExceptionHandler<GlobalExceptionHandler>();
    services.AddProblemDetails();
  }
}
