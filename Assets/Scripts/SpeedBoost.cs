using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private Player player;
    public float boost = 4f;

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
                player.speedBoost += boost;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Player playerComponent in player.players)
        {
            if (collision.gameObject == playerComponent.gameObject)
            {
                player.speedBoost -= boost;
            }
        }
    }
}