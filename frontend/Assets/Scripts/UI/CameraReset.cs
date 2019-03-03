using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraReset : MonoBehaviour
{

    public void clickedReset()
    {
        SceneManager.LoadScene("ModelViewer");
    }
}
