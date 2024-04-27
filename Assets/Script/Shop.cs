using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   [SerializeField] public GameStateManager gameStateManager;
   [SerializeField] public Button[] itemBuyButtons;
   [SerializeField] public GameObject[] itemUseButtons;

   public void CloseShop()
   {
      Application.Quit();
   }

   public void BuyingFirstItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         itemUseButtons[0].SetActive(true);
         gameStateManager.playerGold -= 5;
      }
   }
   public void BuyingSecondItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         itemUseButtons[1].SetActive(true);
         gameStateManager.playerGold -= 5;
      }
   }
   public void BuyingThirdItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         itemUseButtons[2].SetActive(true);
         gameStateManager.playerGold -= 5;
      }
   }
   public void BuyingFourthItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         itemUseButtons[3].SetActive(true);
         gameStateManager.playerGold -= 5;
      }
   }
}
