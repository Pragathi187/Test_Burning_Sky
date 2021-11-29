using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{

    float moveSpeed = 2f;
    public GameObject player;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        GameObject target = player;
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
