using System;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class BateriaManager : MonoBehaviour
{
    // gameObjects a serem ativados
    //[Header("Configurações do limite")]
    private BoxCollider collider;
    
    [SerializeField] 
    private PinoBehavior pinoPreto;
    [SerializeField] 
    private PinoBehavior pinoVermelho;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PinoBehavior pino = other.gameObject.GetComponent<PinoBehavior>();
        if (other.CompareTag("Player"))
        {
            pino.soltarPino();
        }
    }
}
