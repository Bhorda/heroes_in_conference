using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingInventory : MonoBehaviour
{
    void Start()
    {
        if (!NetworkDatabase.NDB.GetAchievementObjByName("Taking inventory...").Won)
        {
            gameObject.SetActive(true);
            NetworkDatabase.NDB.SetAchievement(NetworkDatabase.NDB.GetAchievementIdByName("Taking inventory..."));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
