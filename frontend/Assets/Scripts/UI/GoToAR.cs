using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAR : MonoBehaviour
{
    public void goToAR()
    {
        SceneManager.LoadScene("ARMain");
    }
}
