using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.UI; 

public class QuestUIManager : MonoBehaviour
{
    [Header("Panel's usados na UI")]
    [SerializeField] private GameObject panelTasks;
    [SerializeField] private GameObject panelEnd;
    
    [Header("Tarefas a serem validados diante a interação")]
    [SerializeField] private Toggle FirstTask;
    [SerializeField] private Toggle SecondTask;
    [SerializeField] private Toggle ThirdTask;
    
    [Header("Textos das tarefas a serem mudados de cor quando validadas")]
    [SerializeField] private TextMeshProUGUI FirstText;
    [SerializeField] private TextMeshProUGUI SecondText;
    [SerializeField] private TextMeshProUGUI ThirdText;
    
    [Header("Efeito Sonoro ao validar tarefa")]
    [SerializeField] 
    private AudioClip taskComplete;      // efeito sonoro a ser declarado
    private AudioSource audioSource;    // é determinado a área em que o som será transmitido

    
    //inicializa a instância única do sistema de missões (Singleton)
    //pre-condicao: nenhuma
    //pos-condicao: se não houver instância, define esta; caso contrário, destrói o objeto duplicado
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        panelEnd.SetActive(false);
        
        if (QuestSystem.Instance != null)
        {
            QuestSystem.Instance.onTaskComplete.AddListener(UpdatePanel);
        }
        FirstTask.isOn = false;
        SecondTask.isOn = false;
        ThirdTask.isOn = false;
    }
    
    // De acordo com as "tasks" chamadas, serão validadas com audio e do Toggle para verde na UI
    // pre-condicao: necessita da string do nome da string para o switch
    // pos-condicao: para cada task chamada no switch, será validado na UI
    void UpdatePanel(string taskName)
    {
        switch (taskName)
        {
            case "FirstTask":
                audioSource.PlayOneShot(taskComplete, 5.0f);
                FirstTask.isOn = true;
                var lacre = FirstTask.colors;
                lacre.normalColor = Color.green;
                FirstTask.colors = lacre;
                FirstText.color = Color.green;
                break;
            
            case "SecondTask":
                audioSource.PlayOneShot(taskComplete, 5.0f);
                SecondTask.isOn = true;
                var pino  = SecondTask.colors;
                pino.normalColor = Color.green;
                SecondTask.colors = pino;
                SecondText.color = Color.green;
                break;
            
            case "ThirdTask":
                audioSource.PlayOneShot(taskComplete, 5.0f);
                ThirdTask.isOn = true;
                var pinoSolto  = ThirdTask.colors;
                pinoSolto.normalColor = Color.green;
                ThirdTask.colors = pinoSolto;
                ThirdText.color = Color.green;
                break;
        }
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
    }
    
    void Update()
    {
        if (ThirdTask.isOn)
        {
            DoDelayAction(10.0f);
            panelTasks.SetActive(false);
            panelEnd.SetActive(true);
        }
    }

    // Fará a desinscrição do QuestSystem (Singleton) quando terminado a interação no UpdatePanel
    // pre-condicao: a instância precisa estar nula
    // pos-condicao: se desinscreve do QuestSystem quando terminado a interação na bateria
    private void OnDestroy()
    {
        if (QuestSystem.Instance != null)
        {
            QuestSystem.Instance.onTaskComplete.RemoveListener(UpdatePanel);
        }
    }
}
