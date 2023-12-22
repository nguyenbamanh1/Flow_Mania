using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagBoxImage : Image
{
    public List<Vector3> points;

    float width;
    float height;

    public float thinkness = 10f;

    protected override void OnPopulateMesh(Mesh m)
    {
        base.OnPopulateMesh(m);
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        base.OnPopulateMesh(vh);
        vh.Clear();
        width = rectTransform.rect.width;
        height = rectTransform.rect.height;

        if (points.Count < 2)
            return;
        for (int i = 0; i < points.Count; i++)
        {
            DrawLine(points[i], vh);
        }
        for (int i = 0; i < points.Count - 1; i++)
        {
            int index = i * 5;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);

        }
    }

    void DrawLine(Vector3 point, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(-thinkness / 2, 0);
        vertex.position += new Vector3(point.x, point.y);
        vh.AddVert(vertex);

        vertex.position = new Vector3(thinkness / 2, 0);
        vertex.position += new Vector3(point.x, point.y);
        vh.AddVert(vertex);
    }
}
