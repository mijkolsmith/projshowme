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
        if (activatedTrigger1.trigger && activatedTrigger2.trigger && activatedTrigger3.trigger == true)
        {
            Destroy(this.gameObject);
        }
    }
}
