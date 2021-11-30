using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    public int health;
    public GameObject explosion;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        this.GetComponent<DestroyOnContact>().explosion = (GameObject)GameObject.Find("CartoonBlast_Fireball");
       
    }

  
    public void OnTriggerEnter(Collider other)
    {
        //check if enemies collide with playeror bullet and set them inactive and increase the score
        if (other.gameObject.tag.Equals("bullet"))
        {
            if (health < 0)
            {
                explosion.transform.position = this.transform.position;
                explosion.GetComponent<ParticleSystem>().Play();
                other.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                gameController.score += 5;
                gameController.scoreText.text = "Score: " + gameController.score.ToString();
                FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(0);


            }

            else
            {
                health -= 1;
                other.gameObject.SetActive(false);//if enemy die set it inactive
            }
        }

        if (other.gameObject.tag.Equals("Player"))
        {

            explosion.transform.position = this.transform.position;
            explosion.GetComponent<ParticleSystem>().Play();
            this.gameObject.SetActive(false);
            gameController.score += 5;
            gameController.scoreText.text = "Score: " + gameController.score.ToString();
            FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(1);

        }
    }
}
