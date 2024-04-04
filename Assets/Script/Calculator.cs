using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
   private float flushCounter = 0;

   private void Awake()
   {
      List<CarteData> pile = new List<CarteData>(52);
      for (int i = 0; i < 13; i++)
      {
         pile.Add(new CarteData(i,Enseigne.Carreau));
         pile.Add(new CarteData(i,Enseigne.Trefle));
         pile.Add(new CarteData(i,Enseigne.Coeur));
         pile.Add(new CarteData(i,Enseigne.Pique));
      }

      List<List<CarteData>> combos = new List<List<CarteData>>();

      for (int i = 0; i < pile.Count; i++)
      {
         for (int j = 1 + i; j < pile.Count; j++)
         {
            for (int k = 1 + j; k < pile.Count; k++)
            {
               for (int l = 1 + k; l < pile.Count; l++)
               {
                  for (int m = 1 + l; m < pile.Count; m++)
                  {
                     var combo = new List<CarteData>()
                     {
                        pile[i], pile[j], pile[k], pile[l], pile[m]
                     };
                     combos.Sort();
                     combos.Add(combo);
                  }
               }
            }
         }
      }

      foreach (var varCombo in combos)
      {
         if (varCombo[0].enseigne == varCombo[1].enseigne&&varCombo[0].enseigne == varCombo[2].enseigne && varCombo[0].enseigne == varCombo[3].enseigne&&varCombo[0].enseigne == varCombo[4].enseigne)
         {
            flushCounter++;
            continue;
         }
      }

      var flushCalcul = flushCounter / combos.Count;
      Debug.Log(flushCalcul);
   }
}
