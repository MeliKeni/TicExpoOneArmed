using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoCrotoTrigger : MonoBehaviour
{
    public JuntarComputadorasCrotas manager;
    

    private void OnTriggerStay(Collider other)
    {
        string nombre = other.gameObject.name;

        // Si es computadora crota y el jugador la suelta
        if (nombre.StartsWith("computadora crota") && Input.GetMouseButtonUp(0))
        {
            // Apagar renderer
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null)
                rend.enabled = false;

            // Agregar al manager
            manager.AgregarComputadora(other.gameObject);
        }
        // Si es compu god y la suelta, devolver todas
        else if (nombre.StartsWith("compu god") && Input.GetMouseButtonUp(0))
        {
            manager.DevolverTodas();
            Destroy(gameObject);
           manager.carritosMuertos++;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si la computadora crota se retira del carrito sin soltarla, quitarla del manager
        if (other.gameObject.name.StartsWith("computadora crota"))
        {
            manager.QuitarComputadora(other.gameObject);
        }
    }
}
