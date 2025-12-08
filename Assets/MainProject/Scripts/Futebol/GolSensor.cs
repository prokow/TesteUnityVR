using System;
using UnityEngine;
using UnityEngine.Events;

public class GolSensor : MonoBehaviour
{
    public event Action OnGol; 
    //public UnityEvent OnGol2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bola"))
        {
            OnGol?.Invoke();

            /*BolaController bolaScript = other.GetComponent<BolaController>();

            if (bolaScript != null)
            {
                bolaScript.ResetarPosicao();
            }*/
        }
    }
}
