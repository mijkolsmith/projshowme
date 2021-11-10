using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public Player player;
	private Vector2 startPos;

	private void Start()
	{
		startPos = transform.localPosition;
	}

	private void Update()
	{
		transform.localPosition = new Vector2(startPos.x + player.transform.localPosition.x * 40, startPos.y + player.transform.localPosition.y * 40);
	}
}