using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public GameObject[] numpad;
    public GameObject sphere;
    public Material material;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private string buttonName;
    private int[] code;
    private Renderer render;
    private int pushCount;

    // Start is called before the first frame update
    void Start()
    {
        code = new int[4];
        render = sphere.GetComponent<Renderer>();
        pushCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushCount == 4)
        {
            pushCount = 0;
            if (code[0] == 1 && code[1] == 2 && code[2] == 3 && code[3] == 4)
            {
                // Yay you did it
                render.material = material;
            }
            else
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Returns name of the object hit
                buttonName = hit.transform.name;
                switch (buttonName)
                {
                    case "button1":
                        code[pushCount] = 1;
                        pushCount++;
                        break;
                    case "button2":
                        code[pushCount] = 2;
                        pushCount++;
                        break;
                    case "button3":
                        code[pushCount] = 3;
                        pushCount++;
                        break;
                    case "button4":
                        code[pushCount] = 4;
                        pushCount++;
                        break;
                    case "button5":
                        code[pushCount] = 5;
                        pushCount++;
                        break;
                    case "button6":
                        code[pushCount] = 6;
                        pushCount++;
                        break;
                    case "button7":
                        code[pushCount] = 7;
                        pushCount++;
                        break;
                    case "button8":
                        code[pushCount] = 8;
                        pushCount++;
                        break;
                    case "button9":
                        code[pushCount] = 9;
                        pushCount++;
                        break;
                    case "button0":
                        code[pushCount] = 0;
                        pushCount++;
                        break;
                }
            }
        }
    }
}
