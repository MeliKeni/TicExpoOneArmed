using UnityEngine;

public class CarritoTrigger : MonoBehaviour
{
    public JuntarComputadoras manager; // arrastrás el GameObject con el script JuntarComputadora
    public string filtroNombre = "compu god"; // lo que acepta este carrito
    public GameObject prefabExplosion; // arrastrás un prefab de partículas de explosión (opcional)

    private void OnTriggerEnter(Collider other)
    {
        string nombre = other.gameObject.name.ToLower();

        if (nombre.StartsWith(filtroNombre.ToLower()))
        {
            // ✅ Computadora correcta
            manager.AgregarComputadora(other.gameObject);
        }
        else if (nombre.StartsWith("compu")) // ❌ Es una compu pero no la correcta
        {
            ExplotaCarrito();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.ToLower().StartsWith(filtroNombre.ToLower()))
        {
            manager.QuitarComputadora(other.gameObject);
        }
    }

    private void ExplotaCarrito()
    {
        Debug.Log("💥 El carrito explotó porque entró una computadora equivocada!");

        // 1. Soltar todas las compus guardadas
        manager.SoltarTodas();

        // 2. Instanciar efecto de explosión si lo configuraste
        if (prefabExplosion != null)
        {
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        }

        // 3. Destruir el carrito
        Destroy(gameObject, 0.5f);
    }
}
using UnityEngine;

public class CarritoTrigger : MonoBehaviour
{
    public JuntarComputadoras manager; // arrastrás el GameObject con el script JuntarComputadora
    public string filtroNombre = "compu god"; // lo que acepta este carrito
    public GameObject prefabExplosion; // arrastrás un prefab de partículas de explosión (opcional)

    private void OnTriggerEnter(Collider other)
    {
        string nombre = other.gameObject.name.ToLower();

        if (nombre.StartsWith(filtroNombre.ToLower()))
        {
            // ✅ Computadora correcta
            manager.AgregarComputadora(other.gameObject);
        }
        else if (nombre.StartsWith("compu")) // ❌ Es una compu pero no la correcta
        {
            ExplotaCarrito();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.ToLower().StartsWith(filtroNombre.ToLower()))
        {
            manager.QuitarComputadora(other.gameObject);
        }
    }

    private void ExplotaCarrito()
    {
        Debug.Log("💥 El carrito explotó porque entró una computadora equivocada!");

        // 1. Soltar todas las compus guardadas
        manager.SoltarTodas();

        // 2. Instanciar efecto de explosión si lo configuraste
        if (prefabExplosion != null)
        {
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        }

        // 3. Destruir el carrito
        Destroy(gameObject, 0.5f);
    }
}
