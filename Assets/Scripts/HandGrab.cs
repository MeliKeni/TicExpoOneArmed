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
                if (objetoAgarrado == null)
                {
                    objetoAgarrado = objetoAgarrable;
                    objetoAgarrado.transform.SetParent(transform);
                    objetoAgarrado.GetComponent<Rigidbody>().isKinematic = true; 
                }
            }
            else
            {
                if (objetoAgarrado != null)
                {
                    objetoAgarrado.transform.SetParent(null);
                    objetoAgarrado.GetComponent<Rigidbody>().isKinematic = false;
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
}

