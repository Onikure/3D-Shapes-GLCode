using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    void OnDrawGizmos()
    {
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Begin(GL.TRIANGLES);

        // Define the vertices of the pyramid.
        Vector3 apex = new Vector3(0, 1, 0);
        Vector3[] baseVertices = new Vector3[]
        {
            new Vector3(-0.5f, 0, -0.5f),
            new Vector3(0.5f, 0, -0.5f),
            new Vector3(0.5f, 0, 0.5f),
            new Vector3(-0.5f, 0, 0.5f)
        };

        // Define the faces (triangles) of the pyramid.
        int[][] faces = new int[][]
        {
            new int[] {0, 1, 2}, // Front face
            new int[] {0, 2, 3}, // Front face
            new int[] {0, 3, 4}, // Right face
            new int[] {0, 4, 1}, // Right face
            new int[] {4, 3, 2}, // Base face
            new int[] {2, 1, 4}  // Base face
        };

        // Set the color of the pyramid.
        GL.Color(Color.red);

        // Draw the pyramid by iterating through the faces.
        foreach (int[] face in faces)
        {
            foreach (int vertexIndex in face)
            {
                Vector3 vertex = vertexIndex == 0 ? apex : baseVertices[vertexIndex - 1];
                GL.Vertex(vertex);
            }
        }

        GL.End();
        GL.PopMatrix();
    }
}