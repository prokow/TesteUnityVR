using System;
using UnityEngine;

public class OpenLacre : MonoBehaviour
{
    [SerializeField] private EventLacre lacre;
    

    public void open()
    {
        lacre.gameObject.transform.rotation = Quaternion.Euler(-30, 0, 0);
    }

    private void OnEnable()
    {
        lacre.OnPress += open;
    }

    private void OnDisable()
    {
        lacre.OnPress -= open;

    }
}
