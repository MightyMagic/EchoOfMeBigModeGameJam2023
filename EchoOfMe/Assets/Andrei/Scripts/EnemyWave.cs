using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWave : MonoBehaviour
{
    public float maxFreq;
    public float minFreq;
    public float damagePerSecond;
    [SerializeField] Slider hpBar;

    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        UpdateHP();
    }

    // Update is called once per frame
    void Update()
    {

        if(hp < 0f)
            Death();
    }

    public void GetDamagedByWave(float damagePerSecond)
    {
        hp -= damagePerSecond * Time.deltaTime;
        UpdateHP();
        //Destroy(this.gameObject);
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
