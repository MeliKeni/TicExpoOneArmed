using UnityEngine;

public class IndicadorInteraccion : MonoBehaviour
{
    [Header("Referencia al objeto del Canvas que quieres mostrar")]
    public GameObject objetoCanvas;

    private void Start()
    {
        if (objetoCanvas != null)
        {
            objetoCanvas.SetActive(false); // Asegura que empieza oculto
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agarrable") || other.CompareTag("interactuable"))
        {
            if (objetoCanvas != null)
            {
                objetoCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Agarrable") || other.CompareTag("interactuable"))
        {
            if (objetoCanvas != null)
            {
                objetoCanvas.SetActive(false);
            }
        }
    }
}
