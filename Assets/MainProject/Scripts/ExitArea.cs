using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.XR.CoreUtils;

public class ExitArea : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Caiu do mapa");
        Application.Quit();
        
        //isso será para o editor, que faz a função de desativar o playmode do editor e voltar ao editor normalmente
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

