using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    [SerializeField]
    private GameObject obj; 

    private Queue<GameObject> objects = new Queue<GameObject>();

    public static ObjectPool Instance 
    {
        get;
        private set;
    } 
    void Awake() { 
        Instance = this;
        GrowPool();
    } 
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

    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var objectToAdd = Instantiate(obj);
            objectToAdd.transform.SetParent(transform);
            //AddToPool(instanceToAdd);
            objectToAdd.SetActive(false);
            objects.Enqueue(objectToAdd);
        }
    }

//public void AddToPool(GameObject instance)
    //{ 
        //instance.SetActive(false);
        //availableObjects.Enqueue(instance);
    //}
}
