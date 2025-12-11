using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class EventPino : MonoBehaviour
{
    private XRGrabInteractable grab;
    public UnityEvent onDrop;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        if (grab != null)
        {
            grab.selectExited.AddListener(dispatchEvent);
        }
    }

    void OnDisable()
    {
        if (grab != null)
        {
            grab.selectExited.RemoveListener(dispatchEvent);
        }
    }

    private void dispatchEvent(SelectExitEventArgs args)
    {
        StartCoroutine(holdWait());
    }

    System.Collections.IEnumerator holdWait()
    {
        yield return new WaitForEndOfFrame();
        onDrop.Invoke();
    }
    

}
