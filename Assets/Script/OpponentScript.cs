using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentScript : MonoBehaviour
{
    [SerializeField] public GameObject[] opponentHand;
    private Image[] imageComponents;
    [SerializeField] private List<Sprite> newCard; 
    

    private void Start()
    {
        imageComponents = new Image[opponentHand.Length];
        for (int i = 0; i < opponentHand.Length; i++)
        {
            imageComponents[i] = opponentHand[i].GetComponent<Image>();
        }
       
    }

    public void FirstCombat()
    {
        opponentHand[0].GetComponent<Animator>().SetBool("Flip", true);

    }

    public void SecondCombat()
    {
        imageComponents[0].sprite = newCard[0];
        imageComponents[2].sprite = newCard[1];
        imageComponents[3].sprite = newCard[8];

    }
}
