using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionBrazo : MonoBehaviour
{
    public EmparejarCables tablero;
//elementos de la ui a prender y apagar
    public GameObject panelCables;
    public GameObject Img_InteractionBG;
    public GameObject Img_InteractionBGF;
    public GameObject mensajeError;
    public GameObject pantallaMonitor1;
    public GameObject pantallaMonitor2;
    public GameObject pantallaMonitor3;
    
    public bool puertaAbierta = false;
    public GameObject conversacion;
    

    //bools para ver q abrir
    private bool dentroDelTriggerCubeTask1 = false;
    private bool dentroDelTriggerMonitorTask1 = false;
    private bool dentroDelTriggerMonitor1 = false;
    private bool dentroDelTriggerMonitor2 = false;
    private bool dentroDelTriggerMonitor3 = false;
    private bool dentroDelTriggerPuerta = false;
    private bool dentroDelTriggerMep = false;
    
    
    //mouses
    private bool dentroDelTriggerMouseRojo1 = false;


    private void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "CubeTask1"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerCubeTask1 = true;
        }
        if(other.gameObject.name == "MonitorTask1"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitorTask1 = true;
        }
        if(other.gameObject.name == "Monitor (1)"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor1 = true;
        }
        if(other.gameObject.name == "Monitor (2)"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor2 = true;
        }
        if(other.gameObject.name == "Monitor (3)"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor3 = true;
        }
        if(other.gameObject.name == "Puerta"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerPuerta = true;
        }
        if(other.gameObject.name == "Mep"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMep = true;
        }
        if(other.gameObject.name == "MouseRojo1")
        {
            Img_InteractionBGF.SetActive(true);
            dentroDelTriggerMouseRojo1 = true;
        }

     }
         private void OnTriggerExit(Collider other){
        Img_InteractionBG.SetActive(false);
      dentroDelTriggerCubeTask1 = false;
      dentroDelTriggerMonitorTask1 = false;
      dentroDelTriggerMonitor1 = false;
      dentroDelTriggerMonitor2 = false;
      dentroDelTriggerMonitor3 = false;
      dentroDelTriggerPuerta = false;
      dentroDelTriggerMep = false;
      dentroDelTriggerMouseRojo1 = false;

    }



    void Start()
    {
        mensajeError.SetActive(false);
        pantallaMonitor1.SetActive(false);
        pantallaMonitor2.SetActive(false);
        pantallaMonitor3.SetActive(false);
        conversacion.SetActive(false);
        Img_InteractionBGF.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E)){
            if(dentroDelTriggerCubeTask1 == true){
                panelCables.SetActive(true);
                tablero.colorI = null;
                tablero.colorD = null;
            }

            if(dentroDelTriggerMonitorTask1 == true){
                mensajeError.SetActive(true);
            }
            if(dentroDelTriggerMonitor1 == true){
                pantallaMonitor1.SetActive(true);
            }
            if(dentroDelTriggerMonitor2 == true){
                pantallaMonitor2.SetActive(true);
            }
            if(dentroDelTriggerMonitor3 == true){
                pantallaMonitor3.SetActive(true);
            }
            if(dentroDelTriggerPuerta == true){
                puertaAbierta = ! puertaAbierta;
            }
            if(dentroDelTriggerMep == true){
                conversacion.SetActive(true);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {

            if(dentroDelTriggerMouseRojo1 == true)
            {

            }
        }


        if (Input.GetKeyDown(KeyCode.Q)){
                panelCables.SetActive(false);
                mensajeError.SetActive(false);
                pantallaMonitor1.SetActive(false);
                pantallaMonitor2.SetActive(false);
                pantallaMonitor3.SetActive(false);
                conversacion.SetActive(false);
            Img_InteractionBGF.SetActive(false);
            }
        
    }
}
