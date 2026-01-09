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

    [Header("Pino da Bateria (utilizado para autorizar o uso do pino)")]
    public GameObject pino;

    [Header("Efeito Sonoro do Lacre ao Abrir")]
    [SerializeField] 
    private AudioClip efeitoLacre;      // efeito sonoro a ser declarado
    private AudioSource audioSource;    // é determinado a área em que o som será transmitido

    // inicializa a referência do componente AudioSource para ser usado adiante 
    // pre-condicao: componente AudioSource deve existir no objeto
    // pos-condicao: variável audioSource é atualizada ao inicio do game
    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }
    
    // executa a abertura do lacre da bateria visualmente e com efeito sonoro 
    // pre-condicao: se o lacre não estar aberto, nao continua com a função
    // pos-condicao: o lacre é rotacionado junto com efeito sonoro, atualiza a flag para poder interagir com o pino
    public void Open()
    {
        if (!isOpenLacre)
        {
            if (lacrePrefab.name == "LacreVermelho" || lacrePrefab.name == "LacrePreto")
            {
                lacrePrefab.transform.Rotate(0, 20f, 0);
                audioSource.PlayOneShot(efeitoLacre, 5.0f); // efeito sonoro ao abrir o lacre
                isOpenLacre = true; 
                //Debug.Log("Lacre aberto!");
                
                // habilita o pino a ser interagido
                pino.GetComponent<XRGrabInteractable>().enabled = true;
                QuestSystem.Instance.startLacreAberto();
            }
        }
    }
}
