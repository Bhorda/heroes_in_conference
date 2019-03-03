using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupScript : MonoBehaviour
{
    public GameObject mAchievement;
    public static PopupScript ps;

    void Awake()
    {
        ps = GetComponent<PopupScript>();
    }

    void Start()
    {
        mAchievement.SetActive(false);
    }

    public void GotAchievement(string title, string desc)
    {
        mAchievement.transform.name = "Achievement " + title;
        TextMeshProUGUI[] texts = mAchievement.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = title;
        texts[1].text = desc;
        mAchievement.SetActive(true);
    }
}
