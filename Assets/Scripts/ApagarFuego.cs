using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarFuego : MonoBehaviour
{
  public PuntajeScript puntajeScript;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.StartsWith("pc 3 TASK 1"))
        {
            ParticleSystem[] allParticles = other.gameObject.GetComponentsInChildren<ParticleSystem>();
            
            foreach (ParticleSystem ps in allParticles)
            {
                if (ps.isPlaying)
                {
                    ps.Stop();
                    Debug.Log("Fuego apagado");
                    puntajeScript.SumarPuntaje(15);
                }
            }
        }
    }
}
