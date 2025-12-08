using UnityEngine;

public class BolaController : MonoBehaviour
{
    
    private Vector3 posicaoInicial;

    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicaoInicial = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    public void ResetarPosicao()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        transform.position = posicaoInicial;
    }
}
