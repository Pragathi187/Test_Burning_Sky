using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    public int health;
    public GameObject explosion;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("bullet"))
        {
            if (health < 0)
            {
                explosion.transform.position = this.transform.position;
                explosion.GetComponent<ParticleSystem>().Play();
                other.gameObject.SetActive(false);
                this.gameObject.SetActive(false);


            }

            else
            {
                health -= 1;
                other.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.tag.Equals("Player"))
        {

            explosion.transform.position = this.transform.position;
            explosion.GetComponent<ParticleSystem>().Play();
            this.gameObject.SetActive(false);

            
        }
    }
}
