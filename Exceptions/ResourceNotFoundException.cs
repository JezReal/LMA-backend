namespace Lma_backend.Exceptions;

public class ResourceNotFoundException : Exception
{

    public ResourceNotFoundException() : base()
    {

    }
    public ResourceNotFoundException(string message) : base(message)
    {

    }

}