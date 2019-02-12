using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTimetable : MonoBehaviour
{
    string eventName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Returns name of the object hit
                eventName = hit.transform.name;
                switch (eventName)
                {
                    case "eventName":
                        /*
                        TODO:
                        Need to get local database call for timetable update
                                              
                        Database.toggleInterest(event);
                        Animation.play(approved);                      
                        */

                        break;
                }
            }
        }
    }
}
