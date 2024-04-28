using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [SerializeField] public CarteManager cartemanager;
    [SerializeField] public GameStateManager gameStateManager;
    [SerializeField] private GameObject[] itemButton;


    public void UsingFirstItem()
    {
        gameStateManager.PlayerAction++;
        itemButton[0].SetActive(false);

    }
}
