using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlatform : MonoBehaviour
{
	public bool standingOnPlatform;

	public IEnumerator Disable()
	{
		standingOnPlatform = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		yield return new WaitForSeconds(.5f);
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}
}
