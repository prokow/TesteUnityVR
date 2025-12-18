using System;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class BateriaManager : MonoBehaviour
{
    // gameObjects a serem ativados
    public LacreController lacre;
    public PinoBehavior pino;
    public SplineBehavior spline;

    [Header("Configurações do limite")]
    [SerializeField]
    private BoxCollider collider;

    private bool isLacreOpen = false;
    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // pode pegar o objeto
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (collider.isTrigger == false)
            {
                // solta o objeto
            }
        }
    }
    
}
