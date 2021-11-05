using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishText : MonoBehaviour
{
    public GameObject finishText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Show finish text   
        finishText.SetActive(true);
    }
}
