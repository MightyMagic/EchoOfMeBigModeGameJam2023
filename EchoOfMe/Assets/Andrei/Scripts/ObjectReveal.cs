using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReveal : MonoBehaviour
{
    [SerializeField] float delayToDisappear;

    MeshRenderer objectMesh;
    WaveControl waveControl;
    public float timer;
    public bool isHit;
    
    void Start()
    {
        objectMesh= GetComponent<MeshRenderer>();
        objectMesh.enabled=false;
        timer = 0f;
        isHit=false;
    }

    void Update()
    {
        if (isHit)
        {
            timer += Time.deltaTime;
        }

        if (timer > delayToDisappear && isHit)
        {
            isHit=false;
            objectMesh.enabled=false;
            timer= 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SoundWave")
        {
            isHit=true;
            objectMesh.enabled = true;
            timer= 0f;
        }
            
    }

    

    // too confusing to use probably
    /*

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWave")
        {
            waveControl = other.gameObject.GetComponent<PlayerWaveCollider>().waveControl;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerWave" && waveControl != null)
        {
            if (waveControl.currentFreq < 50f)
                objectMesh.enabled = true;
            else objectMesh.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerWave")
        {
            objectMesh.enabled = false;
        }
    }
    */
}
