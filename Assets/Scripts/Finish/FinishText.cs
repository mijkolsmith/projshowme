using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishText : MonoBehaviour
{
    private int laps = 4;
    public GameObject finishText1;
    public GameObject finishText2;
    public GameObject finishText3;
    private int count1 = 0;
    private int count2 = 0;
    private int count3 = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
		{
            count1++;
		}
        if (collision.gameObject.name == "Player2")
        {
            count2++;
        }
        if (collision.gameObject.name == "Player3")
        {
            count3++;
        }
        // Show finish text   
        if (count1 >= laps)
        {
            finishText1.SetActive(true);
        }
        if (count2 >= laps)
        {
            finishText2.SetActive(true);
        }
        if (count3 >= laps)
        {
            finishText3.SetActive(true);
        }
    }
}