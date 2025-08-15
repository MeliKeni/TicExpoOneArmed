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
    public GameObject pantallaMonitor1;
    public GameObject pantallaMonitor2;
    public GameObject pantallaMonitor3;
   
    
    public bool puertaAbierta = false;
    public GameObject conversacion;

    public bool Task1Hecha = false;

    //bools para ver q abrir
    public bool dentroDelTriggerPc3 = false;
    public bool dentroDelTriggerMonitorT1 = false;
    private bool dentroDelTriggerMonitor1 = false;
    private bool dentroDelTriggerMonitor2 = false;
    private bool dentroDelTriggerMonitor3 = false;
    private bool dentroDelTriggerPuerta = false;
    private bool dentroDelTriggerMep = false;
    
    

    private void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "pc 3 TASK 1"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerPc3 = true;
        }
        if(other.gameObject.name == "MonitorT1"){
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitorT1 = true;
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
        if(other.gameObject.name == "MouseRojo1" || other.gameObject.name == "MouseRojo2" || other.gameObject.name == "MouseRojo3" || other.gameObject.name == "MouseRojo4")
        {
            Img_InteractionBGF.SetActive(true);
        }
        if(other.gameObject.name == "MouseAzul1" || other.gameObject.name == "MouseAzul2" || other.gameObject.name == "MouseAzul3" || other.gameObject.name == "MouseAzul4")
        {
            Img_InteractionBGF.SetActive(true);
        }

     }
         private void OnTriggerExit(Collider other){
        Img_InteractionBG.SetActive(false);
        Img_InteractionBGF.SetActive(false);
      dentroDelTriggerPc3 = false;
      dentroDelTriggerMonitorT1 = false;
      dentroDelTriggerMonitor1 = false;
      dentroDelTriggerMonitor2 = false;
      dentroDelTriggerMonitor3 = false;
      dentroDelTriggerPuerta = false;
      dentroDelTriggerMep = false;


    }



    void Start()
    {
        
        pantallaMonitor1.SetActive(false);
        pantallaMonitor2.SetActive(false);
        pantallaMonitor3.SetActive(false);
        conversacion.SetActive(false);
        Img_InteractionBGF.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)){
            if(dentroDelTriggerPc3 == true){
                panelCables.SetActive(true);
                tablero.colorI = null;
                tablero.colorD = null;
        } 
        }
        if(Input.GetKeyDown(KeyCode.E)){
            if(dentroDelTriggerPc3 == true){
                panelCables.SetActive(true);
                tablero.colorI = null;
                tablero.colorD = null;
            }

            /*if(dentroDelTriggerMonitorTask1 == true){
                if (Task1Hecha == true)
                {
                    pantallaMonitort1.SetActive(true);
                }
                else
                {
                    mensajeError.SetActive(true);
                }
            }*/
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
       


        if (Input.GetKeyDown(KeyCode.Q)){
                panelCables.SetActive(false);
               tablero.mensajeError.SetActive(false);
                pantallaMonitor1.SetActive(false);
                pantallaMonitor2.SetActive(false);
                pantallaMonitor3.SetActive(false);
               tablero.pantallaMonitort1.SetActive(false);
                conversacion.SetActive(false);
            Img_InteractionBGF.SetActive(false);
            }
        
    }
}
