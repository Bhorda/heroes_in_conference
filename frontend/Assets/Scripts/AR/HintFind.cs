using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class HintFind : MonoBehaviour
{
	public GameObject sphere;
	public Material collected;
	public AudioSource audioSource;
	public AudioClip complete;
	public AudioClip incomplete;

	string hintNode;
	Renderer sphereRenderer;

	void Start()
	{
		sphereRenderer = sphere.GetComponent<Renderer>();
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

			if (Physics.Raycast(ray, out RaycastHit hit)
			{
				hintNode = hit.transform.name;

				switch (hintNode)
				{
					case "hintX" :
						sphereRenderer.material = collected;
						
						// TODO inventory update, animation, add achievement, disintegration animation
						break;
				}
			}
		}
	}
}
