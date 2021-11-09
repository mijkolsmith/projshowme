using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanic : MonoBehaviour
{
    public Player triggerOccupied = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerOccupied == null)
        {
            triggerOccupied = collision.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerOccupied == collision.GetComponent<Player>())
        {
            triggerOccupied = null;
        }
    }
}
