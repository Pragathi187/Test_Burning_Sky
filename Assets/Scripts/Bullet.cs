using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    public float zforce = 5f;

    public void OnObjectSpawn()
    {
        Vector3 force = new Vector3(0, 0, zforce);
        GetComponent<Rigidbody>().velocity = force;
    }
}
