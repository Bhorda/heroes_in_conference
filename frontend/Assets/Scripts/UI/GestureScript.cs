using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;
using UnityEngine.SceneManagement;

public class GestureScript : MonoBehaviour
{
    public GameObject Camera;
    public GameObject toRotate;
    public FingersScript FingerScript;
    private PanGestureRecognizer panGesture;
    private RotateGestureRecognizer rotateGesture;
    private PanGestureRecognizer swipeGesture;

    private void PanGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            float deltaX = panGesture.DeltaX / 150.0f;
            float deltaY = panGesture.DeltaY / 150.0f;
            Vector3 pos = Camera.transform.position;
            /*pos.x -= deltaX;
            pos.y -= deltaY;
            Camera.transform.position = pos;*/
            Vector3 upVector = Camera.transform.up;
            Vector3 rightVector = Camera.transform.right;
            pos -= deltaY * (upVector.normalized);
            pos -= deltaX * (rightVector.normalized);
            Camera.transform.position = pos;
        }
    }

    private void CreatePanGesture()
    {
        panGesture = new PanGestureRecognizer();
        panGesture.MinimumNumberOfTouchesToTrack = panGesture.MaximumNumberOfTouchesToTrack = 2;
        panGesture.StateUpdated += PanGestureCallback;
        FingersScript.Instance.AddGesture(panGesture);
    }

    private void SwipeGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            float deltaX = swipeGesture.DeltaX / 250.0f;
            float deltaY = swipeGesture.DeltaY / 250.0f;
            toRotate.transform.RotateAround(Camera.transform.up, -deltaX);
            toRotate.transform.RotateAround(Camera.transform.right, deltaY);
        }
    }

    private void CreateSwipeGesture()
    {
        swipeGesture = new PanGestureRecognizer();
        swipeGesture.MinimumNumberOfTouchesToTrack = swipeGesture.MaximumNumberOfTouchesToTrack = 1;
        swipeGesture.StateUpdated += SwipeGestureCallback;
        FingersScript.Instance.AddGesture(swipeGesture);
    }

    private void RotateGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            toRotate.transform.RotateAround(Camera.transform.forward, rotateGesture.RotationDegreesDelta*Mathf.Deg2Rad*(7.0f));
        }
    }

    private void CreateRotateGesture()
    {
        rotateGesture = new RotateGestureRecognizer();
        rotateGesture.StateUpdated += RotateGestureCallback;
        FingersScript.Instance.AddGesture(rotateGesture);
    }


    void Start()
    {
        GameObject[] modelFinder;
        modelFinder = GameObject.FindGameObjectsWithTag("ModelToView");
        foreach (GameObject p in modelFinder)
        {
            if (p.activeInHierarchy)
            {
                toRotate = p;
                break;
            }
        }
        CreatePanGesture();
        CreateRotateGesture();
        CreateSwipeGesture();
        rotateGesture.AllowSimultaneousExecution(panGesture);
        panGesture.AllowSimultaneousExecution(rotateGesture);
    }

}
