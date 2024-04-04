using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Enseigne
{
    Coeur,
    Pique,
    Carreau,
    Trefle
}
    
public class CarteData : IComparable<CarteData>
{
    public int valeur;
    public Enseigne enseigne;

    public CarteData(int valeur,Enseigne enseigne)
    {
        this.valeur = valeur;
        this.enseigne = enseigne;
    }

    public int CompareTo(CarteData other)
    {
        return valeur.CompareTo(other.valeur);
    }
}
public class Carte : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TMP_Text valeurText;

    [SerializeField] private TMP_Text enseigneText;
    [SerializeField] private TMP_Text heldText;
    [SerializeField] private Image cardBackg;
    public bool isHeld;

    private void Awake()
    {
        heldText.enabled = false;
    }

    internal void SetData(CarteData carteData)
    {
        string valeurString = carteData.valeur.ToString();
        string enseigneString = "";
        switch (carteData.valeur)
        {
            case 1:
                valeurString = "A";
                break;
            case 11:
                valeurString = "J";
                break;
            case 12:
                valeurString = "Q";
                break;
            case 13:
                valeurString = "K";
                break;
        }

        valeurText.text = valeurString;
        Color colorEnseigne = Color.red;
        switch (carteData.enseigne)
        {
            case Enseigne.Carreau:
                enseigneString = "\u2666";
                break;
            case Enseigne.Coeur:
                enseigneString = "\u2665";
                break;
            case Enseigne.Pique:
                enseigneString = "\u2660";
                colorEnseigne = Color.black;
                break;
            case Enseigne.Trefle:
                enseigneString = "\u2663"; 
                colorEnseigne = Color.black;
                break;
        }

        enseigneText.color = colorEnseigne;
        enseigneText.text = enseigneString;
        valeurText.color = colorEnseigne;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = !isHeld;
        heldText.enabled = isHeld;
        if (isHeld)
        {
            cardBackg.color = Color.gray;
        }
        else
        {
            cardBackg.color = Color.white;
            
        }
        
    }

    public void ClearHeld()
    {
        isHeld = false;
        heldText.enabled = false;
        cardBackg.color = Color.white;
    }
}
