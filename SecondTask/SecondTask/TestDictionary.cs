using System.Collections;

namespace SecondTask;

public class TestDictionary<T1, T2> : IEnumerable<TestKeyValuePairs<T1, T2>>, IEnumerator<TestKeyValuePairs<T1, T2>>
{
    private List<TestKeyValuePairs<T1, T2>> Data = new List<TestKeyValuePairs<T1, T2>>();
    private int _position = -1;
    
    
    public IEnumerator<TestKeyValuePairs<T1, T2>> GetEnumerator()
    {
        return Data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool MoveNext()
    {
        if (_position < Data.Count - 1)
        {
            _position++;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        _position = -1;
    }

    public void Add(T1 key, T2 value)
    {
        testOnKeys(key);
        Data.Add(new TestKeyValuePairs<T1, T2>(key, value));
        _position++;
    }
    
    public TestKeyValuePairs<T1, T2> Find(T1 key)
    {
        foreach (TestKeyValuePairs<T1,T2> pair in Data)
        {
            if (pair.Key.Equals(key))
                return pair;
        }

        throw new ElementNotFoundExeption();
    }
    public TestKeyValuePairs<T1, T2> Find(T2 value)
    {
        foreach (TestKeyValuePairs<T1,T2> pair in Data)
        {
            if (pair.Value.Equals(value))
                return pair;
        }

        throw new ElementNotFoundExeption();
    }
    
    public void Delete(T1 key)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            if (Data[i].Key.Equals(key))
            {
                Data.RemoveAt(i);
                return;
            }
        }

        throw new ElementNotFoundExeption();
    }
    public void Delete(T2 value)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            if (Data[i].Value.Equals(value))
            {
                Data.RemoveAt(i);
                return;
            }
        }

        throw new ElementNotFoundExeption();
    }
    private void testOnKeys(T1 key)
    {
        foreach (TestKeyValuePairs<T1,T2> pair in Data)
        {
            if (key.Equals(pair.Key))
                throw new Exception("Key already exists");
        }
    }
    public TestKeyValuePairs<T1, T2> Current
    {
        get
        {
            if (_position == -1 || _position >= Data.Count)
                throw new ArgumentException();
            return Data[_position];
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        
    }

    public void ToConsole()
    {
        foreach (TestKeyValuePairs<T1,T2> pair in Data)
        {
            pair.ToConsole();
        }
    }
}