using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteCarrito : MonoBehaviour
{
    // Start is called before the first frame update
    public JuntarComputadoras god;
    public JuntarComputadorasCrotas crotas;
    public GameObject logro;
    
    void Start()
    {
        logro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(god.carritosMuertos==3 && crotas.carritosMuertos == 3)
        {
            logro.SetActive(true);
        }
    }
}
