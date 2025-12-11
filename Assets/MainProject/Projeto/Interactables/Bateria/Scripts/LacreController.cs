using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LacreController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    
    [SerializeField] private GameObject lacre;
    public UnityEvent OnPress;

    // Variável para travar e não deixar abrir 2 vezes (opcional, mas recomendado)
    private bool jaAbriu = false;

    // Essa função será chamada APENAS pelo evento do XR Interactable
    public void Open()
    {
        if (!jaAbriu)
        {
            // Gira -20 graus no eixo X
            lacre.transform.Rotate(-20f, 0, 0);
            
            jaAbriu = true; // Trava para não girar infinito se tocar de novo
            Debug.Log("Lacre aberto via Poke!");
        }
    }

}
