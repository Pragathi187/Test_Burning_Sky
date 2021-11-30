using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectsToPool;
    public bool shouldExpand;
}

public class EnemyPooler : MonoBehaviour
{

  
    public static EnemyPooler SharedInstance;
    public List<GameObject> pooledObjects;
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
                //get objects and set them inactive
                GameObject obj = (GameObject)Instantiate(item.objectsToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
       
    }


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
             if (item.objectsToPool.tag == tag)
             {
                 if (item.shouldExpand)
                 {
                     GameObject obj = (GameObject)Instantiate(item.objectsToPool);
                     obj.SetActive(false);
                     pooledObjects.Add(obj);
                     return obj;
                 }
             }
         }

        return null;
    }
}
