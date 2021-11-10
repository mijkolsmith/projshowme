using System.Collections;
using UnityEngine;

public class DisablePlatform : MonoBehaviour
{
	public IEnumerator Disable()
	{
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		yield return new WaitForSeconds(.5f);
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}
}