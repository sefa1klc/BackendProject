namespace Generics;

public class MyList<T>
{
    T[] items;
    public MyList()
    {
        items = new T[0];
    }
    void Add(T item)
    {
        T[] TempArray = items; // when we use new key, references are gone. Therefore, we need to store old array elements so that they do not go away.
        items = new T[items.Length + 1];

        for (int i = 0; i < TempArray.Length; i++)
        {
            items[i] = TempArray[i];
        }
        
        items[items.Length - 1] = item; 
    }
}