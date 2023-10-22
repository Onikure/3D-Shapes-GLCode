using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float size = 2.0f; // Size of the plane.

    void OnDrawGizmos()
    {
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Begin(GL.QUADS);

        // Set the color of the plane.
        GL.Color(Color.green);

        // Define the vertices of the plane.
        Vector3 p1 = new Vector3(-size * 0.5f, 0, -size * 0.5f);
        Vector3 p2 = new Vector3(size * 0.5f, 0, -size * 0.5f);
        Vector3 p3 = new Vector3(size * 0.5f, 0, size * 0.5f);
        Vector3 p4 = new Vector3(-size * 0.5f, 0, size * 0.5f);

        // Draw the plane.
        GL.Vertex(p1);
        GL.Vertex(p2);
        GL.Vertex(p3);
        GL.Vertex(p4);

        GL.End();
        GL.PopMatrix();
    }
}
