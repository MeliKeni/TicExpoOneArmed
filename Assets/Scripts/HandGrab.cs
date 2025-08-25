using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private GameObject objetoAgarrable = null;
    private GameObject objetoAgarrado = null;

    [Header("Rotación para Extintor")]
    public float rotacionYExtintor = 0f; // Ajusta en el Inspector si querés

    [Header("Anclaje para objetos")]
    public Transform puntoAgarrar; // Empty en la mano como punto central

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

                    // Posicionar y rotar en el centro del punto de agarre
                    objetoAgarrado.transform.position = puntoAgarrar.position;
                    objetoAgarrado.transform.rotation = puntoAgarrar.rotation;

                    // Rotar 180° en el eje Y

                    // Hacer hijo del punto para seguir la mano
                    objetoAgarrado.transform.SetParent(puntoAgarrar);

                    // Si es extintor, aplicar rotación extra
                    if (objetoAgarrado.name == "extintor")
                    {
                        objetoAgarrado.transform.localRotation = Quaternion.Euler(0f, rotacionYExtintor, 0f);
                    }
                    else                     objetoAgarrado.transform.Rotate(0f, 180f, 0f, Space.Self);

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
