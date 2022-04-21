using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemiesList = new List<GameObject>();
    private Player player;

    [System.Serializable]
    public class EnemiesWave
    {
        public int typeOfEnemy;
        public float delay;
        public int howMany;
        public float frequency;
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public List<EnemiesWave> enemies = new List<EnemiesWave>();
        public float timeBetweenWaves;
    }

    [SerializeField] private Wave[] waves;
    [SerializeField] private int nextWave; //do testowania wybranych fal

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveCounter(waves[nextWave]));
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaveCounter(Wave wwave)
    {
        int k = 0;
        nextWave++;
        while (wwave.enemies.Count > k)
        {
            yield return new WaitForSeconds((wwave.enemies[k].delay));
            StartCoroutine(SpawnEnemy(wwave.enemies[k].howMany, wwave.enemies[k].frequency, wwave.enemies[k].typeOfEnemy));
            k++;
        }
        yield return new WaitForSeconds(wwave.timeBetweenWaves);
        if (nextWave <= 10)
            StartCoroutine(WaveCounter(waves[nextWave]));
    }

    IEnumerator SpawnEnemy(int howMany, float frequency, int typeOfEnemy)
    {
        int i = 0;
        Vector2 spawnPoint = new Vector2(0, 0);
        while (i < howMany)
        {
            if (typeOfEnemy < 3)
                spawnPoint = new Vector2(Random.Range(-5.61f, 5.61f), 9);
            if (typeOfEnemy == 3)
                spawnPoint = new Vector2(Random.Range(-4.61f, 4.61f), 6);
            if (typeOfEnemy == 4)
                spawnPoint = new Vector2(Random.Range(-3.61f, 3.61f), 7);
            Instantiate(EnemiesList[typeOfEnemy], spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(frequency);
            i++;
        }
    }
}
