using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private GameObject objetoAgarrable = null;
    private GameObject objetoAgarrado = null;

    [Header("Rotación para Extintor")]
    public float rotacionYExtintor = 90f; // Ajusta en el Inspector

    void Update()
    {
        if (objetoAgarrable != null)
        {
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

                    // ✅ Si el objeto es "extintor", rotarlo
                    if (objetoAgarrado.name == "extintor")
                    {
                        objetoAgarrado.transform.localRotation = Quaternion.Euler(0f, rotacionYExtintor, 0f);
                    }
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
