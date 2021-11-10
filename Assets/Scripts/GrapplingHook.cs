using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Player player;
    bool colliding;
    Vector3 dir;

    public void ExecuteCoroutine(Player player)
    {
        this.player = player;

        dir = player.GetComponentInChildren<Camera>().ScreenToWorldPoint(Input.mousePosition) - player.transform.localPosition;
        float angleRad;
        float angleDeg;
        if (player.facingRight)
        {
            angleRad = Mathf.Atan2(-dir.y, -dir.x);
            angleDeg = (180 / Mathf.PI) * angleRad;
        }
        else
		{
            angleRad = Mathf.Atan2(-dir.y, dir.x);
            angleDeg = (180 / Mathf.PI) * angleRad;
        }
        transform.parent.localRotation = Quaternion.Euler(0, 0, angleDeg);

        StartCoroutine(GrapplingHookDisable());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && colliding == false)
        {
            colliding = true;
            Rigidbody2D targetRB = collision.GetComponent<Rigidbody2D>();
            targetRB.AddForce(new Vector2(-dir.normalized.x * 5000f, -dir.normalized.y * 2500f));

            colliding = false;
            transform.parent.localRotation = Quaternion.identity;
            transform.parent.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator GrapplingHookDisable()
    {
        for (int i = 0; i < 50; i++)
		{
            transform.parent.localScale = new Vector3(transform.parent.localScale.x + 0.4f - i/100f, transform.parent.localScale.y, transform.parent.localScale.z);
            yield return new WaitForSeconds(.000001f);
        }

        transform.parent.localRotation = Quaternion.identity;
        transform.parent.localScale = new Vector3(1, 1, 1);
        gameObject.SetActive(false);
    }
}
