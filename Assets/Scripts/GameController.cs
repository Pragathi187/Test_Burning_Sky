using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Vector3 spawnValues;
    private Vector2 screenBounds;
    Camera mainCamera;

    //FirePop-Ups
    public int hazardCount;
    public float powerUpSpwanWait;
    public float powerUpstart;
    public float powerUpwavewait;

    //For Enemies
    float spawnWait = 1f;
    float startWait = 1f;
    float waveWait = 4f;
    //enemys
    public int enemiesPerWave=2;


    //UI elements
    public Text scoreText;
    public int score;
    public Text highScore;
    public Text powerUpText;
    public int powerUpScore;
    public Text replayButtonText;


    //gameobjects
    public GameObject gameOverPanel;
   
    public PlayerController playerController;
    

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore,0").ToString();
        playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Invoke("Waves", 1f);
        StartCoroutine("SpawnPoweUps");
    }


    IEnumerator SpawnPoweUps()
    {

        yield return new WaitForSeconds(powerUpstart);
        while (true)
        {


            for (int i = 0; i < hazardCount; i++)
            {


                Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, screenBounds.y + 0.3f);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject hazrad = gameObject.GetComponent<BulletPooler>().GetPooledObject(); ;


                if (hazrad != null)
                {

                    hazrad.transform.position = spawnPosition;
                    hazrad.transform.rotation = spawnRotation;
                    hazrad.SetActive(true);
                }


                yield return new WaitForSeconds(powerUpSpwanWait);
            }
            yield return new WaitForSeconds(powerUpwavewait);
        }

    }



    //spawing enemies based on tags randomly
    IEnumerator SpawnEnemyWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            float waveType = Random.Range(1.0f, 10.0f);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                
 
                if (waveType <= 3.0f)
                {

                    Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, screenBounds.y + 0.3f);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject enemy1 = EnemyPooler.SharedInstance.GetPooledObject("EnemySpaceShip"); ;
                    if (enemy1 != null)
                    {
                        enemy1.transform.position = spawnPosition;
                        enemy1.transform.rotation = spawnRotation;
                        enemy1.SetActive(true);
                    }

                }
                if ((waveType > 3.0f ) || (waveType >= 6.0f))
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, screenBounds.y + 0.3f);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject enemy2 = EnemyPooler.SharedInstance.GetPooledObject("EnemyShipSnow");
                    if (enemy2 != null)
                    {
                        
                        enemy2.transform.position = spawnPosition;
                        enemy2.transform.rotation = spawnRotation;
                        enemy2.SetActive(true);
                    }
                }
                if (score==20)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, screenBounds.y + 0.3f);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject enemy5 = EnemyPooler.SharedInstance.GetPooledObject("EnemyShipRed");
                    if (enemy5 != null)
                    {

                        enemy5.transform.position = spawnPosition;
                        enemy5.transform.rotation = spawnRotation;
                        enemy5.SetActive(true);
                    }
                }
                else
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, screenBounds.y + 0.3f);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject enemy3 = EnemyPooler.SharedInstance.GetPooledObject("EnemyShipDessert");
                    if (enemy3 != null)
                    {
                        
                        enemy3.transform.position = spawnPosition;
                        enemy3.transform.rotation = spawnRotation;
                        enemy3.SetActive(true);
                    }
                }
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

        
       
    }


  
    public void Waves()
    {
        StartCoroutine("SpawnEnemyWaves");
       
    }

    //game over panel once the player gets dead
    public void GameOver()
    {
        if(powerUpScore>10)
        {
            replayButtonText.text = "Use" + "       " + powerUpScore.ToString() + " " + "To continue";
        }
       
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        if (score > PlayerPrefs.GetInt("HighScore",0) )
        {
            PlayerPrefs.SetInt("HighScore", score);
            

        }
        highScore.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
    
    //to start over the game again
    public void Replay()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //exit the game
    public void Exit()
    {
        Application.Quit();
    }
}

