using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// serializable allows us to make instances of this class editable from the inspector
[System.Serializable]
public class ObjectPoolItem
{
    public bool shouldExpand;
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler SharedInstance;
    [Space(15)]
    public List<GameObject> pooledObjects;
    public List<GameObject> activeObjects;
    public List<ObjectPoolItem> itemsToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }


    // a public method that returns a gameobject from the pooleObjects list
    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    public GameObject GetActiveObject(string name)
    {
        for (int i = 0; i < activeObjects.Count; i++)
        {
            if (activeObjects[i].activeInHierarchy && activeObjects[i].name == name)
            {
                GameObject desiredObject = activeObjects[i];
                activeObjects.Remove(activeObjects[i]);
                return desiredObject;
                
            }
        }
        return null;
    }
}
