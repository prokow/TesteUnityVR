using TMPro;
using UnityEngine;
using UnityEngine.UI; // Obrigatório para a Scrollbar funcionar

public class MenuManager : MonoBehaviour
{
    public GameObject objeto;
    private Material materialDefault;
    public Material materialNovo;
    private bool isMaterialChanged;
    
    //Scrollbar R-G-B
    public Scrollbar scrollbarR;
    public Scrollbar scrollbarG;
    public Scrollbar scrollbarB;
    

    void Start()
    {
        if (objeto != null)
        {
            materialDefault = objeto.GetComponent<Renderer>().material;
        }
    }
    
    public void onChangeMaterial()
    {
        if (objeto != null)
        {
            Renderer rend = objeto.GetComponent<Renderer>();

            if (rend != null)
            {
                if (isMaterialChanged == false)
                {
                    rend.material = materialNovo;
                    Debug.Log("Material Novo");
                    isMaterialChanged = true;
                }
                else
                {
                    rend.material = materialDefault;
                    Debug.Log("Material Padrao");
                    isMaterialChanged = false;
                }
            }
        }
        else Debug.Log("Nao existe o objeto ou material");
    }

    public void UpdateMaterialColor()
    {
        objeto.GetComponent<Renderer>().material = materialDefault;

        if (objeto.GetComponent<Renderer>().material != null)
        {
            float r = scrollbarR.value;
            float g = scrollbarG.value;
            float b = scrollbarB.value;
            
            Color color = new Color(r, g, b);
            
            objeto.GetComponent<Renderer>().material.color = color;
        }
    }
}
