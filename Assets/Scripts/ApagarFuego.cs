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
        if (other.gameObject.name.StartsWith("PcT1") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("fuego chay");
            ParticleSystem[] allParticles = other.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem ps in allParticles)
            {
                ps.Stop();
            }
        }
    }



}
