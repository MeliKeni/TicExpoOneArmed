using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarFuego : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        // Verifica que el nombre comience con "pc 3 TASK 1"
        if (other.gameObject.name.StartsWith("pc 3 TASK 1"))
        {
            // Si se está presionando E
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Fuego apagado");

                // Buscar todos los ParticleSystem en hijos y detenerlos
                ParticleSystem[] allParticles = other.gameObject.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem ps in allParticles)
                {
                    ps.Stop();
                }
            }
        }
    }
}
