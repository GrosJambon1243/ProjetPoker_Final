using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WInnigScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text winnigText;
    private float interval = 0.1f;
    void Start()
    {
        StartCoroutine(ColorSwitch());
    }

    IEnumerator ColorSwitch()
    {
        while (true)
        {
            winnigText.color = Color.red;
            yield return new WaitForSeconds(interval);
            winnigText.color = Color.blue;
            yield return new WaitForSeconds(interval);
            winnigText.color = Color.green;
            yield return new WaitForSeconds(interval);
            winnigText.color = Color.yellow;
            yield return new WaitForSeconds(interval);
            winnigText.color = Color.cyan;
            yield return new WaitForSeconds(interval);
            winnigText.color = Color.magenta;
            yield return new WaitForSeconds(interval);
        }
    }
}
