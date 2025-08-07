
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
            if (Input.GetKey(KeyCode.E))
            {
                if (!particulas.isPlaying)
                    particulas.Play();
            }
            else
            {
                if (particulas.isPlaying)
                    particulas.Stop();
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
