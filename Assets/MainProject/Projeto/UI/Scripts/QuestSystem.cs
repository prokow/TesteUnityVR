using System;
using UnityEngine;
using UnityEngine.Events;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem Instance {get; private set;}

    public bool lacreAberto = false;
    public bool pinoColetado = false;
    public bool pinoSolto = false;

    public UnityEvent<string> onTaskComplete;  
    
    // inicializa a instância única do sistema de missões (Singleton)
    // pre-condicao: nenhuma
    // pos-condicao: se não houver instância, define esta;
    //               caso contrário, destrói o objeto duplicado
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        { 
            Instance = this;
        }
    }
    
    // registra a conclusão da etapa de abertura do lacre
    // pre-condicao: nenhuma
    // pos-condicao: flag lacreAberto é definida como true assim fazendo a animação do lacre
    public void startLacreAberto()
    {
        if (!Instance.lacreAberto)
        {
            lacreAberto = true;
            onTaskComplete?.Invoke("FirstTask");
            Debug.Log("Primeira etapa concluida!");
        }
    }

    // registra que o usuário coletou o pino pela primeira vez
    // pre-condicao: nenhuma
    // pos-condicao: flag pinoColetado definida como true assim indicando que o user pegou o pino
    public void startPinoColetado()
    {
        if (!Instance.pinoColetado)
        {
            pinoColetado = true;
            onTaskComplete?.Invoke("SecondTask");
            Debug.Log("Segunda etapa concluida!");
        }
    }

    // registra que o usuário soltou o pino pela primeira vez
    // pre-condicao: nenhuma
    // pos-condicao: flag pinoSolto definida como True e é
    //               feito a animação do pino voltando ao lugar definido
    public void startPinoSolto()
    {
        if (!Instance.pinoSolto)
        {
            pinoSolto = true;
            onTaskComplete?.Invoke("ThirdTask");
            Debug.Log("Terceira etapa concluida!");
            Debug.Log("Interação com a bateria finalizada!");
        }
    }
    
}
