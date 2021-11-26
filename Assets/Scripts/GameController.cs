using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Vector3 spawnValues;
    private Vector2 screenBounds;
    Camera mainCamera;

    //FirePop-Ups
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //enemys
    public int enemiesPerWave=2;


    //UI elements
    public Text scoreText;
    public int score;
    void Start()
    {
        StartCoroutine("SpawnWaves");
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Invoke("Waves", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnWaves()
    {
        
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            float waveType = Random.Range(0.0f, 10.0f);


            for (int i = 0; i < hazardCount; i++)
            {


                Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, screenBounds.y + 0.3f);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject hazrad = EnemyPooler.SharedInstance.GetPooledObject("PowerUps");


                if (hazrad != null)
                {

                    hazrad.transform.position = spawnPosition;
                    hazrad.transform.rotation = spawnRotation;
                    hazrad.SetActive(true);
                }
               

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
               
    }
    IEnumerator SpawnEnemyWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            float waveType = Random.Range(0.0f, 10.0f);
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, screenBounds.y + 0.3f);
                Quaternion spawnRotation = Quaternion.identity; ;
                if (waveType >= 5.0f)
                {
                    GameObject enemy1 = EnemyPooler.SharedInstance.GetPooledObject("EnemySpaceShip");
                    if (enemy1 != null)
                    {
                        enemy1.transform.position = spawnPosition;
                        enemy1.transform.rotation = spawnRotation;
                        enemy1.SetActive(true);
                    }

                }
                else
                {
                    GameObject enemy2 = EnemyPooler.SharedInstance.GetPooledObject("EnemySpaceShip2");
                    if (enemy2 != null)
                    {
                        enemy2.transform.position = spawnPosition;
                        enemy2.transform.rotation = spawnRotation;
                        enemy2.SetActive(true);
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
}

