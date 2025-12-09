using System;
using UnityEngine;

public class EventLacre : MonoBehaviour
{
    public event Action OnPress;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPress?.Invoke();       
        }
    }
}
