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
    private bool isMoving = false;
    public bool gameOver = false;
    Collider col;
    Vector3 pos;
   
    public float fireRate;
    private float nextFire;

    
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
        isMoving = true;
        //activePlayerTurrets = new List<GameObject>();
        //activePlayerTurrets.Add(startWeapon);
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
        print("start");


      /*  if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                nextFire = Time.time + fireRate;
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = shotSpawn.transform.position;
                    bullet.transform.rotation = shotSpawn.transform.rotation;
                    bullet.SetActive(true);
                }

            }
        
        */

    }
   // void Shoot()
    
        /*foreach (GameObject turret in activePlayerTurrets)
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = turret.transform.position;
                bullet.transform.rotation = turret.transform.rotation;
                bullet.SetActive(true);
            }
        }*/
       
    
    
}

