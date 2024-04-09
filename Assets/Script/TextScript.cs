using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    
    [SerializeField] private GameObject roundTextPos;
    private float delay = 1;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            transform.position = Vector3.Lerp(transform.position, roundTextPos.transform.position, 2f * Time.deltaTime);

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 2f * Time.deltaTime);
        }
    }
}
