using System;
using UnityEngine;
using UnityEngine.Events;

public class LacreController : MonoBehaviour
{
    [SerializeField] private GameObject lacre;
    public UnityEvent OnPress;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPress?.Invoke(); 
            Debug.Log("Invocado");
        }
    }

    public void open()
    {
        lacre.gameObject.transform.Rotate(-20f, 0 , 0);
        Debug.Log("Lacre aberto");
    }

}
