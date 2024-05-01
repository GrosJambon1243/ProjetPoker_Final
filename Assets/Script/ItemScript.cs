using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [SerializeField] public CarteManager cartemanager;
    [SerializeField] public GameStateManager gameStateManager;
    [SerializeField] private GameObject[] itemButton;
    [SerializeField] private GameObject remover;

    public void UsingFirstItem()
    {
        gameStateManager.PlayerAction++;
        itemButton[0].SetActive(false);

    }

    public void UsingSecondItem()
    {
        for (int i = 0; i < 5; i++)
        {
            if (cartemanager.main[i].isHeld)
            {
                continue;
            }
            Debug.Log("Lol");
            
            cartemanager.main[i].SetData(new CarteData(1,Enseigne.Coeur));
            break;
        }
        itemButton[1].SetActive(false);
    }

    public void UsingThirdItem()
    {
        remover.SetActive(true);
        
        itemButton[3].SetActive(false);
    }
    
}
