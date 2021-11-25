﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public static ObjectPooler sharedInstance;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
   

    public void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();


        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        print("entered");
        //print(tag);
       if (!poolDictionary.ContainsKey(tag))
        {

            print(tag);
            Debug.LogWarning("Pool with tag" + " " +  tag  + " " + "doesn't exists");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
       
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}