//using System.Collections.Generic;
//using UnityEngine;

//public class TargetInteraction : MonoBehaviour
//{
//    // Actual scene objects
//    public GameObject[] targetNodes;

//    // 
//    private Vector2[] nodePoints;
//    private GameObject[] nodes;

//    private LineRenderer lineRenderer;

//    // Start is called before the first frame update
//    void Start()
//    {
//        lineRenderer = gameObject.GetComponent<LineRenderer>();
//        lineRenderer.alignment = LineAlignment.View;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        GetVisible();
//        drawLines();
//    }

//    private void GetVisible()
//    {
//        List<Vector2> vertexList = new List<Vector2>();
//        List<GameObject> nodeList = new List<GameObject>();

//        // Fill lists if availble
//        for (int i = 0; i < targetNodes.Length; i++)
//        {
//            if (targetNodes[i] != null)
//            {
//                if (targetNodes[i].GetComponent<MeshRenderer>().enabled)
//                {

//                    vertexList.Add(new Vector2(targetNodes[i].transform.position.x, targetNodes[i].transform.position.y));
//                    nodeList.Add(targetNodes[i]);
//                }
//            }
//        }

//        // Convert to array
//        nodePoints = vertexList.ToArray();
//        nodes = nodeList.ToArray();
//    }

//    // Draw Lines for Line Renderer
//    private void drawLines()
//    {
//        // Set positions size
//        lineRenderer.positionCount = nodePoints.Length;

//        // Set all line positions
//        for (int i = 0; i < nodePoints.Length; i++)
//        {
//            lineRenderer.SetPosition(i, new Vector3(nodes[i].transform.position.x, nodes[i].transform.position.y, nodes[i].transform.position.z));
//        }

//        lineRenderer.numCapVertices = 3;
//        lineRenderer.numCornerVertices = 3;
//    }

//    private void calculation()
//    {
//        // Perimeter varible
//        double p = 0;
//        // Area varible
//        double area = 0;
//        // Type varible
//        int n = 0;

//        // Loop all points
//        for (int i = 0; i < nodes.Length; i++)
//        {
//            //          For test neighbors
//            //          int x0, x1, x2;

//            // Point before
//            Vector2 v0;
//            if ((i - 1) >= 0)
//            {
//                v0 = nodePoints[i - 1];                       // x0 = i - 1;
//            }
//            else
//            {
//                v0 = nodePoints[nodePoints.Length - 1];      // x0 = go_points.Length - 1;
//            }

//            // Point now
//            Vector2 v1 = nodePoints[i];                     // x1 = i;

//            // Point after
//            Vector2 v2;
//            if ((i + 1) < nodePoints.Length)
//            {
//                v2 = nodePoints[i + 1];                       // x2 = i + 1;
//            }
//            else
//            {
//                v2 = nodePoints[0];                         // x2 = 0;
//            }

//            // triangular distances
//            double dv0 = distance(v0.x, v0.y, v1.x, v1.y); // v0 & v1
//            double dv1 = distance(v1.x, v1.y, v2.x, v2.y); // v1 & v2
//            double dv2 = distance(v0.x, v0.y, v2.x, v2.y); // v0 & v2

//            // Perimeter

//            p += dv1;

//            // Area

//            double temp_area = (v1.x * v2.y) - (v1.y * v2.x);
//            area += temp_area;

//            // Type

//            n++;

//            // Angle

//            // Set point angle ∠v0v1v2
//            double a = angle(dv0, dv1, dv2, v0.x, v0.y, v1.x, v1.y, v2.x, v2.y);
//            //  test neighbors 

//            // Distance

//            // Set distance position
//            Vector2 mp = midPoint(v1.x, v1.y, v2.x, v2.y);

//            // Set distance angle
//            double az = angle_zero(v1.x, v1.y, v2.x, v2.y);
//        }
//    }

//    // Distance between two points (Pitagor theory)
//    private double distance(float x1, float y1, float x2, float y2)
//    {
//        float a = System.Math.Abs(x1 - x2);
//        float b = System.Math.Abs(y1 - y2);
//        double c = System.Math.Sqrt(a * a + b * b);

//        return c;
//    }

//    // Angle between two lines(three points) anticlockwise
//    private double angle(double i1, double i2, double i3, float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
//    {
//        double k = ((i2 * i2) + (i1 * i1) - (i3 * i3)) / (2 * i1 * i2);
//        double d = System.Math.Acos(k) * (180 / System.Math.PI);

//        double dd = direction(p1x, p1y, p2x, p2y, p3x, p3y);

//        if (dd > 0)
//        {
//            d = 360 - d;
//        }

//        return d;
//    }
//    private double direction(float x1, float y1, float x2, float y2, float x3, float y3)
//    {
//        double d = ((x2 - x1) * (y3 - y1)) - ((y2 - y1) * (x3 - x1));
//        return d;
//    }

//    // Middle Point betwwen two points
//    private Vector2 midPoint(float x1, float y1, float x2, float y2)
//    {
//        float x = (x1 + x2) / 2;
//        float y = (y1 + y2) / 2;
//        return new Vector2(x, y);
//    }

//    // Zero way angle betwwen two points
//    private double angle_zero(float x1, float y1, float x2, float y2)
//    {
//        double xDiff = x2 - x1;
//        double yDiff = y2 - y1;
//        double d = System.Math.Atan2(yDiff, xDiff) * (180 / System.Math.PI);
//        return d;
//    }
//}

