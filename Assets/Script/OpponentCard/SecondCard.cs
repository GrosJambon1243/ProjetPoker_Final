using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCard : MonoBehaviour
{
    private Image theImage;
    [SerializeField] private Sprite newCard;
    // Start is called before the first frame update
    void Start()
    {
        theImage = gameObject.GetComponent<Image>();
    }

   
    public void ChangingCardImage()
    {
        theImage.sprite = newCard;
    }
}
