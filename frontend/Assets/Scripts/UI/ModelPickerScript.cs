using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPickerScript : MonoBehaviour
{
    public GameObject[] ModelList;

    void Awake()
    {
        foreach(GameObject model in ModelList)
        {
            model.SetActive(false);
        }
        ModelList[SlotScript.modelIndex].SetActive(true);
    }
}
