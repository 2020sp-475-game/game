using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game Objects
    //public GameObject weapon;
    //public GameObject player;

    /*****************Spawning*******************/
    // public GameObjects
    public GameObject Top, Middle, Bottom, Pink;
    public GameObject greenBlob, greenBlobVar, redBlob;
    public Text WaveTitle, ScoreTitle, EndScore, PauseScore;

    // private primitives
    private float minSpawnDelay = 1f;
    private float maxSpawnDelay = 4f;
    private float spawnBoxLimit = 2f;
    private double spawnLimit;
    private int enemiesSpawned;
    private float timeBetweenWaves = 10f;
    private int waveNumber = 1;
    

    // public primitives
    public bool startingNextWave = false;
    public int enemiesAlive;
    public int score = 0;

    // private data structures
    private Queue<GameObject> spawnPoints = new Queue<GameObject>();
    private List<GameObject> enemyCollection = new List<GameObject>();
    /********************************************/

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        WaveTitle.text = "Wave " + waveNumber;
        ScoreTitle.text = "Score: " + score;
        spawnLimit = 8;
        setUpStructures();
        StartCoroutine(Spawner());
    }

    private void setUpStructures ()
    {
        // spawnPoints
        spawnPoints.Enqueue(Top);
        spawnPoints.Enqueue(Middle);
        spawnPoints.Enqueue(Bottom);
        spawnPoints.Enqueue(Pink);

        // enemyCollection
        enemyCollection.Add(greenBlob);
        enemyCollection.Add(greenBlobVar);
        enemyCollection.Add(redBlob);
        enemyCollection.Add(redBlob);
        enemyCollection.Add(greenBlob);
        enemyCollection.Add(greenBlob);
        enemyCollection.Add(greenBlobVar);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTitle.text = "Score: " + score;
        EndScore.text = "Score: " + score;
        PauseScore.text = "Score: " + score;
    }

    private IEnumerator Spawner ()
    {
        while (true)
        {
            yield return spawnEnemies ();
            print (enemiesSpawned);
            yield return new WaitWhile(enemyIsAlive);
            prepNextWave ();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private IEnumerator spawnEnemies () 
    {
        while (enemiesSpawned < spawnLimit)
        {
            Spawn();
            enemiesSpawned++;
            enemiesAlive++;
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        } 
    }

    private void Spawn ()
    {
        // Get next spawn point
        GameObject nextSpawnPoint = spawnPoints.Dequeue();

        // Spawning logic
        float randomX = Random.Range(-spawnBoxLimit, spawnBoxLimit);
        float randomY = Random.Range(-spawnBoxLimit, spawnBoxLimit);
        Vector3 spawnPos = nextSpawnPoint.transform.position + new Vector3 (randomX, randomY, 0);
        GameObject enemy = chooseRandomEnemy ();
        Instantiate (enemy, spawnPos, Quaternion.identity);

        spawnPoints.Enqueue (nextSpawnPoint);
    }

    private GameObject chooseRandomEnemy ()
    {
        int index = Random.Range(0, enemyCollection.Count - 1);
        return enemyCollection[index];
    }

    private bool enemyIsAlive ()
    {
        return enemiesAlive > 0;
    }

    private void prepNextWave ()
    {
        waveNumber++;
        WaveTitle.text = "Wave " + waveNumber;
        enemiesSpawned = 0;
        scaleEnemies ();
        // Wave Scaling
        if (spawnLimit < 30) {
            spawnLimit = spawnLimit * 1.5;
        } else if (spawnLimit >= 30 && spawnLimit < 60) {
            spawnLimit = spawnLimit * 2;
        } else {
            spawnLimit = spawnLimit * 3;
        }
    }

    private void scaleEnemies ()
    {
        scaleBlobs(greenBlob, "green");
        scaleBlobs(greenBlobVar, "var");
        scaleBlobs(redBlob, "red");
    }

    private void scaleBlobs(GameObject Blob, string type)
    {
        float maxHealth = Blob.GetComponent<SlimeEnemy>().maxHealth;
        float damage = Blob.GetComponent<SlimeEnemy>().damage;

        switch (type)
        {
            case "green":
                if(maxHealth < 250)
                {
                    maxHealth = maxHealth * 1.3f;
                    damage = damage * 1.3f;
                }
                break;
            case "var":
                if(maxHealth < 200)
                {
                    maxHealth = maxHealth * 1.25f;
                    damage = damage * 1.3f;
                }
                break;
            case "red":
                if(maxHealth < 400)
                {
                    maxHealth = maxHealth * 1.25f;
                    damage = damage * 1.25f;
                }
                break;
        }
        
        Blob.GetComponent<SlimeEnemy>().maxHealth = maxHealth;
        Blob.GetComponent<SlimeEnemy>().health = maxHealth;
        Blob.GetComponent<SlimeEnemy>().damage = damage;
    }
}
