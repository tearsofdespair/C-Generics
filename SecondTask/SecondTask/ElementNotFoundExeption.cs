namespace SecondTask;

public class ElementNotFoundExeption : Exception
{
    public override string Message { get; } = "Element not found";
}