using System;
using TMPro;
using UnityEngine;

public class Placar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI homeText;
    [SerializeField]
    private TextMeshProUGUI awayText;
    [SerializeField]
    private GameObject home;
    [SerializeField]
    private GameObject away;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        homeText.text = "0";
        awayText.text = "0";
    }

    public void OnTriggerEnter(Collider other)
    {
        int homeGol = 0;
        int awayGol = 0;
        
        if (other.gameObject == home.gameObject)
        {
            homeGol++;
            homeText.text = homeGol.ToString();
            Debug.Log("GOL HOME");
        }
        else if (other.gameObject == away.gameObject)
        {
            awayGol++;
            awayText.text = awayGol.ToString();
            Debug.Log("GOL AWAY");
        }
    }
    
}
