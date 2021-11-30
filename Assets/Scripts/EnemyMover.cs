using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed;
    
    Rigidbody rb;


    void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.forward * speed; //enemy to move
       

    }

   

}