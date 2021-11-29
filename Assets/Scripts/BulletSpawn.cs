using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float speed;
     Rigidbody rb;


    void OnEnable()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
      
       
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "enemyBullet")
        {
            collision.gameObject.SetActive(false);
        }
    }
}