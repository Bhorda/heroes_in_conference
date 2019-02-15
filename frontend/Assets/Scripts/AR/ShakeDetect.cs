using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetect : MonoBehaviour
{
	public GameObject sphere;
	public Material material;

	Renderer renderer;

	// How often to update the accelerometer
	float updateAcceleration = 1.0f / 60.0f;
	// Threshold for magnitude of shake vector
	float minShake;
	// Value of filter vector
	Vector3 lowPassValue;
	// Acceleration vectors
	Vector3 acceleration;
	Vector3 deltaAcceleration;

	void Start()
	{
		lowPassValue = Input.acceleration;
		// Recommended value according to certain manufacturers
		minShake = 2.0f;
		renderer = sphere.GetComponent<Renderer>();
	}

	void Update()
	{
		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, updateAcceleration);
		deltaAcceleration = acceleration - lowPassValue;

		if (deltaAcceleration.sqrMagnitude >= minShake)
		{
			renderer.material = material;
		}
	}
}
