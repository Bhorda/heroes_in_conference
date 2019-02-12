using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool touch, left, right, up, down;
    private bool inMotion;
    private Vector2 origin, delta;

    // Update is called once per frame
    void Update()
    {
        touch = left = right = up = down = false;

        // Detect touch state
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                touch = true;
                inMotion = true;
                origin = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                inMotion = false;
                Reset();
            }
        }

        // Calculate distance of motion
        delta = Vector2.zero;
        if (inMotion)
        {
            if (Input.touchCount > 0)
            {
                delta = Input.touches[0].position - origin;
            }
        }

        if (delta.magnitude > 150)
        {
            float x = delta.x;
            float y = delta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    right = true;
                }
                else
                {
                    left = true;
                }
            }
            else
            {
                if (y > 0)
                {
                    up = true;
                }
                else
                {
                    down = true;
                }
            }

            Reset();
        }
    }

    private void Reset()
    {
        origin = delta = Vector2.zero;
        inMotion = false;
    }

    public bool getLeft()
    {
        return left;
    }

    public bool getRight()
    {
        return right;
    }

    public bool getUp()
    {
        return up;
    }

    public bool getDown()
    {
        return down;
    }
}
