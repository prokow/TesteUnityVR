using TMPro;
using UnityEngine;
using UnityEngine.UI; // Obrigatório para a Scrollbar funcionar

public class MenuManager : MonoBehaviour
{
    public GameObject objeto;
    public Material material;
    public Scrollbar scrollbar;
    public TextMeshProUGUI texto;

    public void onChangeObject()
    {
        if (objeto != null)
        {
            Renderer rend = objeto.GetComponent<Renderer>();

            if (rend != null)
            {
                material = rend.material;
                Debug.Log("Material CHANGEADO");
            }
        }
    }
    
    public void onExit()
    {
        Application.Quit();
        //isso será para o editor, que faz a função de desativar o playmode do editor e voltar ao editor normalmente
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

    public void UpdateTexto()
    {
        float valor = scrollbar.value;
        
        texto.text = (valor*100).ToString("F0") + "%";
    }
}
