using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class PinoBehavior : XRGrabInteractable
{
    [Header("Configurações")] 
    public float returnTime = 0.5f;
    public Transform returnPino;
    public Collider limiteArea;

    // Para cada pino usado
    private Rigidbody pinoRB;

    // Para quando soltar o Pino
    private bool voltaAoSoltar = false; // voltaAoSoltar
    private float time = 0f; // cronometro 
    private Vector3 posicaoFinal; // posição da onde sai quando solta
    private Quaternion rotacaoFinal; // rotação do pino 
    
    // Usado para logica para soltar o pino quando sair da area limitada 
    private float tempoGrab; // tempo de quando for pego o pino
    
    protected override void Awake()
    {
        base.Awake();
        pinoRB = GetComponent<Rigidbody>();
        pinoRB.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = false;
        UpdateMask(dentroArea());
    }

    // Fará um update na camada de interação, se pode ou não pode interagir
    private void UpdateMask(bool value)
    {
        // se o "value" for verdadeiro, definirá a camada de interação default que é a que podemos interagir
        // caso for falso, retorna 0
        interactionLayers = value ? LayerMask.GetMask("Default") : 0;
    }

    // Função para quando é pego o pino
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        voltaAoSoltar = false;
        pinoRB.isKinematic = false;
        
        QuestSystem.Instance.startPinoColetado();
        
        // Guarda o tempo quando for pego o pino
        tempoGrab = Time.time;
    }

    
    // Função para quando soltar o pino ele retornará para a posição definida
    public void retornoPino()
    {
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
                    //pinoRB.isKinematic = true;
                }
            }

            time = 0f;
            voltaAoSoltar = true;
            //Debug.Log("Pino solto");
        }
    }

    // Função auxiliar para quando sair do limite e estiver segurando o pino, soltar ele
    private void soltarPino()
    {
        if (isSelected)
        {
            interactionManager.CancelInteractableSelection((IXRSelectInteractable)this);
            //Debug.Log("soltando pino");
        }
    }

    // Booleano que mostrará se o user ta dentro do area para a interação ou não
    private bool dentroArea()
    {
        if (limiteArea == null) return true;
        return limiteArea.bounds.Contains(transform.position);
    }

    
    // Função para detectar que quando o pino estiver pego e sair da área, será soltado a posição final
    public void OnTriggerExit(Collider other)
    {
        //se a colisão for para o Collider "limiteArea" e o pino estiver sendo pego
        if (other == limiteArea && isSelected)
        {
            // Diminui o tempo atual com o tempo guardado quando pego, pra tirar o snap bug de 1 frame
            if (Time.time - tempoGrab > 0.1f)
            {
                soltarPino();
            }
        }
    }
    
    // Função para quando solta o pino
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        QuestSystem.Instance.startPinoSolto();
        retornoPino();
    }
    
    // Update para XRInteractable
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            // se estiver desligado, nao acontece nada
            if (voltaAoSoltar == false) return;

            // caso o voltaAoSoltar seja true, então segue com a lógica
            time += Time.deltaTime; // aumenta o cronômetro
            float percentage = time / returnTime; // calcula a porcentagem do tempo que vai retornar o pino 

            // Lerp
            transform.position = Vector3.Lerp(posicaoFinal, returnPino.position, percentage);
            transform.rotation = Quaternion.Lerp(rotacaoFinal, returnPino.rotation, percentage);

            if (percentage >= 1.0f)
            {
                transform.position = returnPino.position;
                transform.rotation = returnPino.rotation;

                voltaAoSoltar = false;
                //Debug.Log("Pino voltou ao lugar desejado");
            }
        }
    }
    
}
