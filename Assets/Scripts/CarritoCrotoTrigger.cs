using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoCrotoTrigger : MonoBehaviour
{
    public JuntarComputadorasCrotas manager;

    private void OnTriggerEnter(Collider other)
    {
        string nombre = other.gameObject.name;

        if (nombre.StartsWith("computadora crota"))
        {
            manager.AgregarComputadora(other.gameObject);
        }
        else if (nombre.StartsWith("compu god"))
        {
            
            manager.DevolverTodas();

            

            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("computadora crota"))
        {
            manager.QuitarComputadora(other.gameObject);
        }
    }
}
