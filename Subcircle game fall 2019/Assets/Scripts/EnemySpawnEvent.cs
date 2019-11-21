using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Referance to a YouTube video https://www.youtube.com/watch?v=Vrld13ypX_I
//part 2 referance https://www.youtube.com/watch?v=q0SBfDFn2Bs&t=1139s
public class EnemySpawnEvent : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count; //This is for how many enemies
        public float rate; //time between spawn enemy
    }

    public Wave[] waves;
    public float timeBetweenWaves = 5f;

    private float waveCountdown;
    private SpawnState state = SpawnState.COUNTING;
    private int nextWave = 0;
    private float searchCountdown = 1f;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        //Expected changed. This is when last wave is finish, change this to be a winning transition.
        if (nextWave + 1 > waves.Length - 1)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //There should be a next scene when building game //Update: Copy and paste script, use it if desire but otherwise, this is for when all wave is complete
        }
        else
        {
            nextWave++;
        }
    }

    //Need to debug
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}
