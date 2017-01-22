using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseEdgeCollider : MonoBehaviour
{

    public int NumEdges = 1000;

    // Use this for initialization
    void Start()
    {

        float radius = GetComponent<CircleCollider2D>().radius;

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[NumEdges];

        for (int i = 0; i < NumEdges; i++)
        {
            float angle = 2 * Mathf.PI * i / NumEdges;
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);
        }
        edgeCollider.points = points;
    }
}