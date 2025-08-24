using UnityEngine;

public class CarritoTrigger : MonoBehaviour
{
    public JuntarComputadoras manager;

    private void OnTriggerStay(Collider other)
    {
        string nombre = other.gameObject.name;

          if (nombre.StartsWith("compu god") && Input.GetMouseButtonUp(0))
        {
            // Apagar el renderer
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null)
                rend.enabled = false;

            // Agregar al manager
            manager.AgregarComputadora(other.gameObject);
        }
        else if (nombre.StartsWith("computadora crota") && Input.GetMouseButtonUp(0))
        {
            DevolverComputadorasIncorrectas();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("compu god"))
        {
            manager.QuitarComputadora(other.gameObject);
        }
    }

    private void DevolverComputadorasIncorrectas()
    {
        manager.DevolverTodas();
        Destroy(gameObject);
    }
}
