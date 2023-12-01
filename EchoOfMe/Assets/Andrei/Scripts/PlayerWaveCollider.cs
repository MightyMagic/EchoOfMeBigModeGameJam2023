using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaveCollider : MonoBehaviour
{
    public List<GameObject> enemiesInRange= new List<GameObject>();
    [SerializeField] WaveControl waveControl;
    void Start()
    {
        
    }

    void Update()
    {
        
        for(int i = enemiesInRange.Count - 1; i > -1; i--) 
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
                enemiesInRange.Remove(enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
