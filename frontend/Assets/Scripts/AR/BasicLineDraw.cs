using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLineDraw : MonoBehaviour
{
    public GameObject[] spheres;

    private Vector3[] vectors;
    private GameObject[] vertices;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.GetComponent<LineRenderer>();
        lineRenderer.alignment = LineAlignment.View;
        lineRenderer.numCapVertices = 5;
        lineRenderer.numCornerVertices = 5;
    }

    // Update is called once per frame
    void Update()
    {
        GetVisible();
        DrawLine();
    }

    private void GetVisible()
    {
        Vector3[] vectorsTemp = new Vector3[2];
        GameObject[] verticesTemp = new GameObject[2];

        // Fill lists if availble
        for (int i = 0; i < 2; i++)
        {
            if (spheres[i] != null)
            {
                if (spheres[i].GetComponent<MeshRenderer>().enabled)
                {
                    vectorsTemp[i] = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y, spheres[i].transform.position.z);
                    verticesTemp[i] = spheres[i];
                }
            }
        }

        vectors = vectorsTemp;
        vertices = verticesTemp;
    }

    private void DrawLine()
    {
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, vectors[0]);
        lineRenderer.SetPosition(1, vectors[1]);
    }

    public Vector3[] GetVectors ()
    {
        return vectors;
    }
}
