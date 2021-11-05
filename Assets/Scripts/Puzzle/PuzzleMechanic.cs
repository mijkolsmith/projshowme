using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanic : MonoBehaviour
{
    public bool trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
    }
}
