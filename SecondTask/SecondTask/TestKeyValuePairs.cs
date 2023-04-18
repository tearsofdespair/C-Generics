namespace SecondTask;

public class TestKeyValuePairs<T1, T2>
{
    public T1 Key { get; private set; }
    public T2 Value { get; private set; }

    public TestKeyValuePairs(T1 key, T2 value)
    {
        Key = key;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Key} - {Value}";
    }


    public void ToConsole()
    {
        Console.WriteLine($"{Key} - {Value}");
    }
}