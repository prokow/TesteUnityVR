using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationHand : MonoBehaviour
{
    public InputActionProperty triggerValor;
    public InputActionProperty gripValor;

    public Animator handAnimator;
    
    // Update is called once per frame
    void Update()
    {
        float trigger = triggerValor.action.ReadValue<float>();
        float grip = gripValor.action.ReadValue<float>();
        
        handAnimator.SetFloat("Trigger", trigger);
        handAnimator.SetFloat("Grip", grip);
        
    }
}
