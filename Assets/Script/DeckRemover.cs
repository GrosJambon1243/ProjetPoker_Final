using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckRemover : MonoBehaviour
{
    [SerializeField] private CarteManager deck;
    [SerializeField] private TMP_Text carteToRemove;
   
    public void RemoveButton()
    {
        deleteCard();
        gameObject.SetActive(false);
    }

    public void deleteCard()
    {
        var temp = new List<CarteData>();
        temp = deck.deck;
        switch (carteToRemove.text)
        {
            case "Ace":
                temp.RemoveAll(card => card.valeur == 1);
                break;
            case "2":
                temp.RemoveAll(card => card.valeur == 2);
                break;
            case "3":
                temp.RemoveAll(card => card.valeur == 3);
                break;
            case "4":
                temp.RemoveAll(card => card.valeur == 4);
                break;
            case "5":
                temp.RemoveAll(card => card.valeur == 5);
                break;
            case "6":
                temp.RemoveAll(card => card.valeur == 6);
                break;
            case "7":
                temp.RemoveAll(card => card.valeur == 7);
                break;
            case "8":
                temp.RemoveAll(card => card.valeur == 8);
                break;
            case "9":
                temp.RemoveAll(card => card.valeur == 9);
                break;
            case "10":
                temp.RemoveAll(card => card.valeur == 10);
                break;
            case "11":
                temp.RemoveAll(card => card.valeur == 11);
                break;
            case "12":
                temp.RemoveAll(card => card.valeur == 12);
                break;
            case "13":
                temp.RemoveAll(card => card.valeur == 13);
                break;
        }

        deck.deck = temp;
        
    }
}
