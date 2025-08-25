using UnityEngine;

public class BrazoColision : MonoBehaviour
{
    public Transform camara;
    public float distanciaMax = 1.5f;
    public LayerMask capasBloqueo;

    void Update()
    {
        Ray ray = new Ray(camara.position, camara.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, distanciaMax, capasBloqueo))
        {
            transform.position = hit.point - camara.forward * 0.1f; // se queda antes de la pared
        }
        else
        {
            transform.position = camara.position + camara.forward * distanciaMax;
        }
    }
}
