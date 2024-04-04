using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   [SerializeField] private Canvas mainCanvas;
   [SerializeField] private Canvas shopCanvas;

   public void OpenShop()
   {
      mainCanvas.enabled = false;
      shopCanvas.enabled = true;
      
      
   }

   public void CloseShop()
   {
      mainCanvas.enabled = true;
      shopCanvas.enabled = false;
   }
}
