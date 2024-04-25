using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandsCombo : MonoBehaviour
{
    [SerializeField]private TMP_Text comboIndicator;
    [SerializeField]private Carte[] playerHands;
    private int firstCardPair;
    private int secCardPair;
    
    private int firstCardKind;
    private int secCardKind;
    private int thirdCardKind;
    
    
    private int[] playerHandsValue = {1,2,3,4,5};

    public bool hasPair()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 1 +i; j < 5; j++)
            {
                if (playerHands[i].cardValue == playerHands[j].cardValue)
                {
                    firstCardPair = i;
                    secCardPair = j;
                    return true;
                }
            }
            
        }

        return false;
    }

    public bool hasTwoPair()
    {
        if (hasPair())
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 1 +i; j < 5; j++)
                {
                    if (firstCardPair == i && secCardPair == j) continue;
                    if (playerHands[i].cardValue == playerHands[j].cardValue)
                    {
                        return true;
                    }
                }
            
            }
        }
        
        
        return false;
    }

    public bool threeOfAKind()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 1 + i; j < 5; j++)
            {
                for (int k = 1+j; k < 5; k++)
                {
                    if (playerHands[i].cardValue == playerHands[j].cardValue && playerHands[i].cardValue == playerHands[k].cardValue)
                    {
                        firstCardKind = i;
                        secCardPair = j;
                        thirdCardKind = k;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public bool foorOfAKind()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 1 + i; j < 5; j++)
            {
                for (int k = 1+j; k < 5; k++)
                {
                    for (int l = 1+k; l < 5; l++)
                    {
                        if (playerHands[i].cardValue == playerHands[j].cardValue && playerHands[i].cardValue == playerHands[k].cardValue&&playerHands[i].cardValue == playerHands[l].cardValue )
                        {
                         return true;
                        }
                        
                    }
                }
            }
        }

        return false;
    }

    public bool hasFlush()
    {
        if (playerHands[0].CardEnseigne == playerHands[1].CardEnseigne && playerHands[0].CardEnseigne == playerHands[2].CardEnseigne&& playerHands[0].CardEnseigne == playerHands[3].CardEnseigne &&playerHands[0].CardEnseigne == playerHands[4].CardEnseigne)
        {
            return true;
        }
        return false;
    }

    public bool hasStraight()
    {
        Array.Sort(playerHandsValue);

        if (playerHandsValue[0]+1 == playerHandsValue[1] && playerHandsValue[0] + 2 == playerHandsValue[2]&&playerHandsValue[0] + 3 == playerHandsValue[3]&&playerHandsValue[0] + 4 == playerHandsValue[4])
        {
            return true;
        }
        return false;
    }

    public bool hasHouse()
    {
        if (threeOfAKind())
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    
                    if (playerHands[i].cardValue != playerHands[j].cardValue)
                    {
                        
                        return true;
                    }
                }
            }
        }
        
        return false;
    }

    private void Start()
    {
        
    }

    private void Update()
    {

        for (int i = 0; i < playerHands.Length; i++)
        {
            playerHandsValue[i] = playerHands[i].cardValue;
        }

        if (foorOfAKind())
        {
            comboIndicator.text = "Four of a Kind ! ";
        }
        else if(hasHouse())
        {
            comboIndicator.text = "Full House ! ";
        }
        else if (hasFlush())
        {
            comboIndicator.text = "Flush !";
        }
        else if (hasStraight())
        {
            comboIndicator.text = "Straight !";
        }
        else if (threeOfAKind())
        {  
            comboIndicator.text = "Three of a Kind !";
        }
        else if(hasTwoPair())
        {
            comboIndicator.text = "Two Pair !";
        }
        else if (hasPair())
        {
            comboIndicator.text = "Pair !";
        }
        else
        {
            comboIndicator.text = "High Card !";
        }
       
    }
}
