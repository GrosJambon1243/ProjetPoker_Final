using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   [SerializeField] public GameStateManager gameStateManager;
   [SerializeField] public Button[] itemBuyButtons;
   [SerializeField] public GameObject[] itemUseButtons;
   [SerializeField] private AudioSource buyingSound;

   public void CloseShop()
   {
      Application.Quit();
   }

   public void BuyingFirstItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         buyingSound.Play();
         itemUseButtons[0].SetActive(true);
         gameStateManager.playerGold -= 5;
      }
   }
   public void BuyingSecondItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         buyingSound.Play();
         itemUseButtons[1].SetActive(true);
         gameStateManager.playerGold -= 5;
      }
   }
   public void BuyingThirdItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         buyingSound.Play();
         itemUseButtons[2].SetActive(true);
         gameStateManager.playerGold -= 5;
         gameStateManager.doubleGold = true;
      }
   }
   public void BuyingFourthItem()
   {
      if (gameStateManager.playerGold >= 5)
      {
         buyingSound.Play();
         itemUseButtons[3].SetActive(true);
         gameStateManager.playerGold -= 5;
      }
   }
}
