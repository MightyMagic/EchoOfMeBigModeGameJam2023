using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] EnemyWave enemyWave;
    [SerializeField] GameObject soundWavePrefab;
    [SerializeField] float maxRadius;
    [SerializeField] float minRadius;
    [SerializeField] float waveSpeed;
    [SerializeField] Transform waveSpawnPoint;


    [Header("Internal")]
    public float frequency;
    float timer;

    void Start()
    {
        timer = 0f;
        frequency = enemyWave.minFreq + (enemyWave.maxFreq - enemyWave.minFreq) / 2;
    }

    void Update()
    {
        if(timer < frequency)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            EnemySpawnWave();
        }
    }

    public void EnemySpawnWave()
    {
        GameObject newWave = Instantiate(soundWavePrefab, waveSpawnPoint.position, waveSpawnPoint.rotation);
        WaveLogic waveLogic = newWave.GetComponent<WaveLogic>();
        waveLogic.maxRadius = maxRadius;
        waveLogic.minRadius = minRadius;
        waveLogic.waveSpeed = waveSpeed;
        newWave.transform.SetParent(waveSpawnPoint.transform);
    }
}
