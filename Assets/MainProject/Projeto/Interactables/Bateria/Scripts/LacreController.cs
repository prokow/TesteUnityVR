using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class LacreController : XRSimpleInteractable
{
    public System.Action OnLacre;
    [SerializeField]
    private GameObject Lacre;
    //private bool isOpenLacre = false;
    
    //public UnityEvent OnPress;
    
    public void Open()
    {
        // Gira -20 graus no eixo X
        Lacre.transform.Rotate(-20f, 0, 0);
            
        //isOpenLacre = true; // Trava para não girar infinito se tocar de novo
        Debug.Log("Lacre aberto via Poke!");
    }
}
