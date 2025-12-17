using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class PinoBehavior : XRGrabInteractable 
{
    [Header("Configurações")]
    public float returnTime = 0.5f;
    public Transform returnPino;
    
    private Rigidbody pinoRB;
    
    private bool interruptor = false;   // interruptor
    private float time = 0f;            // cronometro 
    private Vector3 posicaoFinal;       // posição da onde sai quando solta
    private Quaternion rotacaoFinal;

    protected override void Awake()
    {
        base.Awake();
        pinoRB = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        interruptor = false;
        pinoRB.isKinematic = false;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (returnPino != null)
        {
            // posição e rotação de onde sai quando solta
            posicaoFinal = transform.position;
            rotacaoFinal = transform.rotation;
            
            // ao soltar o objeto, ele vai voltar para a posição onde estava e ficar isKinematic (parado)
            if (pinoRB != null)
            {
                if (!pinoRB.isKinematic)
                {
                    pinoRB.linearVelocity = Vector3.zero;
                    pinoRB.angularVelocity = Vector3.zero;
                    pinoRB.isKinematic = true;
                }
            }

            time = 0f;
            interruptor = true;
            //Debug.Log("Pino solto");
        }
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            // se estiver desligado, nao acontece nada
            if (interruptor == false) return;
        
            // caso o interruptor seja true, então segue com a lógica
            time += Time.deltaTime;                         // aumenta o cronômetro
            float percentage = time / returnTime;           // calcula a porcentagem do tempo que vai retornar o pino 
        
            // Lerp
            transform.position = Vector3.Lerp(posicaoFinal, returnPino.position, percentage);
            transform.rotation = Quaternion.Lerp(rotacaoFinal, returnPino.rotation, percentage);

            if (percentage >= 1.0f)
            {
                transform.position = returnPino.position;
                transform.rotation = returnPino.rotation;
            
                interruptor = false;
                //Debug.Log("Pino voltou ao lugar desejado");
            }
        }
    }
}
