using System.Net;

public class BaseException : Exception
{
  public HttpStatusCode StatusCode { get; }

  public BaseException(string message, HttpStatusCode statusCode)
    : base(message)
  {
    StatusCode = statusCode;
  }
}
