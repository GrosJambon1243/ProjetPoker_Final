using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatingScript : MonoBehaviour
{
    [SerializeField] private TMP_Text calculText;
    private float dotInterval = 0.5f;
    void Start()
    {
       Coroutine();
    }

    public void Coroutine()
    {
        StartCoroutine(AnimateDot());
    }

    IEnumerator AnimateDot()
    {
        while (true)
        {
            calculText.text = "Calculating...";

            yield return new WaitForSeconds(dotInterval);
            
            calculText.text = "Calculating";

            yield return new WaitForSeconds(dotInterval);
            
            calculText.text = "Calculating.";

            yield return new WaitForSeconds(dotInterval);
            
            calculText.text = "Calculating..";

            yield return new WaitForSeconds(dotInterval);
        }
    }
}
