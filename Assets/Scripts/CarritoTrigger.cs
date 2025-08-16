using UnityEngine;

public class CarritoTrigger : MonoBehaviour
{
    public JuntarComputadoras manager;
    private void OnTriggerEnter(Collider other)
    {
        string nombre = other.gameObject.name;

        if (nombre.StartsWith("compu god"))
        {
            manager.AgregarComputadora(other.gameObject);
        }
        else if (nombre.StartsWith("computadora crota"))
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
