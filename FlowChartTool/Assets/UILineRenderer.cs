using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILineRenderer : Graphic
{
    public List<Vector2> points;
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        for (int i = 0; i < points.Count; i++)
        {
            Vector2 point = points[i];

            DrawVerticesForPoints(point, vh);
        }

    }

    void DrawVerticesForPoints(Vector2 point, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(-50.0f, 0);
        vh.AddVert(vertex);

        vertex.position = new Vector3(50.0f, 0);
        vh.AddVert(vertex);
    }
}
