using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float tumble;
    public Rigidbody rb;
    public float speed;
    public GameController gameController;
    private float startWait=0.5f;
    private int spawnWait=1;
    private int waveWait=4;
    public int hazardCount;
   // private Vector2 screenBounds;

    void Start()
    {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        
        rb.velocity = -transform.forward * speed;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag.Equals("bullet"))
        {
          this.gameObject.SetActive(false);
            gameController.powerUpScore += 2;
            gameController.powerUpText.text = gameController.powerUpScore.ToString();

        }

        if (other.gameObject.tag.Equals("Player"))
        {
            this.gameObject.SetActive(false);
            gameController.powerUpScore += 2;
            gameController.powerUpText.text = gameController.powerUpScore.ToString();

        }
        if (other.gameObject.tag.Equals("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.tag.Equals("enemyBullet"))
        {
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.tag.Equals("EnemyShipSnow"))
        {
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.tag.Equals("EnemyShipDessert"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
