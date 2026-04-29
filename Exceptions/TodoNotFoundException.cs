using System.Net;

public class TodoNotFoundException : BaseException
{
  public TodoNotFoundException(Guid id)
    : base($"Todo item with ID {id} not found.", HttpStatusCode.NotFound) { }
}
