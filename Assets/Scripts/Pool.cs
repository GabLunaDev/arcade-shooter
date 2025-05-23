using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Stack<T> PooledObjects;
    private T LoadedObject;

    public Pool(string path, int initialSize)
    {
        PooledObjects = new Stack<T>(initialSize);
        LoadedObject = Resources.Load<T>(path);

        for (int i = 0; i < initialSize; i++)
        {
            T obj = InstatiateObject();
            PooledObjects.Push(obj);
        }
    }

    public T Rent()
    {
        T obj;

        if (!PooledObjects.TryPop(out obj))
        {
            obj = InstatiateObject();
        }

        return obj;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(null);
        PooledObjects.Push(obj);
    }

    private T InstatiateObject()
    {
        T obj = Object.Instantiate(LoadedObject);
        obj.gameObject.SetActive(false);
        return obj;
    }
}
