using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishText : MonoBehaviour
{
    public GameObject finishText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        finishText.SetActive(true);
    }
}
