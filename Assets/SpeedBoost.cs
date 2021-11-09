using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    Player player;
    List<Player> players;

	private void Start()
	{
        player = GetComponentInParent<Player>();
        players = player.players;
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var playerComp in players)
        {
            if (collision.gameObject == playerComp.gameObject)
            {
                player.speedBoost += 44;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var playerComp in players)
        {
            if (collision.gameObject == playerComp.gameObject)
            {
                player.speedBoost -= 44;
            }
        }
    }
}
