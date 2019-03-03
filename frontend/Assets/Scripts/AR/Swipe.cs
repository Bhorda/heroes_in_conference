using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
	private bool touch, up, down, left, right;
	private Vector2 origin, delta;	

	void Update()
	{
            touch = up = down = left = right = false;

		// Detect touch
		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				touch =true;
				origin = Input.GetTouch(0).position;
			}
			else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				Reset();
			}
			
			delta = Input.GetTouch(0).position - origin;
		}

		// Check if swipe vector is past deadzone
		if (delta.magnitude > 20)
		{
			float x = delta.x;
			float y = delta.y;

			// Act accordingly for the directions
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
