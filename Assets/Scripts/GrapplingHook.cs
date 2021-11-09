using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{   
    private void Update()
    {
        StartCoroutine(GrapplingHookDisable());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector2(gameObject.transform.position.x - 2, collision.transform.position.y);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator GrapplingHookDisable()
    {
        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}
