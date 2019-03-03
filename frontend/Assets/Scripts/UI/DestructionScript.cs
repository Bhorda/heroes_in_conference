using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionScript : MonoBehaviour
{
    public GameObject mObject;
    public void DestroyOnClick()
    {
        Destroy(mObject);
    }
}
