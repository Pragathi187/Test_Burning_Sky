using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    Camera mainCamera;
    Camera cam;
   
    private Vector2 screenBounds;
    float xMin, xMax, zMin, zMax;
    public Transform shotSpawn;
    public Transform shotSpawnLeft;
    public Transform shotSpawnRight;
  
     Collider col;
     Vector3 pos;
    public int health = 20;
    public GameObject playerExplosion;
  
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text HealthText;
    public GameController gameController;
    
    


    // Start is called before the first frame update
    void Start()
{

        col = GetComponent<Collider>();
        cam = Camera.main;
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        xMin = -screenBounds.x;
        xMax = screenBounds.x;
        zMin = -screenBounds.y / 4;
        zMax = screenBounds.y - (screenBounds.y / 4);
        rb = this.GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        StartCoroutine("ShootBullets");
        HealthText.text = health.ToString();

    }

   

    void FixedUpdate()
    {

        //update the player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, zMin, zMax)
            );
        rb.velocity = movement * speed;
        
    }

    // Update is called once per frame
    public void Update()
    {

        HealthText.text = "Health: " + health.ToString();
       

    }
    IEnumerator  ShootBullets()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            GameObject bullet = gameObject.GetComponent<BulletPooler>().GetPooledObject();
            if (bullet != null)
            {
                
                bullet.transform.position = shotSpawn.transform.position;
                bullet.transform.rotation = shotSpawn.transform.rotation;
                bullet.SetActive(true);


              yield return new WaitForSeconds(spawnWait);
            }
          
            yield return new WaitForSeconds(waveWait);
        }
          
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("enemyBullet"))
        {
            if (health <= 0)
            {

                other.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                playerExplosion.transform.position = other.transform.position;
                playerExplosion.GetComponent<ParticleSystem>().Play();
                FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(1);
                Invoke("GameOver", 0.5f);

            }
            else
            {
                other.gameObject.SetActive(false);
                health -= 1;
            }



        }
        if (other.gameObject.tag.Equals("EnemySpaceShip"))
        {
            health -= 2;
        }

        if (other.gameObject.tag.Equals("EnemyShipSnow"))
        {
            health -= 2;
        }
        if (other.gameObject.tag.Equals("EnemyShipDessert"))
        {
            health -= 2;
        }
        if (other.gameObject.tag.Equals("EnemyShipRed"))
        {
            health -= 2;
        }

    }

 
    public void GameOver()
    {
        
        FindObjectOfType<GameController>().GetComponent<GameController>().GameOver();
    }

  
    
}
