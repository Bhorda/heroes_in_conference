using System.Collections;
using Sytem.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
	private bool touch, up, down, left, right, inMotion;
	private Vector2 origin, delta;	

	void Start()
	{
		touch = up = down = left = right = false;

		// Detect touch
		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				touch = inMotion = true;
				origin = Input.GetTouch(0).position;
			}
			else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				inMotion = false;
				Reset();
			}
			
			delta = Input.GetTouch(0).position - origin;
		}

		if (delta.magnitude > 150)
		{
			float x = delta.x;
			float y = delta.y;

			if (Mathf.Abs(x) > Mathf.Abs(y))
			{
				if (x > 0) right = true;
				else left = true;		
			}
			else
			{
				if (y > 0) up = true;
				else down = true;
			}

			Reset();
		}
	}

	private void Reset()
	{
		origin = delta = Vector2.zero;
		inMotion = false;
	}

	public bool GetUp()
	{
		return up;
	}

	public bool GetDown()
	{
		return down;
	}

	public bool GetLeft()
	{
		return left;
	}

	public bool GetRight()
	{
		return right;
	}
}
