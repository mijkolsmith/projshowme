using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    bool colliding;
    Vector3 dir;
    Transform rotate;
    public GameObject ropeLoop;

    public void ExecuteCoroutine(Player player, Transform rotate)
    {
        this.rotate = rotate;

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
        rotate.localRotation = Quaternion.Euler(0, 0, angleDeg);

        StartCoroutine(GrapplingHookDisable());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && colliding == false)
        {
            colliding = true;
            Rigidbody2D targetRB = collision.GetComponent<Rigidbody2D>();
            targetRB.AddForce(new Vector2(-dir.normalized.x * 5000f, -dir.normalized.y * 2500f));

            
            rotate.localRotation = Quaternion.identity;
            transform.parent.localScale = new Vector3(1, 1, 1);
            colliding = false;
            rotate.gameObject.SetActive(false);
        }
    }

    private IEnumerator GrapplingHookDisable()
    {
        for (int i = 0; i < 50; i++)
		{
            float scaleChange = transform.parent.localScale.x + 0.4f - i / 100f;
            transform.parent.localScale = new Vector3(scaleChange, transform.parent.localScale.y, transform.parent.localScale.z);
            ropeLoop.transform.localPosition = new Vector3(transform.parent.localScale.x / -2f - 1f, ropeLoop.transform.localPosition.y, ropeLoop.transform.localPosition.z);
            //Scale = 1 Pos = -1.5
            //Scale = 2 Pos = -2
            //Scale = 3 Pos = -2.5
            //Scale = 4 Pos = -3
            //Scale = 5 Pos = -3.5
            yield return new WaitForSeconds(.000001f);
        }

        ropeLoop.transform.localPosition = new Vector3(-1.5f, 0f, -1f);
        rotate.localRotation = Quaternion.identity;
        transform.parent.localScale = new Vector3(1f, 1f, 1f);
        rotate.gameObject.SetActive(false);
    }
}
