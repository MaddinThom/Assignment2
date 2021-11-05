using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemySlow : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private Queue<GameObject> objects = new Queue<GameObject>();

    public static ObjectPoolEnemySlow Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        Instance = this;
        GrowPool();
    }
    // Get from the pool of objects
    public GameObject GetFromPool()
    {
        if (objects.Count == 0)
        {
            GrowPool();
        }

        var inst = objects.Dequeue();
        inst.SetActive(true);
        return inst;
    }

    // Add to the pool
    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var objectToAdd = Instantiate(obj);
            objectToAdd.transform.SetParent(transform);
            objectToAdd.SetActive(false);
            objects.Enqueue(objectToAdd);
        }
    }
}
