using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class PinoController : MonoBehaviour 
{
    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;
    private Rigidbody pinoRB;
    
    [Header("Configuração do Retorno")]
    [Tooltip("Quanto tempo demora para volta (em s)")]
    public float returnTime = 0.5f;
    public Vector3 offsetPino = new Vector3(0f, 0f, 0.1f);
    void Awake()
    {
        pinoRB = GetComponent<Rigidbody>();
        
        posicaoInicial = transform.position;
        rotacaoInicial = transform.rotation;
    }
    

    // A função do evento agora chama a rotina de espera
    public void AoSoltarObjeto()
    {
        Debug.Log("Soltei! Esperando o frame acabar para resetar...");
        StopAllCoroutines();
        StartCoroutine(Retornar());
    }

    IEnumerator Retornar()
    {
        // Comando para esperar o fim do frame atual
        // Isso deixa o XR Toolkit terminar tudo que ele precisa fazer antes
        yield return new WaitForEndOfFrame(); 

        // Agora sim, resetamos a física
        if (pinoRB != null && !pinoRB.isKinematic)
        {
            pinoRB.linearVelocity = Vector3.zero;
            pinoRB.angularVelocity = Vector3.zero;
            pinoRB.isKinematic = true;
        }

        float passedTime = 0f;
        
        Vector3 positionAtual = pinoRB.transform.position;
        Quaternion rotationAtual = pinoRB.transform.rotation;
        
        Vector3 positionFinal = posicaoInicial - offsetPino;

        while (passedTime < returnTime)
        {
            passedTime += Time.deltaTime;
            
            float t = passedTime / returnTime;
            
            transform.position = Vector3.Lerp(positionAtual, positionFinal, t);
            transform.rotation = Quaternion.Lerp(rotationAtual, rotacaoInicial, t);

            yield return null;
        }
        
        pinoRB.transform.position = positionFinal; 
        pinoRB.transform.rotation = rotacaoInicial;
        
        Debug.Log("Resetado com sucesso!");
    }
}
