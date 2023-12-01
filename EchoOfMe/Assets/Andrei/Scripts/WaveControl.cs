using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    float freqTimer;
    GameObject newWave;

    private void Start()
    {
        freqTimer = 0.01f;
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNewWave();
        }
       
       //FrequencyCount();
    }

    private void SpawnNewWave()
    {
        GameObject newWave = Instantiate(soundWavePrefab, waveSpawnPoint.position, waveSpawnPoint.rotation);
        WaveLogic waveLogic = newWave.GetComponent<WaveLogic>();
        waveLogic.maxRadius= maxRadius;
        waveLogic.waveSpeed= waveSpeed;
        newWave.transform.SetParent(waveSpawnPoint.transform);

        AppendNewWave();
    }

    void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.fontSize = 20;

        Rect labelRect = new Rect(10, 10, 500, 30);

        GUI.Label(labelRect, "Current wave frequency: " + currentFreq.ToString("F2"), labelStyle);
    }

    private void AppendNewWave()
    {
        currentFreq = Time.time - freqTimer;
        freqTimer = Time.time;
    }
}
