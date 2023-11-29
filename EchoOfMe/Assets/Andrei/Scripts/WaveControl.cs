using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject soundWavePrefab;
    [SerializeField] float maxRadius;
    [SerializeField] float waveSpeed;
    [SerializeField] Transform waveSpawnPoint;

    [Header("Misc")]
    public float currentFreq;
    GameObject newWave;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNewWave();
        } 
    }

    private void SpawnNewWave()
    {
        GameObject newWave = Instantiate(soundWavePrefab, waveSpawnPoint.position, waveSpawnPoint.rotation);
        WaveLogic waveLogic = newWave.GetComponent<WaveLogic>();
        waveLogic.maxRadius= maxRadius;
        waveLogic.waveSpeed= waveSpeed;
        newWave.transform.SetParent(waveSpawnPoint.transform);
    }
}
