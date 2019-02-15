using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
	public GameObject resource;
	public Material collected;	

	int hitCounter;
	Renderer renderer;

	void Start()
	{
		hitCounter = 0;
		renderer = resource.GetComponent<Renderer>();
	}

	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).posiiton);

			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				hitCounter++;
			}

			if (hitCounter == 3)
			{
				renderer.material = collected;
			}
		}
	}
}
