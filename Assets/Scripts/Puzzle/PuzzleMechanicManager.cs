using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanicManager : MonoBehaviour
{
    public PuzzleMechanic activatedTrigger1;
    public PuzzleMechanic activatedTrigger2;
    public PuzzleMechanic activatedTrigger3;

    // Update is called once per frame
    void Update()
    {
        // If all triggers from PuzzleMechanic script are activated, open the wall
        if (activatedTrigger1.triggerOccupied && activatedTrigger2.triggerOccupied && activatedTrigger3.triggerOccupied == true)
        {
            Destroy(this.gameObject);
        }
    }
}
