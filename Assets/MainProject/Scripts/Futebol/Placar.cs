using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Placar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI homeText;
    [SerializeField]
    private TextMeshProUGUI awayText;
    [SerializeField]
    private GolSensor home;
    [SerializeField]
    private GolSensor away;
    

    private int homeGol = 0;
    private int awayGol = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        //interactable.selectEntered.AddListener();
        UpdateTexto();
    }

    // este chamada de evento seria para quando for ativado o evento
    // e o uso deste operador "+=" invés de ser algo para acrescentar algum valor,
    // será para indicar quando o evento vai ser chamado ou não, ou seja,
    // quando o evento for chamado será 
    private void OnEnable()
    {
        home.OnGol += MarcarHomeGol;
        away.OnGol += MarcarAwayGol;
    }

    private void OnDisable()
    {
        home.OnGol -= MarcarHomeGol;
        away.OnGol -= MarcarAwayGol;   
    }

    public void MarcarHomeGol()
    {
        homeGol++;
        Debug.Log("GOL HOME");
        UpdateTexto();
    }

    public void MarcarAwayGol(){
        awayGol++;
        Debug.Log("GOL AWAY");
        UpdateTexto();
    }

    void UpdateTexto()
    {
        homeText.text = homeGol.ToString();
        awayText.text = awayGol.ToString();
    }
}
