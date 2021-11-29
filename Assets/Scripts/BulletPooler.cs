using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    public static BulletPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectsToPool;
    public int amountToPool;
    public bool shouldExpand;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            //Instanstiate bullet and set them inactive
            GameObject obj = (GameObject)Instantiate(objectsToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
       /* if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(objectsToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }*/
        
        
       GameObject obj = (GameObject)Instantiate(objectsToPool);
       pooledObjects.Add(obj);
       return obj;
        
    }

}



