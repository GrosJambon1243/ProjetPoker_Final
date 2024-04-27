using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    
    [SerializeField] private GameObject roundTextPos;
    private float delay = 2;
    private float timer;
    private Vector3 originalTransform;
    

    private void Start()
    {
        originalTransform = transform.position;
    }

    private void Update()
    {
       // StartOfRoundAnim();
    }

    public void StartOfRoundAnim()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            transform.position = Vector3.Lerp(transform.position, roundTextPos.transform.position, 2f * Time.deltaTime);

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 2f * Time.deltaTime);
        }
    }

    public void ResetAnim()
    {
        transform.position = originalTransform;
        transform.localScale = new Vector3(2,2,2);
        timer = 0;
    }
}
