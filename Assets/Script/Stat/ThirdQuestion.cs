using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThirdQuestion : MonoBehaviour
{
    [SerializeField] private TMP_Text selectCombo;
    [SerializeField] private TMP_Text selectCombo2;
    [SerializeField] private TMP_Text result;
    [SerializeField] private TMP_Text selectCombo3;
    [SerializeField] private TMP_Text selectCombo4;
    [SerializeField] private TMP_Text result2;
    List<CarteData> pile = new List<CarteData>(52);
    private int cardsPerHand = 5;
    private int firstCard;
    private int secCard;
    private int desireHand;
    private int numbSimulation = 10000;
    private List<CarteData> hand;
    private int firstCardKind;
    private int secCardKind;
    private int thirdCardKind;
    private double betterThan;

    private void Awake()
    {
       GenerateDeck();
    }
    public void CalculateButtonBetter()
    {
       betterThan = 0;
       switch (selectCombo3.text)
       {
          case "Pair":
             CalculatingTwoPair();
             CalculatingThreeKind();
             CalculatingStraight();
             CalculatingFlush();
             CalculatingHouse();
             CalculatingFourKind();
             CalculatingStraightFLush();
             CalculatingStraightFLushRoyal();
             break;
          case "Two Pair":
             CalculatingThreeKind();
             CalculatingStraight();
             CalculatingFlush();
             CalculatingHouse();
             CalculatingFourKind();
             CalculatingStraightFLush();
             CalculatingStraightFLushRoyal();
             break;
          case"Three Of A Kind":
             CalculatingStraight();
             CalculatingFlush();
             CalculatingHouse();
             CalculatingFourKind();
             CalculatingStraightFLush();
             CalculatingStraightFLushRoyal();
             break;
          case"Straight":
             CalculatingFlush();
             CalculatingHouse();
             CalculatingFourKind();
             CalculatingStraightFLush();
             CalculatingStraightFLushRoyal();
             break;
          case "Flush":
             CalculatingHouse();
             CalculatingFourKind();
             CalculatingStraightFLush();
             CalculatingStraightFLushRoyal();
             break;
          case "Full House":
             CalculatingFourKind();
             CalculatingStraightFLush();
             CalculatingStraightFLushRoyal();
             break;
          case "Four Of A Kind":
             CalculatingStraightFLush();
             CalculatingStraightFLushRoyal();
             break;
          case "Straight Flush":
             CalculatingStraightFLushRoyal();
             break;
          case "Royal Flush":
             CalculatingStraightFLushRoyal();
             break;
            
       }

       result2.text = betterThan + " %";
    }

    public void deleteCardBetter()
    {
       switch (selectCombo4.text)
        {
            case "A":
                pile.RemoveAll(card => card.valeur == 0);
                break;
            case "2":
                for (int i = 0; i < 2; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
               
                break;
            case "3":
                for (int i = 0; i < 3; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "4":
                for (int i = 0; i < 4; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "5":
                for (int i = 0; i < 5; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "6":
                for (int i = 0; i < 6; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "7":
                for (int i = 0; i < 7; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "8":
                for (int i = 0; i < 8; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "9":
                for (int i = 0; i < 9; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "10":
                for (int i = 0; i < 10; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "J":
                for (int i = 0; i < 11; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
           
        }
    }
    public void CalculateButton()
    {
       switch (selectCombo.text)
       {
          case "Pair":
             CalculatingPair();
             break;
          case "Two Pair":
             CalculatingTwoPair();
             break;
          case"Three Of A Kind":
             CalculatingThreeKind();
             break;
          case"Straight":
             CalculatingStraight();
             break;
          case "Flush":
             CalculatingFlush();
             break;
          case "Full House":
             CalculatingHouse();
             break;
          case "Four Of A Kind":
             CalculatingFourKind();
             break;
          case "Straight Flush":
             CalculatingStraightFLush();
             break;
          case "Royal Flush":
             CalculatingStraightFLushRoyal();
             break;
            
       }
      
    }
    public void GenerateDeck()
    {
       pile.Clear();
        for (int i = 0; i < 13; i++)
        {
            pile.Add(new CarteData(i,Enseigne.Carreau));
            pile.Add(new CarteData(i,Enseigne.Trefle));
            pile.Add(new CarteData(i,Enseigne.Coeur));
            pile.Add(new CarteData(i,Enseigne.Pique));
        }
       
    }
    public void deleteCard()
    {
        switch (selectCombo2.text)
        {
            case "A":
                pile.RemoveAll(card => card.valeur == 0);
                break;
            case "2":
                for (int i = 0; i < 2; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
               
                break;
            case "3":
                for (int i = 0; i < 3; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "4":
                for (int i = 0; i < 4; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "5":
                for (int i = 0; i < 5; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "6":
                for (int i = 0; i < 6; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "7":
                for (int i = 0; i < 7; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "8":
                for (int i = 0; i < 8; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "9":
                for (int i = 0; i < 9; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "10":
                for (int i = 0; i < 10; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
            case "J":
                for (int i = 0; i < 11; i++)
                {
                    pile.RemoveAll(card => card.valeur == i);
                }
                break;
           
        }
    }

    public void CalculateThirdQuestion()
    {
       deleteCard();
       CalculateButton();
       GenerateDeck();
    }

    public void CalculateFourthQuestion()
    {
       deleteCardBetter();
       CalculateButtonBetter();
       GenerateDeck();
    }
    
    List<CarteData> DrawHandFromPile()
   {
      
      List<CarteData> pileCopy = new List<CarteData>(pile);
      List<CarteData> newHand = new List<CarteData>();
      
      for (int i = 0; i < cardsPerHand; i++)
      {
         int randomIndex = Random.Range(0, pileCopy.Count);
         newHand.Add(pileCopy[randomIndex]);
         pileCopy.RemoveAt(randomIndex);
      }

      return newHand;
   }

   public bool hasPair(List<CarteData> hand)
   {
      for (int i = 0; i < 5; i++)
      {
         for (int j = i +1; j < 5; j++)
         {
            if (hand[i].valeur == hand[j].valeur)
            {
               firstCard = i;
               secCard = j;
               return true;
            }
         }
            
      }
      
      return false;
   }

   public void CalculatingPair()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasPair(hand))
         { 
            desireHand++;
         }
      }

      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }

   public bool hasTwoPair(List<CarteData> hand)
   {
      if (hasPair(hand))
      {
         for (int i = 0; i < 5; i++)
         {
            for (int j = 1 +i; j < 5; j++)
            {
               if (firstCard == i || secCard== j) continue;
               if (hand[i].valeur == hand[j].valeur)
               {
                  return true;
               }
            }
            
         }
      }

      return false;
   }

   public void CalculatingTwoPair()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasTwoPair(hand))
         { 
            desireHand++;
         }
      }
      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }

   public bool threeOfKind(List<CarteData> hand)
   {
      for (int i = 0; i < 5; i++)
      {
         for (int j = 1 + i; j < 5; j++)
         {
            for (int k = 1+j; k < 5; k++)
            {
               if (hand[i].valeur == hand[j].valeur && hand[i].valeur == hand[k].valeur)
               {
                  return true;
               }
            }
         }
      }

      return false;
   }
   public void CalculatingThreeKind()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation; i++)
      {

         hand = DrawHandFromPile();
         
         if (threeOfKind(hand))
         { 
            desireHand++;
         }
      }

      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }

   public bool hasStraight(List<CarteData> hand)
   {
      hand.Sort();
      if (hand[0].valeur +1 == hand[1].valeur && hand[0].valeur + 2== hand[2].valeur&&hand[0].valeur + 3 == hand[3].valeur&&hand[0].valeur +4 == hand[4].valeur)
      {
         return true;
      }
      return false;
   }
   public void CalculatingStraight()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasStraight(hand))
         { 
            desireHand++;
         }
      }

      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }

   public bool hasFlush(List<CarteData> hand)
   {
      if (hand[0].enseigne == hand[1].enseigne && hand[0].enseigne == hand[2].enseigne&& hand[0].enseigne == hand[3].enseigne &&hand[0].enseigne == hand[4].enseigne)
      {
         return true;
      }
      return false;
   }
   public void CalculatingFlush()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasFlush(hand))
         { 
            desireHand++;
         }
      }

      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }

   public bool hasHouse(List<CarteData> hand)
   {
     hand.Sort();
     if (hand[0].valeur == hand[1].valeur && hand[0].valeur == hand[2].valeur )
     {
        if (hand[3].valeur == hand[4].valeur)
        {
           return true;
        }
     }

     if (hand[2].valeur == hand[3].valeur && hand[2].valeur == hand[4].valeur)
     {
        if (hand[0].valeur == hand[1].valeur)
        {
           return true;
        }
     }
     return false;
   }
   public void CalculatingHouse()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasHouse(hand))
         { 
            desireHand++;
         }
      }

      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }

   public bool hasFourKind(List<CarteData> hand)
   {
      for (int i = 0; i < 5; i++)
      {
         for (int j = 1 + i; j < 5; j++)
         {
            for (int k = 1+j; k < 5; k++)
            {
               for (int l = 1+k; l < 5; l++)
               {
                  if (hand[i].valeur == hand[j].valeur && hand[i].valeur  == hand[k].valeur &&hand[i].valeur  == hand[l].valeur)
                  {
                     return true;
                  }
                        
               }
            }
         }
      }

      return false;
   }

   public void CalculatingFourKind()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasFourKind(hand))
         { 
            desireHand++;
         }
      }

      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }

   public bool hasStraightFlush(List<CarteData> hand)
   {
      return hasStraight(hand) && hasFlush(hand);
   }
   public void CalculatingStraightFLush()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation ; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasStraightFlush(hand))
         { 
            desireHand++;
         }
      }

      double probability = ((double)desireHand / numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }
   public bool hasStraightFlushRoyal(List<CarteData> hand)
   {
      return hasStraight(hand) && hasFlush(hand) && hand[0].valeur == 10;
   }
   public void CalculatingStraightFLushRoyal()
   {
      desireHand = 0;
      for (int i = 0; i < numbSimulation ; i++)
      {

         hand = DrawHandFromPile();
         
         if (hasStraightFlushRoyal(hand))
         { 
            desireHand++;
         }
      }
      
      ulong probability = ((ulong)desireHand / (ulong)numbSimulation)*100;
      betterThan += probability;
      result.text = probability + " %";
   }
}


