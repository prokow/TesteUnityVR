using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Rotacionar o GameObject em uma determinada velocidade")]
    [SerializeField] private Vector3 rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
