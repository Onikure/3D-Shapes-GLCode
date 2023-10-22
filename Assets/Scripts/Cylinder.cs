using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder: MonoBehaviour
{
    public int numSegments = 16;  // Number of segments in the cylinder.
    public float height = 2.0f;  // Height of the cylinder.
    public float radius = 1.0f;  // Radius of the cylinder.

    void OnDrawGizmos()
    {
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Begin(GL.TRIANGLES);

        // Set the color of the cylinder.
        GL.Color(Color.blue);

        // Calculate the angle increment for each segment.
        float angleIncrement = 360.0f / numSegments;

        // Create the vertices for the cylinder.
        for (int i = 0; i < numSegments; i++)
        {
            float angle1 = i * angleIncrement;
            float angle2 = (i + 1) * angleIncrement;

            Vector3 p1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle1) * radius, 0, Mathf.Sin(Mathf.Deg2Rad * angle1) * radius);
            Vector3 p2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle1) * radius, height, Mathf.Sin(Mathf.Deg2Rad * angle1) * radius);
            Vector3 p3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle2) * radius, height, Mathf.Sin(Mathf.Deg2Rad * angle2) * radius);
            Vector3 p4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle2) * radius, 0, Mathf.Sin(Mathf.Deg2Rad * angle2) * radius);

            // Draw the sides of the cylinder.
            GL.Vertex(p1);
            GL.Vertex(p2);
            GL.Vertex(p3);

            GL.Vertex(p1);
            GL.Vertex(p3);
            GL.Vertex(p4);

            // Draw the top and bottom faces of the cylinder.
            GL.Vertex(p1);
            GL.Vertex(p4);
            GL.Vertex(p2);

            GL.Vertex(p4);
            GL.Vertex(p3);
            GL.Vertex(p2);
        }

        GL.End();
        GL.PopMatrix();
    }
}
