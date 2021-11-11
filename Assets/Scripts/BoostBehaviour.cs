using UnityEngine;

public class BoostBehaviour : MonoBehaviour
{
    private Player player;
    public float boost = 4f;

    private void Start()
	{
        player = GetComponentInParent<Player>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        // SpeedBoost
        foreach (Player playerComponent in player.players)
        {
            if (collision.gameObject == playerComponent.gameObject)
            {
                player.speedBoost += boost;
                if(player.speedBoost == boost)
				{
                    player.speedBoost2p.SetActive(true);
				}
                else if(player.speedBoost == boost * 2)
                {
                    player.speedBoost3p.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // SpeedBoost
        foreach (Player playerComponent in player.players)
        {
            if (collision.gameObject == playerComponent.gameObject)
            {
                player.speedBoost -= boost;
                if (player.speedBoost == boost)
                {
                    player.speedBoost3p.SetActive(false);
                }
                if (player.speedBoost == 0)
                {
                    player.speedBoost2p.SetActive(false);
                }
            }
        }
    }
}