using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class SpawnEnemy
    {
        public Transform enemy;
        public Transform spawnPoint;
    }


    [System.Serializable]
    public class Wave
    {
        public string name;
        public SpawnEnemy[] spawnEnemy;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;
    public GameObject PlayerWinner;
    /*public GameObject LeftStick;
    public GameObject ButtonSouth;*/

    public float timeBetweenWaves = 3f;
    public float waveCountdown;


    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            { return; }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown = waveCountdown - Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Complete!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            Time.timeScale = 0f;
            /*LeftStick.SetActive(false);
            ButtonSouth.SetActive(false);*/
            PlayerWinner.SetActive(true);

        }
        else
        { nextWave++; }
    }

    bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("enemy") == null) return false; 
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        Spawn(_wave.spawnEnemy);
        yield return new WaitForSeconds(1f/_wave.rate);

        state = SpawnState.WAITING;

        yield break;
    }

    void Spawn(SpawnEnemy[] spawnEnemies)
    {
        for(int i = 0; i<spawnEnemies.Length; i++)
        {
            Instantiate(spawnEnemies[i].enemy, spawnEnemies[i].spawnPoint.position, spawnEnemies[i].enemy.rotation);
        }
    }
}
