using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaveCollider : MonoBehaviour
{
    [Header("References")]
    public WaveControl waveControl;

    [Header("Internal")]
    private List<GameObject> enemiesInRange = new List<GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        CheckCurrentEnemies();      
    }

    // iterate through the current list and damage enemies with matching frequency, clean up all the null members
    private void CheckCurrentEnemies()
    {
        for (int i = enemiesInRange.Count - 1; i > -1; i--)
        {
            GameObject enemy = enemiesInRange[i];
            if (enemy != null)
            {
                if (enemy.GetComponent<EnemyWave>())
                {
                    EnemyWave enemyWave = enemy.GetComponent<EnemyWave>();
                    if (waveControl.currentFreq <= enemyWave.maxFreq && waveControl.currentFreq > enemyWave.minFreq)
                    {
                        enemyWave.GetDamagedByWave(enemyWave.damagePerSecond);
                    }
                }
            }
            else
               RemoveEnemy(enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            AppendEnemy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            RemoveEnemy(other.gameObject);
        }
    }

    void AppendEnemy(GameObject enemy)
    {
        enemiesInRange.Add(enemy);
    }

    void RemoveEnemy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }
}
