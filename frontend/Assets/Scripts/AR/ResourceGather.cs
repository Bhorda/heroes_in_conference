using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
    private int hackCounter = 0;
    // Only used if made several targets on screen at same time
    //private string objectName;

    public GameObject sphere;
    public Material collected;

    private Material material;
    
    // Start is called before the first frame update
    void Start()
    {
        material = sphere.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (hackCounter <= 3)
        {
            CollectChecker();
        }
    }

    private void CollectChecker()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                hackCounter++;
            }

            if (hackCounter == 3)
            {
                material = collected;
            }
        }
    }
}
