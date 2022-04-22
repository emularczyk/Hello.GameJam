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
     //   public int spawnPoint;
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
    [SerializeField] private Animator waveAnimation
 ;

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
            StartCoroutine(SpawnEnemy(wave.enemies[k].howMany, wave.enemies[k].frequency, wave.enemies[k].typeOfEnemy, wave.enemies[k].isGroup));
            k++;
        }
        yield return new WaitForSeconds(wave.timeBetweenWaves);
        if (nextWave < waves.Length)
            StartCoroutine(WaveCounter(waves[nextWave]));
    }
    private Vector2 spawnPointSwitch(int typeOfEnemy)
    {
         Vector2 spawnPointPlace = new Vector2(Random.Range(-7.5f, 7.5f), 6.5f);

        switch (typeOfEnemy)
        {
            case (1) :spawnPointPlace = new Vector2(7.9f, Random.Range(-4, 6.5f)); break;
            case (2): spawnPointPlace = new Vector2(-7.9f, Random.Range(-4, 6.5f)); break;
            case (3): spawnPointPlace = new Vector2(Random.Range(-6, 6), -5.5f); break;
           /* case (5): spawnPointPlace = new Vector2(7.9f, 3.5f); break;
            case (6): spawnPointPlace = new Vector2(-7.0f, 3.5f); break;*/
        }
        return spawnPointPlace;
    }

    IEnumerator SpawnEnemy(int howMany, float frequency, int typeOfEnemy,bool isGroup)
    {
        int i = 0;
        Vector2 spawnPointPlace;
        spawnPointPlace = spawnPointSwitch(typeOfEnemy%4);
        while (i < howMany)
        {

            Instantiate(EnemiesList[typeOfEnemy], spawnPointPlace, Quaternion.identity);
            yield return new WaitForSeconds(frequency);
            if(!isGroup)
            spawnPointPlace = spawnPointSwitch(typeOfEnemy % 4);
            i++;
        }
    }

    private void WaveTextDisplay(string name)
    {
        waveText.text = name;
        waveAnimation.SetTrigger("WaveNr");

    }
}
