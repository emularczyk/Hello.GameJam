using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemiesList = new List<GameObject>();
    [SerializeField] private List<GameObject> RainbowShards = new List<GameObject>();
    [SerializeField] public List<GameObject> RainbowShardsTexts = new List<GameObject>();

    private Player player;


    [SerializeField] private Image fill;
    [SerializeField] private Image doggo;
    [SerializeField] private Image border;

    public  int  spawnedEnemies; // are all enemies destroyed? wait until next wave
    private bool isReadyShard;
    public bool isReady;

    [System.Serializable]
    public class EnemiesWave
    {
        public float delay;
        public float frequency;
        public int typeOfEnemy;
        public int howMany;
        public int spawnPoint;
        public bool isGroup;
    }


    [System.Serializable]
    public class Wave
    {
        public string name;
        public List<EnemiesWave> enemies = new List<EnemiesWave>();
        public int timeBetweenWaves;
    }

    [SerializeField] private Wave[] waves;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Animator waveAnimation;

     private float topWall;
    private float bottomWall;
    private float rightWall;
    private float leftWall;
    private Monitor monitor;

    //do testowania wybranych fal
    [SerializeField] private int actualWave;


    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
        isReadyShard = false;
        spawnedEnemies = 0;
        //StartCoroutine(WaveCounter(waves[nextWave]));
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(CheckReadyToNextWave());

        monitor=GetComponent<Monitor>();

        topWall = monitor.topWall;
        bottomWall = monitor.bottomWall;
        rightWall = monitor.rightWall;
        leftWall = monitor.leftWall;
        doggo.enabled = false;
        fill.enabled = false;
        border.enabled = false;
    }

    IEnumerator CheckReadyToNextWave()
    {
        if (isReady && actualWave < waves.Length && spawnedEnemies <=0)
        {
            spawnedEnemies = 0;
            isReady = false;
            StartCoroutine(isReadyShardWaint());
            startNextWave();
        }
        if (isReadyShard && spawnedEnemies <= 0)
        {
            spawnedEnemies = 0;
            isReadyShard = false;
            if(actualWave < 7 )
                spawnShard(actualWave-1);
            else 
                SceneManager.LoadScene("Credits");
        }
        yield return new WaitForSeconds(3);
       print("NumberOfEnemy:" + spawnedEnemies+" isReady"+ isReady+" isShardReady" + isReadyShard); //test
        StartCoroutine(CheckReadyToNextWave()); 
    }
    IEnumerator isReadyShardWaint()
    {
        yield return new WaitForSeconds(waves[actualWave].timeBetweenWaves);
        isReadyShard = true;
    }
    void spawnShard(int shurdNumber)
    {
        Vector2 spawnPoint = new Vector2(0, topWall - 0.1f);
        Instantiate(RainbowShards[shurdNumber], spawnPoint, Quaternion.identity);
        if(shurdNumber < 5)
        {
            RainbowShardsTexts[shurdNumber].gameObject.SetActive(true);
        }
    }
    void startNextWave()
    {

        WaveTextDisplay((waves[actualWave].name));
        for(int i=0;i< waves[actualWave].enemies.Count;i++)
        {
            StartCoroutine(SpawnEnemy(waves[actualWave], i));
        }
        actualWave++;
    }
    IEnumerator SpawnEnemy(Wave wave,int iteration)
    {
        yield return new WaitForSeconds(wave.enemies[iteration].delay);
        Vector2 spawnPointPlace = spawnPointSwitch(wave.enemies[iteration].spawnPoint, wave.enemies[iteration].typeOfEnemy);
       for(int i=0;i < wave.enemies[iteration].howMany;i++)
        {
            Instantiate(EnemiesList[wave.enemies[iteration].typeOfEnemy], spawnPointPlace, Quaternion.identity);
            spawnedEnemies++;
            yield return new WaitForSeconds(wave.enemies[iteration].frequency);
            if(!wave.enemies[iteration].isGroup)
                spawnPointPlace = spawnPointSwitch(wave.enemies[iteration].spawnPoint, wave.enemies[iteration].typeOfEnemy);
        }
    }

    private Vector2 spawnPointSwitch(int spawnPoint,int typeOfEnemy)
    {
        Vector2 spawnPointPlace;
        if (spawnPoint == 0)
            spawnPoint =( typeOfEnemy % 4);
        switch (spawnPoint)
        {
            case (1): spawnPointPlace = new Vector2(rightWall - 0.1f, Random.Range(bottomWall + 2, topWall - 2)); break; // fala 5
            case (2): spawnPointPlace = new Vector2(leftWall + 0.1f, Random.Range(bottomWall + 2, topWall - 2)); break; // fala 5
            case (3): spawnPointPlace = new Vector2(Random.Range(leftWall + 0.1f, rightWall - 0.1f), bottomWall + 0.1f); break;
            case (4): spawnPointPlace = new Vector2(rightWall - 0.1f, topWall - 3.5f); break;
            case (5): spawnPointPlace = new Vector2(leftWall - 0.1f, topWall - 3.5f); break;
            case (6): spawnPointPlace = new Vector2(0, topWall +1); break;//fala1
            case (7): spawnPointPlace = new Vector2(-3, topWall +1); break;
            case (8): spawnPointPlace = new Vector2(3, topWall - 0.1f); break;
            case (9): spawnPointPlace = new Vector2(rightWall - 0.2f, topWall - 2.5f); break; // fala 2
            case (10): spawnPointPlace = new Vector2(leftWall + 0.2f, topWall - 5.5f); break; // fala 2
            case (11): spawnPointPlace = new Vector2(-6, topWall - 0.1f); break; // fala 3
            case (12): spawnPointPlace = new Vector2(6, topWall - 0.3f); break; // fala 3
            case (13): spawnPointPlace = new Vector2(0, topWall - 0.1f); break; // fala 3
            case (14): spawnPointPlace = new Vector2(8.5f, topWall - 0.3f); break; // fala 4
            case (15): spawnPointPlace = new Vector2(4.2f, bottomWall + 0.1f); break; // fala 4
            case (16): spawnPointPlace = new Vector2(-4.2f, bottomWall + 0.01f); break; // fala 4
            case (17): spawnPointPlace = new Vector2(0, topWall - 0.1f); break; // fala 4
            case (18): spawnPointPlace = new Vector2(-8.5f, topWall - 0.1f); break; // fala 4
            case (19): spawnPointPlace = new Vector2(rightWall - 0.1f, topWall - 6.5f); break;//boss
            default: spawnPointPlace = new Vector2(Random.Range(leftWall + 0.1f, rightWall - 0.1f), topWall - 0.1f); break;
        }
        return spawnPointPlace;
    }

    private void WaveTextDisplay(string name)
    {
        waveText.text = name;
        waveAnimation.SetTrigger("WaveNr");

    }
}
