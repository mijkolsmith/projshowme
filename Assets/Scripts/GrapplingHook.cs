using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        StartCoroutine(GrapplingHookDisable());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D targetRB = collision.GetComponent<Rigidbody2D>();
            if (player.facingRight)
            {
                targetRB.AddForce(new Vector2(2000f, 400f));
            }
            else
            {
                targetRB.AddForce(new Vector2(-2000f, 400f));
            }
            gameObject.SetActive(false);
        }
    }

    private IEnumerator GrapplingHookDisable()
    {
        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}
