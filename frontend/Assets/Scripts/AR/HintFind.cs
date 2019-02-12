using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFind : MonoBehaviour
{
    public GameObject sphere;
    public Material collected;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClipComplete;

    string hintNode;
    Renderer sphereRenderer;


    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = sphere.GetComponent<Renderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                hintNode = hit.transform.name;

                switch (hintNode) {
                    case "Sphere": 
                        sphereRenderer.material = collected;
                        // TODO: Add map item to inventory, add some animation to maybe destroy object on disintegration animation, add achievement

                        audioSource.clip = audioClip;
                        audioSource.Play();
                        break;
                }
            }
        }
    }
}
