using System.Collections;
using System.Collections.generic;
using UnityEngine;

public class QuicktimeEvent : Monobehaviour
{
	public GameObject sphere;
	public Material material;

	private Renderer renderer;

	float probability;
	int reactionFrames

	void Start()
	{
		renderer = sphere.GetComponent<Renderer>();
		//renderer.isVisible = false; ??
		probability = 0.3;
		reactionFrames = 0;
	}

	void Update()
	{
		if (reactionFrames > 0)
		{
			reactionFrames--;
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position)

				if (Physics.RaycastHit(ray, out RaycastHit hit)
				{
					renderer.material = material;
				}
			}
		}
		else
		{
			if (Random.value < probability)
			{
				reactionFrames = 120;
				//renderer.isVisible = true; ??
			}
	}
}	
