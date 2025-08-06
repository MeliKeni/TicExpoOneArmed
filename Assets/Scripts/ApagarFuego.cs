using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarFuego : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("CubeTask1") && Input.GetKey(KeyCode.E))
        {
            ParticleSystem[] allParticles = other.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem ps in allParticles)
            {
                ps.Stop();
            }
        }
    }



}
