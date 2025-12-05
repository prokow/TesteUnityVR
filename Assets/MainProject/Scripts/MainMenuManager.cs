using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image imagem;
    public bool isClicked = false;

    void Start()
    {
        if (imagem != null)
        {
            imagem.gameObject.SetActive(false);
        }
    }
    public void onClick()
    {
        isClicked = !isClicked;
        if (!isClicked)
        { 
            imagem.gameObject.SetActive(true);
        }
        else imagem.gameObject.SetActive(false);
    }
    
    

    public void onExit()
    {
        Application.Quit();
        //isso será para o editor, que faz a função de desativar o playmode do editor e voltar ao editor normalmente
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
