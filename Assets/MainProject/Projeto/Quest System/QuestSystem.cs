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
    
    // Base usada do Singleton
    // Se não houver uma instância, então é atribuido esta instância
    // Caso houver outra instância, eu me destruo para não ter duplicatas 
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
    
    public void startLacreAberto()
    {
        if (!Instance.lacreAberto)
        {
            lacreAberto = true;
            onTaskComplete?.Invoke("FirstTask");
            Debug.Log("Primeira etapa concluida!");
        }
    }

    public void startPinoColetado()
    {
        if (!Instance.pinoColetado)
        {
            pinoColetado = true;
            onTaskComplete?.Invoke("SecondTask");
            Debug.Log("Segunda etapa concluida!");
        }
    }

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
