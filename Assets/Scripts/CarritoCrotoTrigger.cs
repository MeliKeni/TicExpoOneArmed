using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoCrotoTrigger : MonoBehaviour
{
   public JuntarComputadorasCrotas manager; // arrastrás el GameObject con el script JuntarComputadora

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("computadora crota"))
        {
            manager.AgregarComputadora(other.gameObject);
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
