using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    Camera mainCamera;
    Camera cam;
    ObjectPooler ObjectPooler;
    private Vector2 screenBounds;
    float xMin, xMax, zMin, zMax;
    public Transform shotSpawn;
   // public Transform shotSpawnLeft;
   // public Transform shotSpawnRight;
    //private bool isMoving = false;
     Collider col;
     Vector3 pos;
    public int health = 20;
    public GameObject playerExplosion;


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
        //isMoving = true;
        
        ObjectPooler = ObjectPooler.sharedInstance;

 }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, zMin, zMax)
            );
        rb.velocity = movement * speed;
        //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    // Update is called once per frame
    public void Update()
    {
        ObjectPooler.SpawnFromPool("Bullet", shotSpawn.transform.position, shotSpawn.transform.rotation);
        //ObjectPooler.SpawnFromPool("Bullet1", shotSpwanLeft.transform.position, shotSpwanLeft.transform.rotation);
        //ObjectPooler.SpawnFromPool("Bullet2", shotSpawnRight.transform.position, shotSpawnRight.transform.rotation);


    }
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("enemyBullet"))
        {
            if (health < 0)
            {
               
                other.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                playerExplosion.transform.position = other.transform.position;
                playerExplosion.GetComponent<ParticleSystem>().Play();
                FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(1);
                
            }
            else
            {
                other.gameObject.SetActive(false);
                health -= 1;
            }



        }


    }
    
}
