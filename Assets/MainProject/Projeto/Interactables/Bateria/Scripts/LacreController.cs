using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LacreController : XRSimpleInteractable
{
    [Header("Lacre da Bateria")]
    [SerializeField]
    private GameObject lacrePrefab;
    private bool isOpenLacre = false;

    [Header("Efeito Sonoro do Lacre ao Abrir")]
    [SerializeField] private AudioClip efeitoLacre;
    private AudioSource audioSource;

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Open()
    {
        if (!isOpenLacre)
        {
            if (lacrePrefab.name == "LacreVermelho")
            {
                lacrePrefab.transform.Rotate(0, 20f, 0);
                audioSource.PlayOneShot(efeitoLacre, 5.0f);
                isOpenLacre = true; // Trava para não girar infinito se tocar de novo
                Debug.Log("Lacre Vermelho aberto!");
            }
            else 
            {
                lacrePrefab.transform.Rotate(0, 20f, 0);
                audioSource.PlayOneShot(efeitoLacre, 5.0f);
                isOpenLacre = true; // Trava para não girar infinito se tocar de novo
                Debug.Log("Lacre Preto aberto!");
            }
        }
    }
}
