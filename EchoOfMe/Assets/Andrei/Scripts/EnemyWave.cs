using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWave : MonoBehaviour
{
    [Header("References")]
    public float maxFreq;
    public float minFreq;
    public float damagePerSecond;
    [SerializeField] Slider hpBar;

    [Header("Debug display")]
    public float hp;

    void Start()
    {
        hp = 100f;
        UpdateHP();
    }

    void Update()
    {

        if(hp < 0f)
            Death();
    }

    public void GetDamagedByWave(float damagePerSecond)
    {
        hp -= damagePerSecond * Time.deltaTime;
        UpdateHP();
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

    private void UpdateHP()
    {
        hpBar.value = hp;
    }
}
