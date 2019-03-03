using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore1 : MonoBehaviour
{
    public GameObject resource;
    public GameObject obj;
    public GameObject resourceCollected;

    int hitCounter;

	void Start()
	{
        hitCounter = 0;
        resource.SetActive(!NetworkDatabase.NDB.GetAchievementObjByName("Grumpy").Won);
        obj.SetActive(!NetworkDatabase.NDB.GetAchievementObjByName("Grumpy").Won);
        resourceCollected.SetActive(NetworkDatabase.NDB.GetAchievementObjByName("Grumpy").Won);
	}

	void Update()
	{
        if (ARHandler.GetHitIfAny().Equals(resource.name))
        {
            hitCounter++;
        }

		if (hitCounter == 3)
		{
            Destroy(resource);
            resourceCollected.SetActive(true);
            Destroy(obj);
            ARHandler.GetAchievement("Grumpy");
		}
	}
}
