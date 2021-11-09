using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    private Player player;
    public float boost = 4f;
    DisablePlatform disablePlatform;

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
            }
        }

        // Crouch
        /*if (collision.gameObject.layer == 3) // 3 for ground
        {
            Debug.Log(collision.gameObject.name + " enter");
            if (disablePlatform == null)
            {
                disablePlatform = collision.gameObject.GetComponent<DisablePlatform>();
            }
            if (disablePlatform != null)
            {
                disablePlatform.standingOnPlatform = true;
            }
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // SpeedBoost
        foreach (Player playerComponent in player.players)
        {
            if (collision.gameObject == playerComponent.gameObject)
            {
                player.speedBoost -= boost;
            }
        }

        // Crouch
        /*if (collision.gameObject.layer == 3) // 3 for ground
        {
            Debug.Log(collision.name + " exit");
            if (disablePlatform != null)
            {
                disablePlatform = null;
                disablePlatform.standingOnPlatform = false;
            }
        }*/
    }
}