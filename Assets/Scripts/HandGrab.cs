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
            if (Input.GetKey(KeyCode.F))
            {
                // Agarrar
                if (objetoAgarrado == null)
                {
                    objetoAgarrado = objetoAgarrable;
                    Rigidbody rb = objetoAgarrado.GetComponent<Rigidbody>();

                    // Configuración al agarrar
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

                    // Soltar y que la física actúe correctamente
                    objetoAgarrado.transform.SetParent(null);
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

                    // Opcional: asegurar que no atraviese cosas al soltar
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

    // Corutina para reactivar la física de manera segura y evitar atravesar objetos
    private IEnumerator ActivarFisicaDespues(Rigidbody rb)
    {
        yield return null; // Espera un frame
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
}
