using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PooledObject objectToPool;

    private List<PooledObject> objectPool = new List<PooledObject>();
    private List<PooledObject> usedPool = new List<PooledObject>();

    // Start is called before the first frame update
    void Start()
    {
        InitializePool(15);
    }

    public void AddNewObject()
    {
        PooledObject obj = Instantiate(objectToPool, transform);
        objectPool.Add(obj);
        obj.SetObjectPool(this);
        obj.gameObject.SetActive(false);
    }

    public void InitializePool(int amountToPool)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            AddNewObject();
        }
    }

    public PooledObject GetPooledObject()
    {
        if (objectPool.Count == 0)
        {
            AddNewObject();
        }
        PooledObject obj = objectPool[0];
        usedPool.Add(obj);
        objectPool.RemoveAt(0);
        return obj;
    }

    public void RestoreObject(PooledObject obj)
    {
        objectPool.Add(obj);
        usedPool.RemoveAt(0);
        obj.gameObject.SetActive(false);
    }
}
