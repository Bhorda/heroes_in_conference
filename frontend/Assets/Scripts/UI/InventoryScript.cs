using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryScript : MonoBehaviour
{
    public bool[] slotFull;
    public GameObject[] slot;
    public void goBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Start()
    {
        slotFull[0] = slotFull[1] = slotFull[2] = slotFull[3] = true; //resources
        slotFull[5] = true;
        DBAchievement YetiAchievement = NetworkDatabase.NDB.GetAchievementObjByName("Yeti slayer");
        if (YetiAchievement != null)
        {
            slotFull[4] = YetiAchievement.Won;
            slotFull[8] = YetiAchievement.Won;
            
        }
        DBAchievement YakAchievement = NetworkDatabase.NDB.GetAchievementObjByName("Yak whisperer");
        if (YakAchievement != null)
        {
            slotFull[6] = YakAchievement.Won;
            slotFull[7] = YakAchievement.Won;
            slotFull[10]=YakAchievement.Won;
        }
        DBAchievement ZygAchievement=NetworkDatabase.NDB.GetAchievementObjByName("TNT I'm Zygomite");
        if(ZygAchievement!=null)
        {
            slotFull[9]=ZygAchievement.Won;
            slotFull[12]=ZygAchievement.Won;
        }
        DBAchievement CrabAchievement=NetworkDatabase.NDB.GetAchievementObjByName("Crab rave");
        if(CrabAchievement!=null)
        {
            slotFull[11]=CrabAchievement.Won;
            slotFull[13]=CrabAchievement.Won;
        }
        for (int i = 0; i < slotFull.Length; i++)
        {
            slot[i].SetActive(slotFull[i]);
            slot[i].transform.GetChild(0).gameObject.SetActive(slotFull[i]);
        }
    }
}
