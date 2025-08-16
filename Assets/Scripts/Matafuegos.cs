using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matafuegos : MonoBehaviour
{
    public ParticleSystem particulas;
    private bool dentroDelTriggerMano = false;
    private Vector3 posicionOriginalMatafuegos;

    void Start()
    {
        particulas.Stop();
        posicionOriginalMatafuegos = transform.position;
    }

    void Update()
    {
        if (dentroDelTriggerMano)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (particulas.isPlaying)
                    particulas.Stop();
                else
                    particulas.Play();
            }
        }
        else
        {
            if (particulas.isPlaying)
                particulas.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            dentroDelTriggerMano = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            dentroDelTriggerMano = false;
        }
    }
}
