using UnityEngine;

public class Ball : MonoBehaviour
{
    //make a interaction ball with the inputAction on the outside of the area

    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    
}
