using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private GameObject objetoAgarrable = null;
    private GameObject objetoAgarrado = null;

    [Header("Rotación Extintor")]
    public Vector3 rotacionExtintor = new Vector3(30f, 0f, 15f); // Ajustable en el Inspector

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

                    // Hacer hijo del punto para seguir la mano
                    objetoAgarrado.transform.SetParent(puntoAgarrar);

                    // ✅ NUEVO: Cambiar layer a FPS
                    int fpsLayer = LayerMask.NameToLayer("FPS");
                    if (fpsLayer != -1)
                        SetLayerRecursively(objetoAgarrado, fpsLayer);

                    // ✅ Si es el extintor, aplicar rotación especial
                    if (objetoAgarrado.name.ToLower().Contains("extintor"))
                    {
                        objetoAgarrado.transform.localRotation = Quaternion.Euler(rotacionExtintor);
                    }
                    else
                    {
                        // ✅ Para otros objetos, rotación estándar
                        objetoAgarrado.transform.Rotate(0f, 180f, 0f, Space.Self);
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

                    // ✅ NUEVO: Restaurar layer a 0 (Default)
                    SetLayerRecursively(objetoAgarrado, 0);

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

    // ✅ NUEVO: Método para cambiar layer recursivamente (objeto y sus hijos)
    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child != null)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
    }
}
