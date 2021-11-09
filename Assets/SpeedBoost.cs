using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    Player player;

	private void Start()
	{
        player = GetComponentInParent<Player>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (Player playerComponent in player.players)
        {
            if (collision.gameObject == playerComponent.gameObject)
            {
                player.speedBoost += 4;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Player playerComponent in player.players)
        {
            if (collision.gameObject == playerComponent.gameObject)
            {
                player.speedBoost -= 4;
            }
        }
    }
}
