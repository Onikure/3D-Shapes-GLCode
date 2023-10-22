using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGeneratorScript : MonoBehaviour
{
    public int numSegments = 16;  // Number of segments in the capsule.
    public float height = 2.0f;   // Height of the capsule.
    public float radius = 1.0f;   // Radius of the capsule.

    void OnDrawGizmos()
    {
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Begin(GL.LINES);

        // Set the color of the capsule.
        GL.Color(Color.magenta);

        // Calculate the angle increment for each segment.
        float angleIncrement = 360.0f / numSegments;

        // Create the vertices for the capsule.
        for (int i = 0; i < numSegments; i++)
        {
            float angle1 = i * angleIncrement;
            float angle2 = (i + 1) * angleIncrement;

            Vector3 p1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle1) * radius, -height * 0.5f, Mathf.Sin(Mathf.Deg2Rad * angle1) * radius);
            Vector3 p2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle1) * radius, height * 0.5f, Mathf.Sin(Mathf.Deg2Rad * angle1) * radius);
            Vector3 p3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle2) * radius, height * 0.5f, Mathf.Sin(Mathf.Deg2Rad * angle2) * radius);
            Vector3 p4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle2) * radius, -height * 0.5f, Mathf.Sin(Mathf.Deg2Rad * angle2) * radius);

            // Draw the sides of the capsule.
            GL.Vertex(p1);
            GL.Vertex(p2);

            GL.Vertex(p2);
            GL.Vertex(p3);

            GL.Vertex(p3);
            GL.Vertex(p4);

            // Draw the top and bottom circles of the capsule.
            if (i == 0)
            {
                GL.Vertex(p1);
                GL.Vertex(p4);
            }
            if (i == numSegments - 1)
            {
                GL.Vertex(p2);
                GL.Vertex(p3);
            }
        }

        GL.End();
        GL.PopMatrix();
    }
}
