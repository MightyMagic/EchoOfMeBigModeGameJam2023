using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject soundWavePrefab;
    [SerializeField] float maxRadius;
    [SerializeField] float minRadius;
    [SerializeField] float waveSpeed;
    [SerializeField] Transform waveSpawnPoint;

    [Header("Debug")]
    public float currentFreq;
    public float freqTimer;

    [Header("Misc")]
    GameObject newWave;

    private void Start()
    {
        freqTimer = 5f;
        ResetFrequency();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNewWave();
            CalculateCurrentFrequency();
        }

        ResetFrequency();
    }

    public void SpawnNewWave()
    {
        GameObject newWave = Instantiate(soundWavePrefab, waveSpawnPoint.position, waveSpawnPoint.rotation);
        WaveLogic waveLogic = newWave.GetComponent<WaveLogic>();
        AssignValues(waveLogic);
        newWave.transform.SetParent(waveSpawnPoint.transform);    
    }

    private void AssignValues(WaveLogic waveLogic)
    {
        waveLogic.maxRadius = maxRadius;
        waveLogic.minRadius = minRadius;
        waveLogic.waveSpeed = waveSpeed;
    }

    // reset the frequency value after some time if the waves aren't launched anymore

    private void ResetFrequency()
    {
        if(Time.time - freqTimer > 1.5f)
            currentFreq = 5f;
    }


    // during each wave we update the frequency basically by measuring the time difference between the previous wave
    private void CalculateCurrentFrequency()
    {   
        currentFreq = Time.time - freqTimer;
        UpdateWaveFreq();
    }

    private void UpdateWaveFreq()
    {
        freqTimer = Time.time;
    }

    void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.fontSize = 20;

        Rect labelRect = new Rect(10, 10, 500, 30);

        GUI.Label(labelRect, "Current wave frequency: " + currentFreq.ToString("F2"), labelStyle);
    }

    public enum Character
    {
        Player,
        Enemy
    }
}
