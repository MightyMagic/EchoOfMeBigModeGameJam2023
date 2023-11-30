using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLogic : MonoBehaviour
{
    public float maxRadius;
    public float waveSpeed;

    float timer;
    Vector3 currentScale;

    void Start()
    {
        currentScale = 0.1f * Vector3.one;
        timer = 0.05f;
    }

    void Update()
    {
        if(maxRadius > 0f)
        {
            PlayWave();
        }
    }

    private void PlayWave()
    {
        // increasing the size according to speed

        timer += Time.deltaTime;

        currentScale = currentScale * (1f + waveSpeed * timer);
        transform.localScale = currentScale;

        // destroy when grew big enough
        if(transform.localScale.x > maxRadius && maxRadius > 0f)
        {
            Destroy(this.gameObject);
        }
        
    }
}
