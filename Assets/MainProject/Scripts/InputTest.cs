using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class InputTest : MonoBehaviour
{
    public InputActionProperty testActionValue;
    public GameObject testObject;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*if (testActionValue.action != null)
        {
            float value = testActionValue.action.ReadValue<float>();
            Debug.Log("Valor do trigger: " + value);

            bool IsPressed = testActionValue.action.IsPressed();
            Debug.Log(IsPressed);
        }*/
    }
    
    
}
