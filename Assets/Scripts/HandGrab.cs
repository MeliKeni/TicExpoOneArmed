
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private GameObject objetoAgarrable = null;
    private GameObject objetoAgarrado = null;

    void Update()
    {
        if (objetoAgarrable != null)
        {
            // Mientras mantengas el click izquierdo
            if (Input.GetMouseButton(0))
            {
                // Agarrar
                if (objetoAgarrado == null)
                {
                    objetoAgarrado = objetoAgarrable;
                    Rigidbody rb = objetoAgarrado.GetComponent<Rigidbody>();

                    rb.isKinematic = true;
                    rb.useGravity = false;

                    objetoAgarrado.transform.SetParent(transform);
                }
            }
            else
            {
                // Soltar
                if (objetoAgarrado != null)
                {
                    Rigidbody rb = objetoAgarrado.GetComponent<Rigidbody>();

                    objetoAgarrado.transform.SetParent(null);
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

                    StartCoroutine(ActivarFisicaDespues(rb));

                    objetoAgarrado = null;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agarrable"))
        {
            objetoAgarrable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Agarrable"))
        {
            if (objetoAgarrado == null)
            {
                objetoAgarrable = null;
            }
        }
    }

    private IEnumerator ActivarFisicaDespues(Rigidbody rb)
    {
        yield return null; // Espera un frame
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
}