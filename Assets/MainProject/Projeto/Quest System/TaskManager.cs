using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI; 

public class TaskManager : MonoBehaviour
{
    [SerializeField] private Toggle FirstTask;
    [SerializeField] private Toggle SecondTask;
    [SerializeField] private Toggle ThirdTask;
    
    [SerializeField] private TextMeshProUGUI FirstText;
    [SerializeField] private TextMeshProUGUI SecondText;
    [SerializeField] private TextMeshProUGUI ThirdText;

    void Start()
    {
        if (QuestSystem.Instance != null)
        {
            QuestSystem.Instance.onTaskComplete.AddListener(UpdatePanel);
        }
        FirstTask.isOn = false;
        SecondTask.isOn = false;
        ThirdTask.isOn = false;
    }

    void UpdatePanel(string taskName)
    {
        switch (taskName)
        {
            case "FirstTask":
                FirstTask.isOn = true;
                var lacre = FirstTask.colors;
                lacre.normalColor = Color.green;
                FirstTask.colors = lacre;
                FirstText.color = Color.green;
                break;
            
            case "SecondTask":
                SecondTask.isOn = true;
                var pino  = SecondTask.colors;
                pino.normalColor = Color.green;
                SecondTask.colors = pino;
                SecondText.color = Color.green;
                break;
            
            case "ThirdTask":
                ThirdTask.isOn = true;
                var pinoSolto  = ThirdTask.colors;
                pinoSolto.normalColor = Color.green;
                ThirdTask.colors = pinoSolto;
                ThirdText.color = Color.green;
                break;
        }
    }

    private void OnDestroy()
    {
        if (QuestSystem.Instance != null)
        {
            QuestSystem.Instance.onTaskComplete.RemoveListener(UpdatePanel);
        }
    }
}
