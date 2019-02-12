using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    public Swipe swipe;
    public Transform box;

    private Vector3 moveTo;

    // Start is called before the first frame update
    void Start()
    {
        moveTo = box.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveTo = Vector3.zero;
        if (swipe.getLeft())
        {
            moveTo += new Vector3(-20, 0, 0);
        }
        if (swipe.getRight())
        {
            moveTo += new Vector3(20, 0, 0);
        }
        if (swipe.getUp())
        {
            moveTo += new Vector3(0, 0, 20);
        }
        if (swipe.getDown())
        {
            moveTo += new Vector3(0, 0, -20);
        }

        box.transform.position = Vector3.MoveTowards(box.position, box.position + 5*moveTo, 3f * Time.deltaTime);
    }
}
