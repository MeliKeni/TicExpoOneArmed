using UnityEngine;

public class ReaparecerSiCae : MonoBehaviour
{
    public float limiteY = -10f; // Si baja de este valor, reaparece
    private Vector3 posicionInicial;

    void Start()
    {
        // Guardamos la posición inicial al empezar
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Verificamos si cayó por debajo del límite
        if (transform.position.y < limiteY)
        {
            transform.position = posicionInicial;
            // Opcional: reiniciar velocidad si tiene Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
