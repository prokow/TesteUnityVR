using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class PinoController : MonoBehaviour 
{
    [Header("Configurações")]
    public float returnTime = 0.5f;
    public Vector3 offsetPino = new Vector3(0f, 0f, 0.1f);
    
    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial; 
    private Rigidbody pinoRB;
    
    private bool interruptor = false;   // interruptor
    private float time = 0f;            // cronometro 
    private Vector3 posicaoFinal;       // posição da onde sai quando solta
    private Quaternion rotacaoFinal;
    
    void Start()
    {
        pinoRB = GetComponent<Rigidbody>();
        
        // salva a posição inicial
        posicaoInicial = transform.position;
        rotacaoInicial = transform.rotation;
    }
    
    
    
    public void AoSoltarObjeto()
    {
        if (pinoRB != null)
        {
            if (!pinoRB.isKinematic)
            {
                pinoRB.linearVelocity = Vector3.zero;
                pinoRB.angularVelocity = Vector3.zero;
            }
            pinoRB.isKinematic = true;
        }
        
        posicaoFinal = transform.position;
        rotacaoFinal = transform.rotation;

        time = 0f;

        interruptor = true;
        
        Debug.Log("Iniciando Pino Controller");
    }

    // Event Tick, que acontece o tempo todo no jogo
    void Update()
    {   
        //se estiver desligado, nao acontece nada
        if (interruptor == false) return;
        
        // caso o interruptor seja true, então segue com a lógica
        time += Time.deltaTime;                         // aumenta o cronômetro
        float percentage = time / returnTime;           // calcula a porcentagem do tempo que vai retornar o pino 
        Vector3 destino = posicaoInicial - offsetPino;  // define o destino final (casa - offset)
        
        // Lerp para mover suavemente 
        transform.position = Vector3.Lerp(posicaoFinal, destino, percentage);
        transform.rotation = Quaternion.Lerp(rotacaoFinal, rotacaoInicial, percentage);

        if (percentage >= 1.0f)
        {
            transform.position = destino;
            transform.rotation = rotacaoInicial;
            
            interruptor = false;
            Debug.Log("Feito");
        }
    }
}
