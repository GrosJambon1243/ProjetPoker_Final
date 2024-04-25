using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentScript : MonoBehaviour
{
    [SerializeField] public GameObject[] opponentHand;
    private Image[] imageComponents;
    [SerializeField] private Sprite newCard;

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
}
