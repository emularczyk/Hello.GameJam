using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemiesList = new List<GameObject>();
    private Player player;

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
        public float timeBetweenWaves;
    }

    [SerializeField] private Wave[] waves;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Animator waveAnimation;

     public float topWall=12.5f;
     public float bottomWall=-9;
     public float rightWall=8;
     public float leftWall=-8;


    //do testowania wybranych fal
    [SerializeField] private int nextWave;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveCounter(waves[nextWave]));
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player").GetComponent<Player>();
    }

    IEnumerator WaveCounter(Wave wave)
    {
        int k = 0;
        nextWave++;
        WaveTextDisplay(wave.name);
        while (wave.enemies.Count > k)
        {
            yield return new WaitForSeconds((wave.enemies[k].delay));
            StartCoroutine(SpawnEnemy(wave,k));
            k++;
        }
        yield return new WaitForSeconds(wave.timeBetweenWaves);
        if (nextWave < waves.Length)
            StartCoroutine(WaveCounter(waves[nextWave]));
    }


    IEnumerator SpawnEnemy(Wave wave,int iteration)
    {
        int i = 0;
        Vector2 spawnPointPlace;
        spawnPointPlace = spawnPointSwitch(wave.enemies[iteration].spawnPoint, wave.enemies[iteration].typeOfEnemy);
        while (i < wave.enemies[iteration].howMany)
        {

            Instantiate(EnemiesList[wave.enemies[iteration].typeOfEnemy], spawnPointPlace, Quaternion.identity);
            yield return new WaitForSeconds(wave.enemies[iteration].frequency);
            if(!wave.enemies[iteration].isGroup)
                spawnPointPlace = spawnPointSwitch(wave.enemies[iteration].spawnPoint, wave.enemies[iteration].typeOfEnemy);
            i++;
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
            case (6): spawnPointPlace = new Vector2(0, topWall - 0.1f); break;
            case (7): spawnPointPlace = new Vector2(-3, topWall - 0.1f); break;
            case (8): spawnPointPlace = new Vector2(3, topWall - 0.1f); break;
            case (9): spawnPointPlace = new Vector2(rightWall - 0.2f, topWall - 2.5f); break; // fala 2
            case (10): spawnPointPlace = new Vector2(leftWall + 0.2f, topWall - 5.5f); break; // fala 2
            case (11): spawnPointPlace = new Vector2(-6, topWall - 0.1f); break; // fala 3
            case (12): spawnPointPlace = new Vector2(6, topWall - 0.3f); break; // fala 3
            case (13): spawnPointPlace = new Vector2(0, topWall - 0.1f); break; // fala 3
            case (14): spawnPointPlace = new Vector2(7, topWall - 0.3f); break; // fala 4
            case (15): spawnPointPlace = new Vector2(4, bottomWall + 0.1f); break; // fala 4
            case (16): spawnPointPlace = new Vector2(-3, bottomWall + 0.01f); break; // fala 4
            case (17): spawnPointPlace = new Vector2(1, topWall - 0.1f); break; // fala 4
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
